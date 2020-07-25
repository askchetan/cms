using CMS.DataAccess;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS
{
    public class CommonData
    {
        private static readonly Lazy<CommonData> lazy = new Lazy<CommonData>(() => new CommonData(new CMSDbContext()));
        private readonly CMSDbContext _context;
        private IEnumerable<Page> _pages;
        private IEnumerable<WebsiteConfiguration> _websiteConfigurations;
        private CommonData(CMSDbContext context)
        {
            _context = context;
        }
        public static CommonData Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public string GetValue(string key)
        {
            if (_websiteConfigurations == null)
            {
                _websiteConfigurations = _context.websiteConfigurations;
            }

            return _websiteConfigurations.FirstOrDefault(wc => wc.Key == key)?.Value ?? string.Empty;
        }
        /// <summary>
        /// Get the dynamic pages list
        /// </summary>
        public IEnumerable<Page> Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = _context.Pages.Where(p=>p.IsActive).OrderBy(p=>p.DisplayOrder);
                }
                return _pages;
            }
        }
        public void ResetWebsiteConfiguration()
        {
            _websiteConfigurations = null;
        }
        public void ResetPagesCache()
        {
            _pages = null;
        }

    }
}
;