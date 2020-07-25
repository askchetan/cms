using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.DataAccess
{
    public class PageSEO
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Page.PageId")]
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
    }
}