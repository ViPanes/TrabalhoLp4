using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoLp4.CamadaAcessoDados
{
    public class UserBD
    {
        MySQLPersistencia _bd = new MySQLPersistencia();

        public bool Criar(Models.User usuario)
        {
            string insert = @"insert into usuario(nome, senha)
                              values(@nome, @senha)";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", usuario.Nome);
            parametros.Add("@senha", usuario.Senha);

            int linhasAfetadas = _bd.ExecutarNonQuery(insert, parametros);
            if (linhasAfetadas > 0)
            {
                usuario.Id = _bd.UltimoId;
            }
            return linhasAfetadas > 0;
        }

        public bool Validar(string usuarioNome, string senha)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nome", usuarioNome);
            parametros.Add("@senha", senha);

            string select = @"select count(*) as conta
                              from usuario 
                              where nome = @nome and 
                                    senha = @senha";

            DataTable dt = _bd.ExecutarSelect(select, parametros);

            int conta = Convert.ToInt32(dt.Rows[0]["conta"]);

            if (conta == 0)
                return false;
            else return true;
        }

        public Models.User Pesquisar_Id(int id)
        {
            Models.User usuario = null;

            string select = @"select * 
                              from usuario 
                              where id = " + id;

            DataTable dt = _bd.ExecutarSelect(select);

            if (dt.Rows.Count == 1)
            {
                usuario = Map(dt.Rows[0]);
            }

            return usuario;
        }

        public List<Models.User> Pesquisar_Nome(string nome)
        {

            List<Models.User> usuarios = new List<Models.User>();

            string select = @"select * 
                              from usuario 
                              where nome like @nome";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", "%" + nome + "%");

            DataTable dt = _bd.ExecutarSelect(select, parametros);

            foreach (DataRow row in dt.Rows)
            {
                usuarios.Add(Map(row));
            }

            return usuarios;

        }

        internal Models.User Map(DataRow row)
        {
            Models.User usuario = new Models.User();
            usuario.Id = Convert.ToInt32(row["id"]);
            usuario.Nome = row["nome"].ToString();
            usuario.Senha = row["senha"].ToString();

            return usuario;
        }

        public bool Excluir(int id)
        {
            string select = @"delete 
                              from usuario 
                              where id = " + id;

            return _bd.ExecutarNonQuery(select) > 0;
        }
    }
}
