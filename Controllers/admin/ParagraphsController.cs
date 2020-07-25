﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.DataAccess;

namespace CMS.Controllers
{
    public class ParagraphsController : BaseController
    {
        private readonly CMSDbContext _context;
        private const string ViewPathFormat = "~/Views/Admin/Paragraphs/{0}.cshtml";

        public ParagraphsController(CMSDbContext context): base (context)
        {
            _context = context;
        }

        // GET: Paragraphs
        public async Task<IActionResult> Index()
        {
            var cMSDbContext = _context.Paragraph.Include(p => p.Page);
            return View(string.Format(ViewPathFormat, "Index"), await cMSDbContext.ToListAsync());
        }

        // GET: Paragraphs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragraph = await _context.Paragraph
                .Include(p => p.Page)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paragraph == null)
            {
                return NotFound();
            }

            return View(string.Format(ViewPathFormat, "Details"), paragraph);
        }

        // GET: Paragraphs/Create
        public IActionResult Create()
        {
            ViewData["PageId"] = new SelectList(_context.Pages, "PageId", "Name");
            return View(string.Format(ViewPathFormat, "Create"));
        }

        // POST: Paragraphs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PageId,Title,DisplayOrder,Details")] Paragraph paragraph)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paragraph);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PageId"] = new SelectList(_context.Pages, "PageId", "Name", paragraph.PageId);
            return View(string.Format(ViewPathFormat, "Create"),paragraph);
        }

        // GET: Paragraphs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragraph = await _context.Paragraph.FindAsync(id);
            if (paragraph == null)
            {
                return NotFound();
            }
            ViewData["PageId"] = new SelectList(_context.Pages, "PageId", "Name", paragraph.PageId);
            return View(string.Format(ViewPathFormat, "Edit"), paragraph);
        }

        // POST: Paragraphs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PageId,Title,DisplayOrder,Details")] Paragraph paragraph)
        {
            if (id != paragraph.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paragraph);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParagraphExists(paragraph.Id))
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
            ViewData["PageId"] = new SelectList(_context.Pages, "PageId", "PageId", paragraph.PageId);
            return View(string.Format(ViewPathFormat, "Edit"),paragraph);
        }

        // GET: Paragraphs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paragraph = await _context.Paragraph
                .Include(p => p.Page)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paragraph == null)
            {
                return NotFound();
            }

            return View(string.Format(ViewPathFormat, "Delete"),paragraph);
        }

        // POST: Paragraphs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paragraph = await _context.Paragraph.FindAsync(id);
            _context.Paragraph.Remove(paragraph);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParagraphExists(int id)
        {
            return _context.Paragraph.Any(e => e.Id == id);
        }
    }
}
