using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.DataAccess;

namespace CMS.Controllers
{
    public class PageSEOsController : BaseController
    {
        private readonly CMSDbContext _context;
        private const string ViewPathFormat = "~/Views/Admin/PageSEOs/{0}.cshtml";

        public PageSEOsController(CMSDbContext context)
            :base(context)
        {
            _context = context;
        }

        // GET: PageSEOs
        public async Task<IActionResult> Index()
        {
            var cMSDbContext = _context.PageSEOs.Include(p => p.Page);
            return View(string.Format(ViewPathFormat, "Index"), await cMSDbContext.ToListAsync());
        }

        // GET: PageSEOs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageSEO = await _context.PageSEOs
                .Include(p => p.Page)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pageSEO == null)
            {
                return NotFound();
            }

            return View(string.Format(ViewPathFormat, "Details"), pageSEO);
        }

        // GET: PageSEOs/Create
        public IActionResult Create()
        {
            ViewData["Pages"] = new SelectList(_context.Pages, "PageId", "Name");
            return View(string.Format(ViewPathFormat, "Create"));
        }

        // POST: PageSEOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PageId,MetaTag,MetaDescription")] PageSEO pageSEO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pageSEO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PageId"] = new SelectList(_context.Pages, "PageId", "PageId", pageSEO.PageId);
            return View(string.Format(ViewPathFormat, "Create"), pageSEO);
        }

        // GET: PageSEOs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageSEO = await _context.PageSEOs.FindAsync(id);
            if (pageSEO == null)
            {
                return NotFound();
            }
            ViewData["PageId"] = new SelectList(_context.Pages, "PageId", "PageId", pageSEO.PageId);
            return View(string.Format(ViewPathFormat, "Edit"), pageSEO);
        }

        // POST: PageSEOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PageId,MetaTag,MetaDescription")] PageSEO pageSEO)
        {
            if (id != pageSEO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageSEO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageSEOExists(pageSEO.Id))
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
            ViewData["PageId"] = new SelectList(_context.Pages, "PageId", "PageId", pageSEO.PageId);
            return View(string.Format(ViewPathFormat, "Edit"), pageSEO);
        }

        // GET: PageSEOs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageSEO = await _context.PageSEOs
                .Include(p => p.Page)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pageSEO == null)
            {
                return NotFound();
            }

            return View(string.Format(ViewPathFormat, "Delete"), pageSEO);
        }

        // POST: PageSEOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pageSEO = await _context.PageSEOs.FindAsync(id);
            _context.PageSEOs.Remove(pageSEO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageSEOExists(int id)
        {
            return _context.PageSEOs.Any(e => e.Id == id);
        }
    }
}
