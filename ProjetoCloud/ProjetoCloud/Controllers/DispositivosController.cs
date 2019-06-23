using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contexto;
using DAL.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCloud.DTO;
using ProjetoCloud.Models;
using Dispositivo = DAL.Entidades.Dispositivo;

namespace ProjetoCloud.Controllers
{
    [Authorize]
    public class DispositivosController : Controller
    {
        private readonly CloudContexto _context;
        private readonly IMapper _mapper;


        public DispositivosController(CloudContexto context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Dispositivos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dispositivos.Include(d => d.Ambiente).ToListAsync());
        }

        // GET: Dispositivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivos
                .FirstOrDefaultAsync(m => m.Id_Dispositivo == id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        // GET: Dispositivos/Create
        public IActionResult Create()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult ValidateDispositivo(string nome_ambiente)
        {
            Ambiente ambiente = _context.Ambientes.Include(a => a.Dispositivos_Ambiente).Include(a => a.Usuario).Include(a => a.Usuario.Plano_Usuario).Where(_ => _.Nome_Ambiente.Equals(nome_ambiente)).FirstOrDefault();

            if (ambiente == null)
            {
                return Json(data: "Ambiente não encontrado.");
            }

            if (ambiente.Dispositivos_Ambiente.Count() >= ambiente.Usuario.Plano_Usuario.Qtde_Max_Dispositivos_Plano)
            {
                return Json(data: $"O ambiente permite no máximo até {  ambiente.Usuario.Plano_Usuario.Qtde_Max_Dispositivos_Plano } disposivitos.");
            }

            return Json(data: true);
        }

        // POST: Dispositivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Dispositivo,Nome_Dispositivo,Status_Dispositivo,nome_ambiente")] DispositivoDTO dispositivo)
        {
            if (ModelState.IsValid)
            {
                Ambiente ambiente = _context.Ambientes.Include(a => a.Usuario).Include(a => a.Usuario.Plano_Usuario).Where(_ => _.Nome_Ambiente.Equals(dispositivo.nome_ambiente)).FirstOrDefault();

                //Cadastrando Dispositivo.
                dispositivo.Data_Cadastro_Dispositivo = DateTime.Now;
                dispositivo.Ambiente = ambiente;
                var dispositivoFinal = _mapper.Map(dispositivo, new Dispositivo());
                _context.Add(dispositivoFinal);
                await _context.SaveChangesAsync();

                if (ambiente != null)
                {
                    //Atualizando quantidade dispositivos no ambiente.
                    ambiente.Qtda_Dispositivo_Ambiente++;
                    ambiente.Dispositivos_Ambiente.Add(dispositivoFinal);
                    _context.Update(ambiente);
                    _context.SaveChanges();

                }

                return RedirectToAction(nameof(Index));
            }
            return View(dispositivo);
        }

        // GET: Dispositivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispositivo = _context.Dispositivos.Include(d => d.Ambiente).FirstOrDefault(a => a.Id_Dispositivo == id);
            var dispositivoDTO = _mapper.Map(dispositivo, new DispositivoDTO());
            dispositivoDTO.nome_ambiente = dispositivo.Ambiente.Nome_Ambiente;
            if (dispositivo == null)
            {
                return NotFound();
            }
            return View(dispositivoDTO);
        }

        // POST: Dispositivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Dispositivo,Nome_Dispositivo,Status_Dispositivo,nome_ambiente")] DispositivoDTO dispositivo)
        {
            if (id != dispositivo.Id_Dispositivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Ambiente ambiente = _context.Ambientes.Include(a => a.Usuario).Include(a => a.Usuario.Plano_Usuario).Where(_ => _.Nome_Ambiente.Equals(dispositivo.nome_ambiente)).FirstOrDefault();
                    dispositivo.Ambiente = ambiente;

                    dispositivo.Data_Cadastro_Dispositivo = DateTime.Now;
                    var dispositivoFinal = _mapper.Map(dispositivo, new Dispositivo());

                    _context.Update(dispositivoFinal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispositivoExists(dispositivo.Id_Dispositivo))
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
            return View(dispositivo);
        }

        // GET: Dispositivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivos
                .FirstOrDefaultAsync(m => m.Id_Dispositivo == id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        // POST: Dispositivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Dispositivo dispositivo = _context.Dispositivos.Where(_ => _.Id_Dispositivo == id).Include(_ => _.Ambiente).FirstOrDefault();

            Ambiente ambiente = dispositivo.Ambiente;

            if (ambiente != null)
            {
                // Remove a Quantidade de dispositivos no ambiente.
                ambiente.Qtda_Dispositivo_Ambiente--;
                _context.Ambientes.Update(ambiente);
                _context.SaveChanges();
            }

            // Remove dispositivo.
            _context.Dispositivos.Remove(dispositivo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool DispositivoExists(int id)
        {
            return _context.Dispositivos.Any(e => e.Id_Dispositivo == id);
        }
    }
}
