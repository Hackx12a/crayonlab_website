namespace Crayonlab.Models
{
    public class BasketballJersey
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string FrontDesign { get; set; } = "";
        public string BackDesign { get; set; } = "";
        public string ShortsDesign { get; set; } = "";
        public Decimal MenXSPrice { get; set; }
        public Decimal MenSPrice { get; set; }
        public Decimal MenMPrice { get; set; }
        public Decimal MenLPrice { get; set; }
        public Decimal MenXLPrice { get; set; }
        public Decimal MenXXLPrice { get; set; }
        public Decimal WomenXSPrice { get; set; }
        public Decimal WomenSPrice { get; set; }
        public Decimal WomenMPrice { get; set; }
        public Decimal WomenLPrice { get; set; }
        public Decimal WomenXLPrice { get; set; }
        public Decimal WomenXXLPrice { get; set; }
    }
}