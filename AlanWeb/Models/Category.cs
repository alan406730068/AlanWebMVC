using System.ComponentModel.DataAnnotations;

namespace AlanWeb.Models
{
    public class Category
    {
        //可加入[Key]，此欄位將視為主鍵(但系統會將包含id的欄位視為主鍵)
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Display(Name = "種類名稱")]
        [MaxLength(30, ErrorMessage = "長度已超過30")]
        [Required(ErrorMessage = "請輸入名稱(長度不能超過30)")]
        public string? Name { get; set; }
        [Display(Name = "展示順序")]
        [Range(1, 100, ErrorMessage = "請輸入 1 ~ 100 之間")]
        [Required(ErrorMessage = "請輸入展示順序")]

        public int? DisplayOrder { get; set; }

    }
}
