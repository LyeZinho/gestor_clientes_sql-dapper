using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace gestor_clientes
{

    interface IDbClientes
    {
        public bool NovoUsuario(string nome, string email, int telefone, int nif);

        public bool NovaCompra(int cquantidade, decimal cpreco, int cidcliente);

        public dynamic ComprasCliente(string cnome);

        public dynamic MediaVendas();

        public dynamic TotalCaixa();


    }

    public class DbClientes
    {
        protected string ConnStr()
        {
            string connStr = "server=localhost;database=clientes;userid=root;password=123456789;";
            return connStr;
        }

        public bool NovoUsuario(string nome, string email, int telefone, int nif)
        {
            try
            {
                string procedule = "novo_cliente";
                using (MySqlConnection conn = new MySqlConnection(ConnStr()))
                {
                    var fileiras = conn.Execute(
                    procedule, new
                    {
                        unome = nome,
                        uemail = email,
                        utelefone = telefone,
                        unif = nif
                    }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool NovaCompra(int cquantidade, double cpreco, string cnome)
        {
            try
            {
                string procedule = "nova_compra";
                using (MySqlConnection conn = new MySqlConnection(ConnStr()))
                {
                    var fileiras = conn.Execute(
                    procedule, new
                    {
                        cquantidade = cquantidade,
                        cpreco = cpreco,
                        cnome = cnome
                    }, commandType: CommandType.StoredProcedure);

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public dynamic ComprasCliente(string cnome)
        {
            try
            {
                string procedule = "compras_cliente";
                using (MySqlConnection conn = new MySqlConnection(ConnStr()))
                {
                    dynamic dados = conn.Query(
                        procedule, new
                        {
                            cname = cnome
                        }, commandType: CommandType.StoredProcedure);
                    return dados;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public dynamic MediaVendas()
        {
            try
            {
                string procedule = "med_vendas";
                using (MySqlConnection conn = new MySqlConnection(ConnStr()))
                {
                    dynamic dados = conn.Query<decimal>(
                        procedule, commandType: CommandType.StoredProcedure);
                    return dados;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public dynamic TotalCaixa()
        {
            try
            {
                string procedule = "total_caixa";
                using (MySqlConnection conn = new MySqlConnection(ConnStr()))
                {
                    dynamic dados = conn.Query<decimal>(
                        procedule, commandType: CommandType.StoredProcedure);
                    return dados;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

