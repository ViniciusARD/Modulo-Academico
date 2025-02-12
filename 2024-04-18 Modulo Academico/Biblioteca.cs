using _2024_04_04;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_03_21_ModuloAcademico
{
    internal class Biblioteca : MenuTemplate
    {
        Repositorio repositorio = new Repositorio(); // Cria uma instância da classe Repositorio para interagir com o banco de dados

        public override void ExecutarAcoes(string opcao) // Implementação do método abstrato ExecutarAcoes da classe MenuTemplate
        {
            switch (opcao)
            {
                case "1":
                    {
                        insertLivro();
                        break;
                    }
                case "2": 
                    {
                        updateLivro();
                        break;
                    }
                case "3": 
                    {
                        deleteLivro();
                        break;
                    }
                case "4": 
                    {
                        readLivro();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção inválida na biblioteca!!");
                        break;
                    }
            }
        }

        private void insertLivro()
        {
            repositorio.con.Open();

            Livro l = new Livro();
            Console.WriteLine("+--------------------- LIVRO  ------------------+    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("¦       Forneca os dados do Livro:              ¦    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("+-----------------------------------------------+    ");

            Console.WriteLine("ISBN: ");
            l.SetISBN(Console.ReadLine().ToString());

            Console.WriteLine("Titulo: ");
            l.SetTitulo(Console.ReadLine().ToString());

            Console.WriteLine("Autor: ");
            l.SetAutor(Console.ReadLine().ToString());

            Console.WriteLine("Ano: ");
            l.SetAno(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Genero: ");
            l.SetGenero(Console.ReadLine().ToString());

            Console.WriteLine("Edicao: ");
            l.SetEdicao(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Quantidade: ");
            l.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

            string sql = $"INSERT INTO LIVRO (isbn, titulo, autor, ano, genero, edicao, quantidade) VALUES ('{l.GetISBN()}', '{l.GetTitulo()}', '{l.GetAutor()}', {l.GetAno()}, '{l.GetGenero()}', {l.GetEdicao()}, {l.GetQuantidade()});";

            repositorio.executeScript(sql);
            repositorio.con.Close();
        }

        private void updateLivro()
        {
            repositorio.con.Open();

            Livro l = new Livro();
            Console.WriteLine("+------------------------- LIVRO  --------------+    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("¦    Forneca os dados atualizados do Livro:     ¦    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("+-----------------------------------------------+    ");

            Console.WriteLine("ISBN: ");
            l.SetISBN(Console.ReadLine().ToString());

            Console.WriteLine("Titulo: ");
            l.SetTitulo(Console.ReadLine().ToString());

            Console.WriteLine("Autor: ");
            l.SetAutor(Console.ReadLine().ToString());

            Console.WriteLine("Ano: ");
            l.SetAno(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Genero: ");
            l.SetGenero(Console.ReadLine().ToString());

            Console.WriteLine("Edicao: ");
            l.SetEdicao(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Quantidade: ");
            l.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

            string sql = $"UPDATE LIVRO SET titulo = '{l.GetTitulo()}', autor = '{l.GetAutor()}', ano = {l.GetAno()}, genero = '{l.GetGenero()}', edicao = {l.GetEdicao()}, quantidade = {l.GetQuantidade()} WHERE isbn =  '{l.GetISBN()}' ";

            repositorio.executeScript(sql);
            repositorio.con.Close();
        }

        private void deleteLivro()
        {
            repositorio.con.Open();

            Console.WriteLine("+------------------------- REMOVER LIVRO ---------------+");
            Console.WriteLine("¦                                                       ¦");
            Console.WriteLine("¦   Forneca o ISBN do livro que deseja remover:         ¦");
            Console.WriteLine("¦                                                       ¦");
            Console.WriteLine("+-------------------------------------------------------+");

            Console.WriteLine("ISBM:");
            string isbnToRemove = Console.ReadLine().ToString();

            string sql = $"DELETE FROM LIVRO WHERE isbn = '{isbnToRemove}'";

            repositorio.executeScript(sql);
            repositorio.con.Close();

            Console.WriteLine("Livro removido com sucesso!");
        }

        private void readLivro()
        {
            Console.WriteLine("+------------------------- CONSULTAR LIVRO ---------------+");
            Console.WriteLine("¦                                                         ¦");
            Console.WriteLine("¦   Forneca o ISBN do livro que deseja consultar:         ¦");
            Console.WriteLine("¦                                                         ¦");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("ISBN:");

            string isbnToConsult = Console.ReadLine();

            string sql = $"SELECT * FROM LIVRO WHERE isbn = '{isbnToConsult}'";

            try
            {
                repositorio.con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, repositorio.con))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"\nISBN: {reader["isbn"]}");
                        Console.WriteLine($"Título: {reader["titulo"]}");
                        Console.WriteLine($"Autor: {reader["autor"]}");
                        Console.WriteLine($"Ano: {reader["ano"]}");
                        Console.WriteLine($"Gênero: {reader["genero"]}");
                        Console.WriteLine($"Edição: {reader["edicao"]}");
                        Console.WriteLine($"Quantidade: {reader["quantidade"]}");
                    }
                    else
                    {
                        Console.WriteLine("Livro não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao consultar o banco de dados: {ex.Message}");
            }
            finally
            {
                repositorio.con.Close();
            }
        }
    }
}
