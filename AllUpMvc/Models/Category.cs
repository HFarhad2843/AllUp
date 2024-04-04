using System.ComponentModel.DataAnnotations;

namespace AllUpMVC.Models
{
    public class Category : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }

        public List<Product>? Products { get; set; }
    }
}
