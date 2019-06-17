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
    public class AmbientesController : Controller
    {
        private readonly Contexto _context;

        public AmbientesController(Contexto context)
        {
            _context = context;
        }

        // GET: Ambientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ambientes.ToListAsync());
        }

        // GET: Ambientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambiente = await _context.Ambientes
                .FirstOrDefaultAsync(m => m.Id_Ambiente == id);
            if (ambiente == null)
            {
                return NotFound();
            }

            return View(ambiente);
        }

        // GET: Ambientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ambientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Ambiente,Nome_Ambiente")] Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                ambiente.Data_Cadastro_Ambiente = DateTime.Now;
                ambiente.Qtda_Dispositivo_Ambiente = 0 ;

                _context.Add(ambiente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ambiente);
        }

        // GET: Ambientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambiente = await _context.Ambientes.FindAsync(id);
            if (ambiente == null)
            {
                return NotFound();
            }
            return View(ambiente);
        }

        // POST: Ambientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Ambiente,Nome_Ambiente,Qtda_Dispositivo_Ambiente")] Ambiente ambiente)
        {
            if (id != ambiente.Id_Ambiente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ambiente.Data_Cadastro_Ambiente = DateTime.Now;
                    _context.Update(ambiente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmbienteExists(ambiente.Id_Ambiente))
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
            return View(ambiente);
        }

        // GET: Ambientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambiente = await _context.Ambientes
                .FirstOrDefaultAsync(m => m.Id_Ambiente == id);
            if (ambiente == null)
            {
                return NotFound();
            }

            return View(ambiente);
        }

        // POST: Ambientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ambiente = await _context.Ambientes.FindAsync(id);
            _context.Ambientes.Remove(ambiente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmbienteExists(int id)
        {
            return _context.Ambientes.Any(e => e.Id_Ambiente == id);
        }
    }
}
