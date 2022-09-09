using ProjBancoM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class ContaPoupanca : Conta
    {
        public String Numero { get; set; }
        public float SaldoContaPoupanca { get; set; }

        public ContaPoupanca()
        {

        }

        public float ResgatarPoupanca(float saldoPoupanca, float valorResgate)
        {
            float ResultadoPoupanca = saldoPoupanca - valorResgate;
            Console.WriteLine("Operação de resgate sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("Operação realizada com sucesso!");
            return ResultadoPoupanca;
        }
    }
}
