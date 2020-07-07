using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoLp4.CamadaNegocio
{
    public class LoginCamadaNegocio
    {
        public (bool, string) InserirCriar(Models.User usuario)
        {
            string msg = "";
            bool operacao = false;

            if (usuario.Senha.ToString().Length < 6)
                msg = "Senha muito pequena.";
            else
            {
                CamadaAcessoDados.UserBD ubd = new CamadaAcessoDados.UserBD();
                operacao = ubd.Criar(usuario);
            }
            return (operacao, msg);
        }

        public bool Validar(string userName, string senha)
        {
            CamadaAcessoDados.UserBD usuario = new CamadaAcessoDados.UserBD();
            return usuario.Validar(userName, senha);
        }

        public Models.User Pesquisar_Id(int id)
        {
            CamadaAcessoDados.UserBD usuBD = new CamadaAcessoDados.UserBD();
            return usuBD.Pesquisar_Id(id);
        }

        public List<Models.User> Pesquisar_Nome(string nome)
        {
            CamadaAcessoDados.UserBD usuBD = new CamadaAcessoDados.UserBD();
            nome = nome.ToLower();
            if (nome.Length > 3)
                return usuBD.Pesquisar_Nome(nome);
            else
                return new List<Models.User>();
        }

        public bool Excluir(int id)
        {
            CamadaAcessoDados.UserBD usuBD = new CamadaAcessoDados.UserBD();
            return usuBD.Excluir(id);
        }
    }
}
