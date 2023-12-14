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
    public class PagamentoComCartaoController : Controller
    {
        private readonly Contexto _context;

        public PagamentoComCartaoController(Contexto context)
        {
            _context = context;
        }

        // GET: PagamentoComCartao
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.PagamentoComCartao.Include(p => p.NotaDeVenda);
            return View(await myDbContext.ToListAsync());
        }

        // GET: PagamentoComCartao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCartao = await _context.PagamentoComCartao
                .Include(p => p.NotaDeVenda)
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoComCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoComCartao);
        }

        // GET: PagamentoComCartao/Create
        public IActionResult Create()
        {
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId");
            return View();
        }

        // POST: PagamentoComCartao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroDoCartao,Bandeira,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais,NotaDeVendaId")] PagamentoComCartao pagamentoComCartao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoComCartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId", pagamentoComCartao.NotaDeVendaId);
            return View(pagamentoComCartao);
        }

        // GET: PagamentoComCartao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCartao = await _context.PagamentoComCartao.FindAsync(id);
            if (pagamentoComCartao == null)
            {
                return NotFound();
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId", pagamentoComCartao.NotaDeVendaId);
            return View(pagamentoComCartao);
        }

        // POST: PagamentoComCartao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroDoCartao,Bandeira,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais,NotaDeVendaId")] PagamentoComCartao pagamentoComCartao)
        {
            if (id != pagamentoComCartao.TipoPagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoComCartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoComCartaoExists(pagamentoComCartao.TipoPagamentoId))
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
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "NotaDeVendaId", "NotaDeVendaId", pagamentoComCartao.NotaDeVendaId);
            return View(pagamentoComCartao);
        }

        // GET: PagamentoComCartao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCartao = await _context.PagamentoComCartao
                .Include(p => p.NotaDeVenda)
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoComCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoComCartao);
        }

        // POST: PagamentoComCartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoComCartao = await _context.PagamentoComCartao.FindAsync(id);
            _context.PagamentoComCartao.Remove(pagamentoComCartao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoComCartaoExists(int id)
        {
            return _context.PagamentoComCartao.Any(e => e.TipoPagamentoId == id);
        }
    }
}
