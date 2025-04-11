namespace Crayonlab.Models
{
    public class ShirtDesign
    {
        public int Id { get; set; }

        // Foreign key
        public int ShirtTypeId { get; set; }

        // Navigation property
        public ShirtType ShirtType { get; set; }

        public string Name { get; set; }
        public string FrontDesign { get; set; }
        public string BackDesign { get; set; }
        public string ShortsDesign { get; set; } = "";

        // Prices
        public decimal MenXSPrice { get; set; }
        public decimal MenSPrice { get; set; }
        public decimal MenMPrice { get; set; }
        public decimal MenLPrice { get; set; }
        public decimal MenXLPrice { get; set; }
        public decimal MenXXLPrice { get; set; }

        public decimal WomenXSPrice { get; set; }
        public decimal WomenSPrice { get; set; }
        public decimal WomenMPrice { get; set; }
        public decimal WomenLPrice { get; set; }
        public decimal WomenXLPrice { get; set; }
        public decimal WomenXXLPrice { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

}