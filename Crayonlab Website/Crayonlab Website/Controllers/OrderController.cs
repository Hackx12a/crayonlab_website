using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Crayonlab.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public IActionResult SendOrderEmail([FromBody] OrderData orderData)
        {
            try
            {
                // Configure email settings (you'll need to use your actual email settings)
                string shopEmail = "princemartinez275@gmail.com"; // Replace with your email
                string subject = "New Order from Crayonlab Website";

                // Create email body
                StringBuilder body = new StringBuilder();
                body.AppendLine("<html><body>");
                body.AppendLine("<h2>New Order Details</h2>");
                body.AppendLine($"<p><strong>Date:</strong> {DateTime.Parse(orderData.Date).ToString("yyyy-MM-dd HH:mm:ss")}</p>");

                // Customer info
                body.AppendLine("<h3>Customer Information</h3>");
                body.AppendLine("<ul>");
                body.AppendLine($"<li><strong>Name:</strong> {orderData.Customer.FirstName} {orderData.Customer.LastName}</li>");
                body.AppendLine($"<li><strong>Address:</strong> {orderData.Customer.Address}</li>");
                body.AppendLine($"<li><strong>Contact Number:</strong> {orderData.Customer.ContactNumber}</li>");
                body.AppendLine($"<li><strong>Email:</strong> {orderData.Customer.Email}</li>");
                body.AppendLine("</ul>");

                // Order items
                body.AppendLine("<h3>Order Items</h3>");
                body.AppendLine("<table border='1' cellpadding='5' style='border-collapse: collapse;'>");
                body.AppendLine("<tr><th>Product</th><th>Size</th><th>Gender</th><th>Quantity</th><th>Price</th><th>Total</th></tr>");

                foreach (var item in orderData.Items)
                {
                    string gender = item.Gender == "men" ? "Men's" : "Women's";
                    decimal itemTotal = item.Price * item.Quantity;
                    body.AppendLine($"<tr>");
                    body.AppendLine($"<td>{item.Name}</td>");
                    body.AppendLine($"<td>{item.Size}</td>");
                    body.AppendLine($"<td>{gender}</td>");
                    body.AppendLine($"<td>{item.Quantity}</td>");
                    body.AppendLine($"<td>₱{item.Price:0.00}</td>");
                    body.AppendLine($"<td>₱{itemTotal:0.00}</td>");
                    body.AppendLine($"</tr>");
                }

                body.AppendLine("</table>");

                // Order summary
                body.AppendLine("<h3>Order Summary</h3>");
                body.AppendLine("<ul>");
                body.AppendLine($"<li><strong>Subtotal:</strong> ₱{orderData.Total:0.00}</li>");
                body.AppendLine($"<li><strong>Shipping:</strong> ₱{orderData.Shipping:0.00}</li>");
                body.AppendLine($"<li><strong>Total Amount:</strong> ₱{(orderData.Total + orderData.Shipping):0.00}</li>");
                body.AppendLine($"<li><strong>Payment Method:</strong> {orderData.PaymentMethod}</li>");
                body.AppendLine("</ul>");

                body.AppendLine("</body></html>");

                // Send email
                using (var client = new SmtpClient())
                {
                    // Configure your SMTP settings
                    client.Host = "smtp.gmail.com"; // Replace with your SMTP server
                    client.Port = 587; // Common SMTP port
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("princemartinez275@gmail.com", "ytvhybojrwtadlrs");

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress("princemartinez275@gmail.com", "Crayonlab Online Store");
                        message.To.Add(new MailAddress(shopEmail));

                        // Send a copy to the customer for confirmation
                        message.Bcc.Add(new MailAddress(orderData.Customer.Email));

                        message.Subject = subject;
                        message.Body = body.ToString();
                        message.IsBodyHtml = true;

                        client.Send(message);
                    }
                }

                return Ok(new { success = true, message = "Order email sent successfully" });
            }
            catch (Exception ex)
            {
                // Log the error (in a production app)
                Console.WriteLine("Error sending email: " + ex.Message);

                // Return error response
                return StatusCode(500, new { success = false, message = "Error sending email: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SendFooterContactMessage([FromBody] ContactMessage message)
        {
            try
            {
                // Configure email settings
                string shopEmail = "princemartinez275@gmail.com"; // Replace with your email
                string subject = "New Message from Website Contact Form";

                // Create email body
                StringBuilder body = new StringBuilder();
                body.AppendLine("<html><body>");
                body.AppendLine("<h2>New Message</h2>");
                body.AppendLine($"<p><strong>First Name:</strong> {message.FirstName}</p>");
                body.AppendLine($"<p><strong>Last Name:</strong> {message.LastName}</p>");
                body.AppendLine($"<p><strong>Contact Number:</strong> {message.ContactNumber}</p>");
                body.AppendLine($"<p><strong>Message:</strong> {message.Message}</p>");
                body.AppendLine("</body></html>");

                // Send email logic (similar to the SendOrderEmail method)
                using (var client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com"; // Replace with your SMTP server
                    client.Port = 587; // Common SMTP port
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("princemartinez275@gmail.com", "ytvhybojrwtadlrs");

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.From = new MailAddress("princemartinez275@gmail.com", "Crayonlab Contact Form");
                        emailMessage.To.Add(new MailAddress(shopEmail));
                        emailMessage.Subject = subject;
                        emailMessage.Body = body.ToString();
                        emailMessage.IsBodyHtml = true;

                        client.Send(emailMessage);
                    }
                }

                return Ok(new { success = true, message = "Your message has been sent successfully!" });
            }
            catch (Exception ex)
            {
                // Log the error (in a production app)
                Console.WriteLine("Error sending message: " + ex.Message);
                return StatusCode(500, new { success = false, message = "Error sending message: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SendContactEmail([FromBody] ContactFormModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Invalid contact form data." });
            }

            try
            {
                string subject = $"New Contact Form Submission from {model.FirstName} {model.LastName}";
                StringBuilder body = new StringBuilder();
                body.AppendLine("<html><body>");
                body.AppendLine("<h2>New Contact Form Submission</h2>");
                body.AppendLine($"<p><strong>Name:</strong> {model.FirstName} {model.LastName}</p>");
                body.AppendLine($"<p><strong>Company:</strong> {model.CompanyName ?? "Not provided"}</p>");
                body.AppendLine($"<p><strong>Email:</strong> {model.Email}</p>");
                body.AppendLine($"<p><strong>Phone:</strong> {model.ContactNumber}</p>");
                body.AppendLine($"<p><strong>Company Address:</strong> {model.CompanyAddress ?? "Not provided"}</p>");
                body.AppendLine("<h3>Message:</h3>");
                body.AppendLine($"<p>{model.Message}</p>");
                body.AppendLine("</body></html>");

                using (var client = new SmtpClient())
                {
                    // Configure your SMTP settings
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("princemartinez275@gmail.com", "ytvhybojrwtadlrs");

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress("princemartinez275@gmail.com", "Crayonlab Online Store");
                        message.To.Add(new MailAddress("princemartinez275@gmail.com")); // Send to shop email
                        message.Subject = subject;
                        message.Body = body.ToString();
                        message.IsBodyHtml = true;

                        client.Send(message);
                    }
                }

                return Ok(new { success = true, message = "Your message has been sent successfully." });
            }
            catch (Exception ex)
            {
                // Log the error (in a production app)
                Console.WriteLine("Error sending email: " + ex.Message);

                // Return error response
                return StatusCode(500, new { success = false, message = "Error sending email: " + ex.Message });
            }
        }
    }

    // Data model classes to match JSON sent from client
    public class OrderData
    {
        public string Date { get; set; }
        public OrderItem[] Items { get; set; }
        public decimal Total { get; set; }
        public decimal Shipping { get; set; }
        public string PaymentMethod { get; set; }
        public CustomerInfo Customer { get; set; }
    }

    public class OrderItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Gender { get; set; }
        public int Quantity { get; set; }
    }

    public class CustomerInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }

    public class ContactFormModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Message { get; set; }
    }


    public class ContactMessage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Message { get; set; }
    }
}
