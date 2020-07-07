using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoLp4.CamadaAcessoDados
{
    public class MySQLPersistencia
    {
        MySqlConnection _con;
        MySqlCommand _cmd;
        int _ultimoId = 0;
        public int UltimoId { get => _ultimoId; set => _ultimoId = value; }

        public MySQLPersistencia()
        {
            string strCon = System.Environment.GetEnvironmentVariable("MYSQLSTRCON");
            _con = new MySqlConnection(strCon);
            _cmd = _con.CreateCommand();
        }


        public void Abrir()
        {
            if (_con.State != System.Data.ConnectionState.Open)
                _con.Open();
        }

        public void Fechar()
        {
            _con.Close();
        }

        public Dictionary<string, object> GerarParametros()
        {
            return new Dictionary<string, object>();
        }

        public Dictionary<string, byte[]> GerarParametrosBinarios()
        {
            return new Dictionary<string, byte[]>();
        }

        public DataTable ExecutarSelect(string select, Dictionary<string, object> parametros = null)
        {
            Abrir();
            _cmd.CommandText = select;
            DataTable dt = new DataTable();

            if (parametros != null)
            {
                foreach (var p in parametros)
                {
                    _cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }

            dt.Load(_cmd.ExecuteReader());

            Fechar();

            return dt;
        }


        //ALTERADO AQUI
        public int ExecutarNonQuery(string sql, Dictionary<string, object> parametros = null, Dictionary<string, byte[]> parametrosBinarios = null)
        {
            Abrir();
            _cmd.Parameters.Clear();
            _cmd.CommandText = sql;

            if (parametros != null)
            {
                foreach (var p in parametros)
                {
                    _cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }

            if (parametrosBinarios != null)
            {
                foreach (var p in parametrosBinarios)
                {
                    _cmd.Parameters.Add(p.Key, MySqlDbType.Blob);
                    _cmd.Parameters[p.Key].Value = p.Value;
                }
            }

            int linhasAfetadas = _cmd.ExecuteNonQuery();
            _ultimoId = (int)_cmd.LastInsertedId;
            Fechar();
            return linhasAfetadas;
        }


        public object ExecutarScalar(string sql, Dictionary<string, object> parametros = null, Dictionary<string, byte[]> parametrosBinarios = null)
        {
            Abrir();
            _cmd.CommandText = sql;

            if (parametros != null)
            {
                foreach (var p in parametros)
                {
                    _cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }
            if (parametrosBinarios != null)
            {
                foreach (var p in parametrosBinarios)
                {
                    _cmd.Parameters.Add(p.Key, MySqlDbType.Blob);
                    _cmd.Parameters[p.Key].Value = p.Value;
                }
            }

            object retorno = _cmd.ExecuteScalar();
            _ultimoId = (int)_cmd.LastInsertedId;

            Fechar();
            return retorno;
        }
    }
}

