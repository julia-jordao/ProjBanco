using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Conta
    {
        public int NumeroConta { get; set; }

        public String TipoConta { get; set; }

        public float SaldoContaCorrente { get; set; }

        public float ValorChequeEspecial { get; set; }


        public float Saque(float saldoConta, float valorSaque)
        {
            Console.WriteLine("Operação de saque sendo realizada...");
            Thread.Sleep(2000);
            float resultadoSaque = saldoConta - valorSaque;
            Console.WriteLine("Operação de saque realizada com sucesso!");
            return resultadoSaque;
        }

        public float Depositar(float saldoConta, float valorDeposito)
        {
            Console.WriteLine("Operação de deposito sendo realizada...");
            Thread.Sleep(2000);
            float resultadoDeposito = saldoConta + valorDeposito;
            Console.WriteLine("Operação de deposito realizada com sucesso!");
            return resultadoDeposito;
        }

        public void ConsultarSaldo(float saldo, string nome, float chequeEspecial)
        {
            Console.WriteLine("Voce escolheu a opção: consultar saldo.");
            Console.WriteLine("Consulta de saldo sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("Senhor(a) " + nome + ", no momento seu saldo é de R$" + saldo + ".\nCom Cheque especial de R$" + chequeEspecial);
        }

        public void ConsultarExtrato(List<string> ListaExtratoCorrente)
        {
            Console.Clear();
            Console.WriteLine("Voce escolheu a opção: Consultar Extrato.");
            Console.WriteLine("As movimentações realizadas foram:");
            ListaExtratoCorrente.ForEach(i => Console.WriteLine(i));
        }

        public void VerLimiteChequeEspecial(double salario)
        {
            Console.WriteLine("O limite de cheque especial é definido de acordo com seu salário!");
            Console.WriteLine("De acordo com seu salário R$" + salario);
            Console.WriteLine("Limite de Cheque Especial sendo realizado...");
            Thread.Sleep(2000);
            Console.WriteLine("Seu cheque especial é de R$" + (salario * 0.25));
        }

    }
}