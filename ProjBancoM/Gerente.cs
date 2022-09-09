using ProjBancoM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Gerente : Funcionario
    {
        public Gerente(string nome, int numeroRegistro) : base(nome, numeroRegistro)
        {

        }

        public void AutorizarEmprestimo(double salario)
        {
            Console.WriteLine("Autorização de solicitação de empréstimo sendo analisada...\n");
            Thread.Sleep(2000);
            Console.WriteLine("De acordo com seu perfil e faixa salarial o seu empréstimo foi autorizado!");
            Console.WriteLine("O valor do empréstimo será equivalente à seu salário R$" + salario + " x 15. Totalizando R$" + (salario * 15) + ", parcelado em 36 vezes!");
        }
        public bool AutorizarAberturaConta(double salario)
        {
            if (salario < 500)
            {
                Console.WriteLine("Sua faixa salarial não atingiu a renda miníma aceita, a abertura da conta foi negada!");
                return false;
            }
            else
            {
                Console.WriteLine("Sua conta foi aceita e criada com sucesso!\nO número da sua agência é 345.");
                return true;
            }
        }
    }
}