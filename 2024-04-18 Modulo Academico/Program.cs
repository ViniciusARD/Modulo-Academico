using System;
using System.Data;
using _2024_03_21_ModuloAcademico;
using MySql.Data.MySqlClient;

class Program
{


    public static void Main(string[] args)
    {
        string opcao = "";

        do
        {
            // Mostra o menu principal e obtém a opção escolhida pelo usuário
            opcao = Singleton.GetInstance().ShowMenu("Menu", null);

            if (opcao == "0")
                break;

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    {
                        Biblioteca biblioteca = new Biblioteca(); // Caso a opção seja "1", cria uma instância da classe Biblioteca
                        string opcaoBiblioteca = Singleton.GetInstance().ShowMenu("Biblioteca", biblioteca); // Exibe o menu da biblioteca e obtém a opção escolhida pelo usuário

                        break;
                    }

                case "2":
                    {
                        Secretaria secretaria = new Secretaria(); // Caso a opção seja "2", cria uma instância da classe Secretaria
                        string opcaoSecretaria = Singleton.GetInstance().ShowMenu("Secretaria", secretaria); // Exibe o menu da secretaria e obtém a opção escolhida pelo usuário

                        break;
                    }

                default:
                    {
                        Console.WriteLine("Opção inválida no menu principal!");
                        break;
                    }
            }
        } while (opcao != "0");
    }
}
