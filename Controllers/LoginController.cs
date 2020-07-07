using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrabalhoLp4.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar ([FromBody] Dictionary<string, string> dados)
        {
            string nome = dados["email"];
            string senha = dados["senha"];
            
            CamadaNegocio.LoginCamadaNegocio loginCN = new CamadaNegocio.LoginCamadaNegocio();

            if(loginCN.Validar(nome, senha))
            {
                return Json(new {
                    operacao = true,
                    msg = "Usuário Logado com Sucesso!"
                });
            }
            else
            {
                return Json(new
                {
                    operacao = false,
                    msg = "Dados inválidos!"
                });
            }

        }
    }
}