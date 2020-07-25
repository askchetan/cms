using CMS.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Controllers
{
    public class BaseController : Controller
    {
        protected readonly CMSDbContext _context;
        public BaseController(CMSDbContext context)
        {
            _context = context;           
        }
    }
}
