using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.DataAccess
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string DetailUrl { get; set; }
        [DefaultValue(100)]
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
    }
}
