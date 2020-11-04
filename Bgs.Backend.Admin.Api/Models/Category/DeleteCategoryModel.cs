using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Category
{
    public class DeleteCategoryModel
    {
        [Required]
        public int? Id { get; set; }
    }
}