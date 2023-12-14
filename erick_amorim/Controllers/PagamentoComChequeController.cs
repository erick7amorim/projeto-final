#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using erick_amorim.Models;
using erick_amorim.Data;

namespace erick_amorim.Controllers
{
    public class PagamentoComChequeController : Controller
    {
        private readonly Contexto _context;

        public PagamentoComChequeController(Contexto context)
        {
            _context = context;
        }

        // GET: PagamentoComCheque
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.PagamentoComCheque.Include(p => p.NotaDeVenda);
            return View(await myDbContext.ToListAsync());
        }

        // GET: PagamentoComCheque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque
                .Include(p => p.NotaDeVenda)
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoComCheque);
        }

        // GET: PagamentoComCheque/Create
        public IActionResult Create()
        {
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId");
            return View();
        }

        // POST: PagamentoComCheque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Banco,NomeDoBanco,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais,NotaDeVendaId")] PagamentoComCheque pagamentoComCheque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoComCheque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId", pagamentoComCheque.NotaDeVendaId);
            return View(pagamentoComCheque);
        }

        // GET: PagamentoComCheque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId", pagamentoComCheque.NotaDeVendaId);
            return View(pagamentoComCheque);
        }

        // POST: PagamentoComCheque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Banco,NomeDoBanco,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais,NotaDeVendaId")] PagamentoComCheque pagamentoComCheque)
        {
            if (id != pagamentoComCheque.TipoPagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoComCheque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoComChequeExists(pagamentoComCheque.TipoPagamentoId))
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
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId", pagamentoComCheque.NotaDeVendaId);
            return View(pagamentoComCheque);
        }

        // GET: PagamentoComCheque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque
                .Include(p => p.NotaDeVenda)
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoComCheque);
        }

        // POST: PagamentoComCheque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);
            _context.PagamentoComCheque.Remove(pagamentoComCheque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoComChequeExists(int id)
        {
            return _context.PagamentoComCheque.Any(e => e.TipoPagamentoId == id);
        }
    }
}
