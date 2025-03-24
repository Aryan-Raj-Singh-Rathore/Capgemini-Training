using System.ComponentModel.DataAnnotations;

namespace phonebookapi.Models
{
    public class Product
    {
        [Key]
        public string Name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
    }

}
