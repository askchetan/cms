using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.DataAccess
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [DefaultValue(100)]
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool TopMenu { get; set; }
        public bool BottomMenu { get; set; }
        public virtual PageSEO PageSEO { get; set; }
        public virtual List<Paragraph> Paragraphs{ get; set; }
    }
}