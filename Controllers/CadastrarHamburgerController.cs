using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrabalhoLp4.Controllers
{
    public class CadastrarHamburgerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Dictionary<string, string> dados)
        {
            bool operacao = false;
            string nome = dados["nomeProd"];
            string descricao = dados["descricaoProd"];
            float preco = (float) Convert.ToDouble(dados["precoProd"]);
            string categoria = dados["categoriaProd"];    //XXX OLHAR AQUI
            string msg = "";
            Models.Hamburger hamb = new Models.Hamburger(nome, descricao, preco, categoria);


            if ( !float.TryParse(dados["precoProd"], out preco) )
            {
                msg = "Preço Inválido!";
            }
            else
            {
                CamadaNegocio.CadastrarHamburgerCamadaNegocio hamburgerCN = new CamadaNegocio.CadastrarHamburgerCamadaNegocio();
                
                (operacao, msg) = hamburgerCN.inserir(hamb);
            }

            return Json(new
            {
                id = hamb.Id,
                operacao,
                msg
            });
        }

        public IActionResult buscarCategorias()
        {
            CamadaNegocio.CadastrarHamburgerCamadaNegocio hamb = new CamadaNegocio.CadastrarHamburgerCamadaNegocio();
            return Json(hamb.obterCategoria());
        }


        public IActionResult Foto()
        {
            bool operacao = false;
            string msg = "";

            int id = Convert.ToInt32(Request.Form["id"]);

            string nome = Request.Form.Files[0].FileName;

            if (System.IO.Path.GetExtension(nome) != ".jpg")
            {
                msg = "Formato de foto inválido.";
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Request.Form.Files[0].CopyTo(ms);
                byte[] arq = ms.ToArray();

                CamadaNegocio.CadastrarHamburgerCamadaNegocio
                    fto = new CamadaNegocio.CadastrarHamburgerCamadaNegocio();
                (operacao, msg) = fto.IncluirFoto(id, arq);

            }

            return Json(new
            {
                operacao,
                msg
            });
        }

        


    }
}