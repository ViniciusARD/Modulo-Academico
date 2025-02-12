using _2024_03_21_ModuloAcademico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_04_04
{
    public abstract class MenuTemplate
    {
        // Método principal que executa o menu
        public void Run(string key)
        {
            this.LimparTela();
            this.ExecutarAcoes(key);
        }

        // Método para limpar a tela
        public void LimparTela()
        {
            Console.Clear();
        }

        // Método abstrato para executar as ações específicas do menu
        public abstract void ExecutarAcoes(string key);

    }
 
}

