using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.DataAccess
{
    public class WebsiteConfiguration
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
