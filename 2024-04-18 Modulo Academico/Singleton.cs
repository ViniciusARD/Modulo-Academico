using _2024_03_21_ModuloAcademico;
using _2024_04_04;
using Mysqlx.Prepare;
using System;


public class Singleton
{
    private Singleton() { }
    private static Singleton _instance;
    public static Singleton GetInstance() // Método estático para obter a instância única
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    // Método para exibir menus de opções com base na chave fornecida
    public string ShowMenu(string key, MenuTemplate obj)
    {
        switch (key) {
            case "Menu":
                // Menu principal
                Console.WriteLine("╔════════════════ MENU DE OPÇÕES ═════════════════╗");
                Console.WriteLine("║ 1 - BIBLIOTECA                                  ║");
                Console.WriteLine("║ 2 - SECRETARIA                                  ║");
                Console.WriteLine("║═════════════════════════════════════════════════║");
                Console.WriteLine("║ 0 - SAIR                                        ║");
                Console.WriteLine("╚═════════════════════════════════════════════════╝");
                
                break;
            case "Biblioteca":
                // Menu da biblioteca
                Console.WriteLine("╔══════════════ MENU DA BIBLIOTECA ═════════════╗    ");
                Console.WriteLine("║ 1 INCLUIR - LIVRO                             ║    ");
                Console.WriteLine("║ 2 ATUALIZAR - LIVRO                           ║    ");
                Console.WriteLine("║ 3 REMOVER - LIVRO                             ║    ");
                Console.WriteLine("║ 4 CONSULTAR - LIVRO                           ║    ");
                Console.WriteLine("║═══════════════════════════════════════════════║    ");
                Console.WriteLine("║ 0 SAIR                                        ║    ");
                Console.WriteLine("╚═══════════════════════════════════════════════╝    ");
                Console.WriteLine(" ");
                
                break;
            case "Secretaria":
                // Menu da secretaria
                Console.WriteLine("╔══════════════ MENU DA SECRETARIA ═════════════╗    ");
                Console.WriteLine("║ 1 INCLUIR - ALUNO                             ║    ");
                Console.WriteLine("║ 2 ATUALIZAR - ALUNO                           ║    ");
                Console.WriteLine("║ 3 REMOVER - ALUNO                             ║    ");
                Console.WriteLine("║ 4 CONSULTAR - ALUNO                           ║    ");
                Console.WriteLine("║═══════════════════════════════════════════════║    ");
                Console.WriteLine("║ 0 SAIR                                        ║    ");
                Console.WriteLine("╚═══════════════════════════════════════════════╝    ");
                Console.WriteLine(" ");
                
                break;
            default:
                return "Chave inválida.";
        }

        // Solicita uma opção ao usuário
        Console.Write("DIGITE UMA OPÇÃO : ");
        string opcao = Console.ReadLine();

        // Se um objeto de menu for fornecido, executa a ação correspondente à opção selecionada
        if (obj != null)
        { obj.Run(opcao); }

        return opcao;
    }

    
}

