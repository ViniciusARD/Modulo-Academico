using _2024_03_21_ModuloAcademico;
using System;

namespace _2024_04_14_Modulo_Academico___Command
{
    // Interface ICommand
    public interface ICommand
    {
        void Execute(Secretaria secretaria);
    }

    // Comandos para operações CRUD de aluno
    public class InsertAlunoCommand : ICommand
    {
        // Implementação do método Execute para inserir um aluno
        public void Execute(Secretaria secretaria)
        {
            secretaria.insertAluno(); // Chama o método insertAluno() da instância da Secretaria
        }
    }

    public class UpdateAlunoCommand : ICommand
    {
        public void Execute(Secretaria secretaria)
        {
            secretaria.updateAluno();
        }
    }

    public class DeleteAlunoCommand : ICommand
    {
        public void Execute(Secretaria secretaria)
        {
            secretaria.deleteAluno();
        }
    }

    public class ReadAlunoCommand : ICommand
    {
        public void Execute(Secretaria secretaria)
        {
            secretaria.readAluno();
        }
    }

    // Invocador de comandos
    public class CommandInvoker
    {
        private ICommand _command;

        // Método para executar o comando definido, recebendo o comando e a instância da Secretaria como parâmetros
        public void ExecuteCommand(ICommand command, Secretaria secretaria)
        {
            _command = command; // Define o comando a ser executado
            _command.Execute(secretaria); // Executa o comando, passando a instância da Secretaria como parâmetro
        }
    }
}
