using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrabalhoLp4.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult obterHamburgers()
        {
            CamadaNegocio.CadastrarHamburgerCamadaNegocio hamb = new CamadaNegocio.CadastrarHamburgerCamadaNegocio();
            return Json(hamb.obterHamburgers());
        }

        public IActionResult obterHamburgers_Categoria(string categoria)
        {
            CamadaNegocio.CadastrarHamburgerCamadaNegocio hamb = new CamadaNegocio.CadastrarHamburgerCamadaNegocio();

            if (categoria == null)
                return Json(hamb.obterHamburgers());
            else
                return Json(hamb.obterHamburgers_Categoria(categoria));
        }

        public IActionResult buscarCategorias()
        {
            CamadaNegocio.CadastrarHamburgerCamadaNegocio hamb = new CamadaNegocio.CadastrarHamburgerCamadaNegocio();
            return Json(hamb.obterCategoria());
        }

        public IActionResult ObterFoto(int id)
        {
            CamadaNegocio.CadastrarHamburgerCamadaNegocio hambCN = new CamadaNegocio.CadastrarHamburgerCamadaNegocio();

            byte[] foto = hambCN.ObterFoto(id);

            
            MemoryStream ms = new MemoryStream(foto);
            //Image imagem = Image.FromStream(ms);
            //Image c = imagem.byteArrayToImage(foto);

            if (foto == null)
                return File("~/imgs/semfoto.jpg", "image/jpg");
            else
                return File(hambCN.ObterFoto(id), "image/jpg");
        }



    }
}