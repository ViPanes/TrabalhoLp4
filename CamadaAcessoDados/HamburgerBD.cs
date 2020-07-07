using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoLp4.CamadaAcessoDados
{
    public class HamburgerBD
    {
        MySQLPersistencia _bd = new MySQLPersistencia();

        public bool Criar(Models.Hamburger hamb)
        {
            string insert = @"insert into hamburger(nome, descricao, preco, categoria)
                              values(@nome, @descricao, @preco, @categoria)";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", hamb.Nome);
            parametros.Add("@descricao", hamb.Descricao);
            parametros.Add("@preco", hamb.Preco);
            parametros.Add("@categoria", hamb.Categoria);


            int linhasAfetadas = _bd.ExecutarNonQuery(insert, parametros);
            if (linhasAfetadas > 0)
            {
                hamb.Id = _bd.UltimoId;
            }
            return linhasAfetadas > 0;
        }

        public Models.Hamburger Pesquisar_Id(int id)
        {
            Models.Hamburger hamb = null;

            string select = @"select * 
                              from hamburger 
                              where id = " + id;

            DataTable dt = _bd.ExecutarSelect(select);

            if (dt.Rows.Count == 1)
            {
                hamb = Map(dt.Rows[0]);
            }

            return hamb;
        }

        public List<Models.Hamburger> Pesquisar_Nome(string nome)
        {

            List<Models.Hamburger> hamb = new List<Models.Hamburger>();

            string select = @"select *  from hamburger 
                              where nome like @nome";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", "%" + nome + "%");

            DataTable dt = _bd.ExecutarSelect(select, parametros);

            foreach (DataRow row in dt.Rows)
            {
                hamb.Add(Map(row));
            }

            return hamb;
        }

        public List<Models.Hamburger> Obter_Todos()
        {

            List<Models.Hamburger> hamb = new List<Models.Hamburger>();

            string select = @"select *  from hamburger";

            DataTable dt = _bd.ExecutarSelect(select);

            foreach (DataRow row in dt.Rows)
            {
                hamb.Add(Map(row));
            }

            return hamb;
        }

        public List<Models.Hamburger> Obter_Categoria(string categoria)
        {

            List<Models.Hamburger> hamb = new List<Models.Hamburger>();

            string select = @"select *  from hamburger  where categoria like @categoria";
            var parametros = _bd.GerarParametros();
            parametros.Add("@categoria", "%" + categoria + "%");

            DataTable dt = _bd.ExecutarSelect(select, parametros);

            foreach (DataRow row in dt.Rows)
            {
                hamb.Add(Map(row));
            }
            return hamb;
        }

        internal Models.Hamburger Map(DataRow row)
        {
            Models.Hamburger hamb = new Models.Hamburger();
            hamb.Id = Convert.ToInt32(row["id"]);
            hamb.Nome = row["nome"].ToString();
            hamb.Descricao = row["descricao"].ToString();
            hamb.Categoria = row["categoria"].ToString();
            hamb.Preco = Convert.ToInt32(row["preco"]);

            return hamb;
        }

        public bool IncluirFoto(int id, byte[] foto)
        {
            string insert = @"update hamburger set foto = @foto 
                              where id = @id";

            var parametros = _bd.GerarParametros();
            parametros.Add("@id", id);

            var parametrosBinarios = _bd.GerarParametrosBinarios();
            parametrosBinarios.Add("@foto", foto);

            int linhasAfetadas = _bd.ExecutarNonQuery(insert, parametros, parametrosBinarios);

            return true;
        }

        public byte[] ObterFoto(int id)
        {
            byte[] retorno = null;

            string select = @"select foto from hamburger 
                              where id = " + id;

            object fotoBd = _bd.ExecutarScalar(select);

            if (fotoBd != DBNull.Value)
            {
                retorno = (byte[])fotoBd;
            }

            return retorno;
        }
    }
}
