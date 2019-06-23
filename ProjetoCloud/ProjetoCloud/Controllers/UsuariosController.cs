using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Contexto;
using DAL.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCloud.Areas.Identity.Data;
using ProjetoCloud.ViewModels;

namespace ProjetoCloud.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly CloudContexto _context;
        private readonly UserManager<ProjetoCloudUser> _userManager;

        public UsuariosController(CloudContexto context, UserManager<ProjetoCloudUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            if( User.HasClaim(c => c.Value == "Administrator"))
            {
                return View(await _context.Usuarios.Include(i => i.Plano_Usuario).ToListAsync());
            }
            else
            {
                return Unauthorized();
            }
            
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id_Usuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Usuario,Nome_Usuario,CPF_Usuario,Cartao_Usuario,CEP_Usuario,Email_Usuario,Senha_Usuario,Adm_Usuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Data_Cadastro_Usuario = DateTime.Now;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var planos = await _context.Planos.ToListAsync();
            var viewModel = new ViewModelEditarUsuario()
            {
                Usuario = usuario,
                Planos = new SelectList(planos, "Id_Plano", "Nome_Plano"),
                PlanoSelecionado = usuario.Plano_Usuario is null ? 0 : usuario.Plano_Usuario.Id_Plano
            };

            return View(viewModel);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Usuario,Nome_Usuario,CPF_Usuario,Cartao_Usuario,CEP_Usuario,Email_Usuario,Senha_Usuario,Adm_Usuario,Plano_Usuario")] Usuario usuario, bool Admin, int PlanoSelecionado)
        {
                
            if (id != usuario.Id_Usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Data_Cadastro_Usuario = DateTime.Now;
                    
                    if(PlanoSelecionado > 0)
                    {
                        usuario.Plano_Usuario = _context.Planos.Find(PlanoSelecionado);
                    }

                    _context.Update(usuario);
                    await _context.SaveChangesAsync();

                    var searchUser = _userManager.Users.FirstOrDefault(_ => _.UsuarioId == id);

                    if (searchUser != null)
                    {
                        var usuarioClaims = _userManager.GetClaimsAsync(searchUser).Result;

                        if (usuarioClaims != null)
                        {
                            var adminClaim = usuarioClaims.FirstOrDefault(c => c.Value == "Administrator");

                            if(adminClaim is null && Admin)
                            {
                                await _userManager.AddClaimAsync(searchUser, new Claim(ClaimTypes.Role, "Administrator"));
                            }
                            else if(adminClaim != null && !Admin)
                            {
                                await _userManager.RemoveClaimAsync(searchUser, new Claim(ClaimTypes.Role, "Administrator"));
                            }
                            
                        }
                        
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id_Usuario))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id_Usuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();


            var searchUser = _userManager.Users.FirstOrDefault(_ => _.UsuarioId == id);

            if (searchUser != null)
            {
                var usuarioClaims = _userManager.GetClaimsAsync(searchUser).Result;

                if (usuarioClaims != null)
                {
                    var adminClaim = usuarioClaims.FirstOrDefault(c => c.Value == "Administrator");

                    if (adminClaim != null)
                    {
                        await _userManager.RemoveClaimAsync(searchUser, new Claim(ClaimTypes.Role, "Administrator"));
                    }

                    await _userManager.DeleteAsync(searchUser);
                }

            }



            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id_Usuario == id);
        }
    }
}
