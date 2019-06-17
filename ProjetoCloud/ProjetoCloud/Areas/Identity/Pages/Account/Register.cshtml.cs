using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProjetoCloud.Areas.Identity.Data;
using ProjetoCloud.Models;
using Microsoft.Extensions.Configuration;


namespace ProjetoCloud.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ProjetoCloudUser> _signInManager;
        private readonly UserManager<ProjetoCloudUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly Contexto _context;


        public RegisterModel(
            UserManager<ProjetoCloudUser> userManager,
            SignInManager<ProjetoCloudUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            Microsoft.Extensions.Configuration.IConfiguration configuration,
            IMapper mapper,
            Contexto context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Digite seu nome")]
            [Required(ErrorMessage = "Digite seu nome.")]
            [StringLength(64, ErrorMessage = "O Nome deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
            public string Nome_Usuario { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Digite seu CPF")]
            [Required(ErrorMessage = "Digite seu CPF.")]
            [StringLength(11, ErrorMessage = "O CPF deve ter {1} caracteres.", MinimumLength = 11)]
            public string CPF_Usuario { get; set; }

            [DataType(DataType.CreditCard)]
            [Display(Name = "Digite seu cartão")]
            [Required(ErrorMessage = "Digite seu cartão.")]
            [StringLength(22, ErrorMessage = "O Cartão deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]         
            public string Cartao_Usuario { get; set; }

            [DataType(DataType.PostalCode)]
            [Display(Name = "Digite seu CEP")]
            [Required(ErrorMessage = "Digite seu CEP.")]
            [StringLength(8, ErrorMessage = "O CEP deve ter entre {2} e {1} caracteres.", MinimumLength = 8)]
            public string CEP_Usuario { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Código de administrador")]
            public string CodigoAdministrador { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                Usuario usuario = _mapper.Map(Input, new Usuario());
                usuario.Data_Cadastro_Usuario = DateTime.UtcNow;
                usuario = _context.Usuarios.Add(usuario).Entity;
                usuario.Adm_Usuario = IsAdmin();
                _context.SaveChanges();
                usuario = _context.Usuarios.Find(usuario.Id_Usuario);

                var user = new ProjetoCloudUser { UserName = Input.Nome_Usuario, Email = Input.Email, UsuarioDeAplicacaoId  = usuario.Id_Usuario };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    usuario.UsuarioDeAutenticacao = user;
                    _context.SaveChanges();
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private bool IsAdmin()
        {
            return !string.IsNullOrWhiteSpace(Input.CodigoAdministrador)
                && Input.CodigoAdministrador == _configuration.GetSection("CodigoAdministrador").Value;

        }
    }
}
