using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.DataAccess;

namespace CMS.Controllers.admin
{
    public class WebsiteConfigurationsController : BaseController
    {
        private const string ViewPathFormat = "~/Views/Admin/WebsiteConfigurations/{0}.cshtml";

        public WebsiteConfigurationsController(CMSDbContext context) : base(context)
        {
        }

        // GET: WebsiteConfigurations
        public async Task<IActionResult> Index()
        {
            return View(string.Format(ViewPathFormat, "Index"), await _context.websiteConfigurations.ToListAsync());
        }

        // GET: WebsiteConfigurations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websiteConfiguration = await _context.websiteConfigurations
                .FirstOrDefaultAsync(m => m.Key == id);
            if (websiteConfiguration == null)
            {
                return NotFound();
            }

            return View(string.Format(ViewPathFormat, "Details"), websiteConfiguration);
        }

        // GET: WebsiteConfigurations/Create
        public IActionResult Create()
        {
            return View(string.Format(ViewPathFormat, "Create"));
        }

        // POST: WebsiteConfigurations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Key,Value")] WebsiteConfiguration websiteConfiguration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(websiteConfiguration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(string.Format(ViewPathFormat, "Create"), websiteConfiguration);
        }

        // GET: WebsiteConfigurations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websiteConfiguration = await _context.websiteConfigurations.FindAsync(id);
            if (websiteConfiguration == null)
            {
                return NotFound();
            }
            return View(string.Format(ViewPathFormat, "Edit"), websiteConfiguration);
        }

        // POST: WebsiteConfigurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Key,Value")] WebsiteConfiguration websiteConfiguration)
        {
            if (id != websiteConfiguration.Key)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(websiteConfiguration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebsiteConfigurationExists(websiteConfiguration.Key))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(websiteConfiguration);
        }

        // GET: WebsiteConfigurations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websiteConfiguration = await _context.websiteConfigurations
                .FirstOrDefaultAsync(m => m.Key == id);
            if (websiteConfiguration == null)
            {
                return NotFound();
            }

            return View(string.Format(ViewPathFormat, "Delete"), websiteConfiguration);
        }

        // POST: WebsiteConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var websiteConfiguration = await _context.websiteConfigurations.FindAsync(id);
            _context.websiteConfigurations.Remove(websiteConfiguration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebsiteConfigurationExists(string id)
        {
            return _context.websiteConfigurations.Any(e => e.Key == id);
        }
    }
}
