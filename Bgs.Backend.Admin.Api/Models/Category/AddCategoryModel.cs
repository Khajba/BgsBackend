using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Category
{
    public class AddCategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}