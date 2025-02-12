using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_03_21_ModuloAcademico
{
    internal class Repositorio
    {
        // Objeto de conexão com o banco de dados MySQL
        public MySqlConnection con = new MySqlConnection("Persist Security Info=False;server=sql.freedb.tech;database=freedb_DBModuloAcademico;uid=freedb_vinicius;pwd=g*B#hGbUHWS9Dx6");

        // Método para executar scripts SQL que não retornam dados
        public void executeScript(string sql)
        {
            try
            {
                // Abre a conexão com o banco de dados
                con.Open();
                // Exibe a versão do MySQL
                Console.WriteLine($"MySQL version : {con.ServerVersion}");
            }
            catch (System.Exception)
            {
                // Tratamento de exceção, o código dentro deste bloco é executado caso ocorra um erro
            }
            // Verifica se a conexão está aberta
            if (con.State == ConnectionState.Open)
            {
                Console.WriteLine("connection Open!");
                // Cria um novo comando SQL com o script fornecido e a conexão
                using var cmd = new MySqlCommand(sql, con);
                // Executa o script SQL que não retorna dados (como INSERT, UPDATE, DELETE)
                cmd.ExecuteNonQuery();
            }
        }

        // Método para executar consultas SQL que retornam dados
        public void executeQuery(string sql)
        {
            // Cria uma nova conexão
            MySqlConnection con = new MySqlConnection("Persist Security Info=False;server=sql.freedb.tech;database=freedb_DBModuloAcademico;uid=freedb_vinicius;pwd=g*B#hGbUHWS9Dx6");
            try
            {
                // Abre a conexão com o banco de dados
                con.Open();
                // Exibe a versão do MySQL
                Console.WriteLine($"MySQL version : {con.ServerVersion}");
            }
            catch (System.Exception)
            {
                // Tratamento de exceção, o código dentro deste bloco é executado caso ocorra um erro
            }

            // Verifica se a conexão está aberta
            if (con.State == ConnectionState.Open)
            {
                Console.WriteLine("connection Open!");
                // Cria um novo comando SQL com o script fornecido e a conexão
                using var cmd = new MySqlCommand(sql, con);
                // Executa a consulta SQL que retorna dados (como SELECT)
                cmd.ExecuteNonQuery();
            }
        }
    }
}
