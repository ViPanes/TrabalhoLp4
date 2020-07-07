using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoLp4.CamadaNegocio
{
    public class CadastrarHamburgerCamadaNegocio
    {


        public (bool, string) inserir(Models.Hamburger hamb)
        {
            string msg = "";
            bool x = false;
            CamadaAcessoDados.HamburgerBD hambBD = new CamadaAcessoDados.HamburgerBD();

            if (hamb.Descricao.ToString().Length < 6)
            {
                msg = "Descrição muito pequena!";
            }
            else
            if (hamb.Preco < 0)
            {
                msg = "Preço inválido!";
            }
            else
            if (hambBD.Pesquisar_Nome(hamb.Nome).Count != 0)
            {
                msg = "Nome já existe!";
            }
            else
            {
                x = hambBD.Criar(hamb);              
                msg = "Cadastro feito com sucesso!";
            }

            return (x, msg);
        }

        public List<string> obterCategoria()
        {
            List<string> lista = new List<string>();
            lista.Add("Vegetariano");
            lista.Add("Artesanal");
            lista.Add("Gourmet");
            lista.Add("Tradicional");
            return lista;
        }

        public List<Models.Hamburger> obterHamburgers()
        {
            List<Models.Hamburger> hamb = new List<Models.Hamburger>();
            CamadaAcessoDados.HamburgerBD hambBD = new CamadaAcessoDados.HamburgerBD();
            hamb = hambBD.Obter_Todos();
            return hamb;
        }

        public List<Models.Hamburger> obterHamburgers_Categoria(string categoria)
        {
            List<Models.Hamburger> hamb = new List<Models.Hamburger>();
            CamadaAcessoDados.HamburgerBD hambBD = new CamadaAcessoDados.HamburgerBD();
            hamb = hambBD.Obter_Categoria(categoria);
            return hamb;
        }

        public (bool, string) IncluirFoto(int id, byte[] foto)
        {
            string msg = "";
            bool operacao = false;

            {
                CamadaAcessoDados.HamburgerBD ubd = new CamadaAcessoDados.HamburgerBD();
                operacao = ubd.IncluirFoto(id, foto);
            }
            return (operacao, msg);
        }

        public byte[] ObterFoto(int id)
        {
            CamadaAcessoDados.HamburgerBD ubd = new CamadaAcessoDados.HamburgerBD();
            return ubd.ObterFoto(id);
        }


    }
}
