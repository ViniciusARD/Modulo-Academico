using _2024_04_04;
using _2024_04_14_Modulo_Academico___Command;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_03_21_ModuloAcademico
{
    public class Secretaria : MenuTemplate
    {
        
        private CommandInvoker invoker; // Invocador de comandos
        private Repositorio repositorio; // Instância da classe Repositorio para interagir com o banco de dados

        // Construtor da classe Secretaria
        public Secretaria()
        {
            repositorio = new Repositorio(); // Inicializa a instância da classe Repositorio
            invoker = new CommandInvoker(); // Inicializa a instância do invocador de comandos
        }
  
        public override void ExecutarAcoes(string opcao) // Implementação do método abstrato ExecutarAcoes da classe MenuTemplate
        {
            switch (opcao)
            {
                case "1":
                    {
                        ICommand command = new InsertAlunoCommand(); // Cria um comando para inserir um aluno e o executa
                        invoker.ExecuteCommand(command, this); // Executa o comando passando a instância da Secretaria como parâmetro
                        break;
                    }
                case "2":
                    {
                        ICommand command = new UpdateAlunoCommand();
                        invoker.ExecuteCommand(command, this);
                        break;
                    }
                case "3":
                    {
                        ICommand command = new DeleteAlunoCommand();
                        invoker.ExecuteCommand(command, this);
                        break;
                    }
                case "4":
                    {
                        ICommand command = new ReadAlunoCommand();
                        invoker.ExecuteCommand(command, this);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opção inválida na secretaria!!");
                        break;
                    }
            }
        }

        public void insertAluno()
        {
            repositorio.con.Open();

            Aluno a = new Aluno();
            Console.WriteLine("+------------------------- ALUNO ---------------------+");
            Console.WriteLine("¦                                                     ¦");
            Console.WriteLine("¦     Forneca os dados do Aluno:                      ¦");
            Console.WriteLine("¦                                                     ¦");
            Console.WriteLine("+-----------------------------------------------------+");

            Console.WriteLine("Nome: ");
            a.SetNome(Console.ReadLine().ToString());

            Console.WriteLine("RGM: ");
            a.SetRgm(Console.ReadLine().ToString());

            Console.WriteLine("Data de Nascimento (YYYY-MM-DD): ");
            a.SetDataNascimento(DateTime.Parse(Console.ReadLine()));

            Console.WriteLine("Curso: ");
            a.SetCurso(Console.ReadLine().ToString());

            Console.WriteLine("Bolsista (1 - Sim, 0 - Não): ");
            a.SetBolsista(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("RG: ");
            a.SetRg(Console.ReadLine().ToString());

            Console.WriteLine("Gênero: ");
            a.SetGenero(Console.ReadLine().ToString());

            string sql = $"INSERT INTO ALUNO (nome, rgm, datanasc, curso, bolsista, rg, genero) VALUES ('{a.GetNome()}', '{a.GetRgm()}', '{a.GetDataNascimento().ToString("yyyy-MM-dd")}', '{a.GetCurso()}', {a.GetBolsista()}, '{a.GetRg()}', '{a.GetGenero()}');";

            repositorio.executeScript(sql);
            repositorio.con.Close();
        }

        public void updateAluno()
        {
            repositorio.con.Open();

            Aluno a = new Aluno();
            Console.WriteLine("+------------------------- ALUNO ---------------------+");
            Console.WriteLine("¦                                                     ¦");
            Console.WriteLine("¦   Forneca os dados atualizados do Aluno:            ¦");
            Console.WriteLine("¦                                                     ¦");
            Console.WriteLine("+-----------------------------------------------------+");

            Console.WriteLine("ID do Aluno: ");
            a.SetId(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Nome: ");
            a.SetNome(Console.ReadLine().ToString());

            Console.WriteLine("RGM: ");
            a.SetRgm(Console.ReadLine().ToString());

            Console.WriteLine("Data de Nascimento (YYYY-MM-DD): ");
            a.SetDataNascimento(DateTime.Parse(Console.ReadLine()));

            Console.WriteLine("Curso: ");
            a.SetCurso(Console.ReadLine().ToString());

            Console.WriteLine("Bolsista (1 - Sim, 0 - Não): ");
            a.SetBolsista(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("RG: ");
            a.SetRg(Console.ReadLine().ToString());

            Console.WriteLine("Gênero: ");
            a.SetGenero(Console.ReadLine().ToString());

            string sql = $"UPDATE ALUNO SET nome = '{a.GetNome()}', rgm = '{a.GetRgm()}', datanasc = '{a.GetDataNascimento().ToString("yyyy-MM-dd")}', curso = '{a.GetCurso()}', bolsista = {a.GetBolsista()}, rg = '{a.GetRg()}', genero = '{a.GetGenero()}' WHERE id = {a.GetId()}";

            repositorio.executeScript(sql);
            repositorio.con.Close();
        }

        public void deleteAluno()
        {
            repositorio.con.Open();

            Console.WriteLine("+------------------------- REMOVER ALUNO ---------------+");
            Console.WriteLine("¦                                                       ¦");
            Console.WriteLine("¦   Forneca o ID do aluno que deseja remover:           ¦");
            Console.WriteLine("¦                                                       ¦");
            Console.WriteLine("+-------------------------------------------------------+");

            Console.WriteLine("ID do Aluno:");
            int idToRemove = Convert.ToInt32(Console.ReadLine());

            string sql = $"DELETE FROM ALUNO WHERE id = {idToRemove}";

            repositorio.executeScript(sql);
            repositorio.con.Close();

            Console.WriteLine("Aluno removido com sucesso!");
        }

        public void readAluno()
        {
            Console.WriteLine("+------------------------- CONSULTAR ALUNO ---------------+");
            Console.WriteLine("¦                                                         ¦");
            Console.WriteLine("¦   Forneca o ID do aluno que deseja consultar:           ¦");
            Console.WriteLine("¦                                                         ¦");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("ID do Aluno:");

            int idToConsult = Convert.ToInt32(Console.ReadLine());

            string sql = $"SELECT * FROM ALUNO WHERE id = {idToConsult}";

            try
            {
                repositorio.con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, repositorio.con))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"\nID: {reader["id"]}");
                        Console.WriteLine($"Nome: {reader["nome"]}");
                        Console.WriteLine($"RGM: {reader["rgm"]}");
                        Console.WriteLine($"Data de Nascimento: {reader["datanasc"]}");
                        Console.WriteLine($"Curso: {reader["curso"]}");
                        Console.WriteLine($"Bolsista: {(reader["bolsista"].ToString() == "1" ? "Sim" : "Não")}");
                        Console.WriteLine($"RG: {reader["rg"]}");
                        Console.WriteLine($"Gênero: {reader["genero"]}");
                    }
                    else
                    {
                        Console.WriteLine("Aluno não encontrado.");
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

