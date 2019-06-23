using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contexto;
using DAL.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCloud.Areas.Identity.Data;
using ProjetoCloud.Models;

namespace ProjetoCloud.Controllers
{

    [Authorize]
    public class AmbientesController : Controller
    {
        private readonly CloudContexto _context;
        private readonly UserManager<ProjetoCloudUser> _userManager;


        public AmbientesController(CloudContexto context, UserManager<ProjetoCloudUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Ambientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ambientes.Include(a => a.Usuario).ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id_Ambiente,Nome_Ambiente")] DAL.Entidades.Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                var nome_ambiente = "";
                var cont = 0;

                nome_ambiente = ambiente.Nome_Ambiente;

                List<Dispositivo> dispositivos = _context.Dispositivos.Where(_ => _.Ambiente.Nome_Ambiente.Equals(nome_ambiente)).ToList();

                foreach (var item in dispositivos)
                {
                    cont++;
                }

                var usuarioIdentity = await _userManager.GetUserAsync(User);
                var usuario = _context.Usuarios.Find(usuarioIdentity.UsuarioId);
                ambiente.Usuario = usuario;
                ambiente.Qtda_Dispositivo_Ambiente = cont;
                ambiente.Data_Cadastro_Ambiente = DateTime.Now;
                
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
        public async Task<IActionResult> Edit(int id, [Bind("Id_Ambiente,Nome_Ambiente,Qtda_Dispositivo_Ambiente")] DAL.Entidades.Ambiente ambiente)
        {
            if (id != ambiente.Id_Ambiente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ambiente.Qtda_Dispositivo_Ambiente = _context.Dispositivos.Where(_ => _.Ambiente.Nome_Ambiente.Equals(ambiente.Nome_Ambiente)).Count();
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
            int id_ambiente = ambiente.Id_Ambiente;

            if (ambiente.Qtda_Dispositivo_Ambiente < 1)
            {
                _context.Ambientes.Remove(ambiente);
                await _context.SaveChangesAsync();
            }
            else
            {
                List<Dispositivo> dispositivos = _context.Dispositivos.Where(_ => _.Ambiente.Id_Ambiente == id_ambiente).ToList();

                foreach (var item in dispositivos)
                {
                    _context.Dispositivos.Remove(item);
                    await _context.SaveChangesAsync();
                }
                
                _context.Ambientes.Remove(ambiente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AmbienteExists(int id)
        {
            return _context.Ambientes.Any(e => e.Id_Ambiente == id);
        }
    }
}
