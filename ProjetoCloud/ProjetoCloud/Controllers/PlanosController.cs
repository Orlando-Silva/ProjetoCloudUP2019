using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCloud.Models;

namespace ProjetoCloud.Controllers
{
    [Authorize]
    public class PlanosController : Controller
    {
        private readonly Contexto _context;

        public PlanosController(Contexto context)
        {
            _context = context;
        }

        // GET: Planos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planos.ToListAsync());
        }

        // GET: Planos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Planos
                .FirstOrDefaultAsync(m => m.Id_Plano == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // GET: Planos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Plano,Nome_Plano,Valor_Plano,Qtde_Max_Dispositivos_Plano")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                plano.Data_Cadastro_Plano = DateTime.Now;
                _context.Add(plano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plano);
        }

        // GET: Planos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Planos.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }
            return View(plano);
        }

        // POST: Planos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Plano,Nome_Plano,Valor_Plano,Qtde_Max_Dispositivos_Plano")] Plano plano)
        {
            if (id != plano.Id_Plano)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    plano.Data_Cadastro_Plano = DateTime.Now;
                    _context.Update(plano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoExists(plano.Id_Plano))
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
            return View(plano);
        }

        // GET: Planos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Planos
                .FirstOrDefaultAsync(m => m.Id_Plano == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // POST: Planos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plano = await _context.Planos.FindAsync(id);
            _context.Planos.Remove(plano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoExists(int id)
        {
            return _context.Planos.Any(e => e.Id_Plano == id);
        }
    }
}
