using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Cliente : Pessoa
    {
        public double FaixaSalarial { get; set; }

        public Conta conta;

        public Cliente()
        {

        }

        public Cliente CadastrarCliente()
        {
            Cliente cliente = new Cliente();
            Endereco endereco = new Endereco();
            cliente.Endereco = endereco;

            Console.Write("Insira de acordo com o orientado; \nNome: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("CPF (Cadastro de Pessoa Fisica): ");
            cliente.Cpf = (Console.ReadLine());
            Console.Write("Informe seu E-mail: ");
            cliente.Email = Console.ReadLine();
            Console.Write("Informe seu telefone: ");
            cliente.Telefone = long.Parse(Console.ReadLine());
            Console.Write("Informe sua data de nascimento no modelo (dd/mm/aaaa): ");
            cliente.DataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("Informe sua faixa salarial: ");
            cliente.FaixaSalarial = double.Parse(Console.ReadLine());
            Console.Write("");
            Console.WriteLine("Endereço completo: ");
            Console.Write("Informe o número da residência: ");
            cliente.Endereco.Numero = Console.ReadLine();
            Console.Write("Informe a cidade: ");
            cliente.Endereco.Cidade = Console.ReadLine();
            Console.Write("Informe seu estado: ");
            cliente.Endereco.Estado = Console.ReadLine();
            return cliente;
        }

        public override string ToString()
        {
            return "O Cadastro foi efetuado com SUCESSO\n\nConfira alguns dos dados informados para cadastro do cliente " + Nome + ", no caso foram: \nCPF: " + Cpf +
                "\nEmail: " + Email + "\nTelefone: " + Telefone + "\nCidade: " + Endereco;
        }

        public double SolicitarAberturaConta(Gerente conta)
        {
            conta.AutorizarAberturaConta(FaixaSalarial);
            return FaixaSalarial;
        }

        public void SolicitarTipoConta()
        {
            Console.WriteLine("De acordo com sua faixa salarial vamos prosseguir e analisar seu tipo de conta;");
            Console.WriteLine("Pressione enter para iniciar o processo.");
            Console.ReadKey();

        }
    }
}