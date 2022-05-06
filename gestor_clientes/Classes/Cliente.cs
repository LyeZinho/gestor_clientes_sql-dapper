using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_clientes.Classes
{
    public class Cliente
    {
        public int idcliente { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public int telefone { get; set; }
        public int nif { get; set; }

        public Cliente()
        {
            idcliente = 0;
            nome = "";
            email = "";
            telefone = 0;
            nif = 0;
        }

        public Cliente(int idcliente, string nome, string email, int telefone, int nif)
        {
            this.idcliente = idcliente;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.nif = nif;
        }
    }

    public class Compra : Cliente
    {
        public int idcompra { get; set; }
        public int idproduto { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }

        Compra()
        {
            idcompra = 0;
            idcliente = 0;
            idproduto = 0;
            quantidade = 0;
            preco = 0;
        }

        Compra(int idcompra, int idcliente, int idproduto, int quantidade, double preco)
        {
            this.idcompra = idcompra;
            this.idcliente = idcliente;
            this.idproduto = idproduto;
            this.quantidade = quantidade;
            this.preco = preco;
        }
    }
}


