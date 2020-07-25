using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.DataAccess
{
    public class Paragraph
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Page.PageId")]
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        [DefaultValue(100)]
        public int DisplayOrder { get; set; }
    }
}