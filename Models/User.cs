using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoLp4.Models
{
    public class User
    {
        string _nome;
        string _senha;
        int _id;

        public string Nome { get => _nome; set => _nome = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public int Id { get => _id; set => _id = value; }

        public User(string nome, string senha, int id)
        {
            _nome = nome;
            _senha = senha;
            _id = id;
        }

        public User()
        {
            _nome = "";
            _senha = "";
            _id = 0;
        }

    }
}
