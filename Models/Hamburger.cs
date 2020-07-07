using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoLp4.Models
{
    public class Hamburger
    {
        string _nome;
        string _descricao;
        double _preco;
        string _categoria;
        int _id;

        public string Nome { get => _nome; set => _nome = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public double Preco { get => _preco; set => _preco = value; }
        public string Categoria { get => _categoria; set => _categoria = value; }
        public int Id { get => _id; set => _id = value; }

        public Hamburger(string nome, string descricao, double preco, string categoria)
        {
            _nome = nome;
            _descricao = descricao;
            _preco = preco;
            _categoria = categoria;
        }

        public Hamburger(string nome, string descricao, double preco, string categoria, int id)
        {
            _nome = nome;
            _descricao = descricao;
            _preco = preco;
            _categoria = categoria;
            _id = id;
        }

        public Hamburger()
        {
        }
    }
}
