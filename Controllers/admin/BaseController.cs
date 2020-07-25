using CMS.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers.Admin
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly CMSDbContext _context;
        public BaseController(CMSDbContext context)
        {
            _context = context;
        }
    }
}
