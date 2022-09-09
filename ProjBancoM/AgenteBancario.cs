using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class AgenteBancario : Funcionario
    {
        public AgenteBancario(string nome, int numeroRegistro) : base(nome, numeroRegistro)
        {
            this.Nome = nome;
            this.NumeroRegistro = numeroRegistro;
        }

        public string AvaliarTipoConta(double salario)
        {
            if (salario > 0 && salario <= 1500)
            {
                Console.WriteLine("\nDe acordo com sua faixa salarial, sua conta foi definida como CONTA UNIVERSITÁRIA");
                Console.WriteLine("Conforme os padrões, seu cheque especial é de R$" + (salario * 0.25) + ", e seu limite no cartão de crédito é de R$" + (salario * 2) + ".");
                return "Universitária";
            }
            else if (salario > 1500 && salario <= 5000)
            {
                Console.WriteLine("De acordo com sua faixa salarial, sua conta foi definida como CONTA NORMAL");
                Console.WriteLine("Conforme os padrões, seu cheque especial é de R$" + (salario * 0.25) + ", e seu limite no cartão de crédito é de R$" + (salario * 2) + ".");
                return "Comum";
            }
            else
            {
                Console.WriteLine("De acordo com sua faixa salarial, sua conta foi definida como CONTA VIP");
                Console.WriteLine("Conforme os padrões, seu cheque especial é de R$" + (salario * 0.25) + ", e seu limite no cartão de crédito é de R$" + (salario * 2) + ".");
                return "VIP";
            }
        }
    }
}
