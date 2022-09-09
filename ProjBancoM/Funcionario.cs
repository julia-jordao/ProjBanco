using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Funcionario : Pessoa
    {
        public int NumeroRegistro { get; set; }

        public Funcionario(string nome, int numeroRegistro) : base(nome)
        {
            NumeroRegistro = numeroRegistro;
        }

    }
}