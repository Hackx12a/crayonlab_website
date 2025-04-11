namespace Crayonlab.Models
{
    public class ShirtType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<ShirtDesign> ShirtDesigns { get; set; }
    }
}