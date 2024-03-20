using System.ComponentModel.DataAnnotations;

namespace MyRESTServices.BLL.DTOs
{
    public class ArticleCreateDTO
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Details { get; set; }

        public bool IsApproved { get; set; }

        public string Pic { get; set; }
    }
}
