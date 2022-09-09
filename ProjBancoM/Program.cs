using ProjBancoM;
using ProjBancoMorangao;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjBancoMorangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;
            Cabecario();
            string typeAccount;
            bool saida = true;

            List<string> listaExtratoCorrente = new List<string>();
            List<string> listaExtratoPoupanca = new List<string>();
            List<Cliente> listaClientes = new List<Cliente>();

            Cliente PrimeiroCliente = new Cliente();
            Endereco PrimeiroEndereco = new Endereco();
            Cliente ClienteBanco = new Cliente();
            Gerente gerente = new Gerente("Pestana", 9203745);
            AgenteBancario agente = new AgenteBancario("Papini", 387423);
            ContaPoupanca contaPoupanca = new ContaPoupanca();
            Conta conta = new Conta();
            CartaoDeCredito cartaoCredito = new CartaoDeCredito();

            static void Cabecario()
            {
                string textToEnter = "BIG STRAWBERRY BANK";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
                Console.WriteLine("");
            }

            Console.WriteLine("\n\nSeja bem-vindo ao Big Strawberry Bank\n");
            while (escolha != 1 && escolha != 2 && escolha != 3)
            {
                Console.WriteLine("MENU DE OPÇÕES: \n01. Já sou cliente \n02. Desejo fazer um cadastro \n03. Finalizar programa");
                escolha = int.Parse(Console.ReadLine());
                Console.Clear();
                Cabecario();
                if (escolha == 1)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Informe seu CPF: ");
                        string documentoValidacao = Console.ReadLine();
                        Cliente buscaCliente = null;
                        foreach (Cliente cliente in listaClientes)
                        {
                            if (documentoValidacao == cliente.Cpf)
                            {
                                buscaCliente = cliente;
                            }
                        }
                        if (buscaCliente == null)
                        {
                            Console.WriteLine("A conta não foi encontrada");
                            escolha = 4;
                            break;
                        }
                    } while (true);
                }
                else if (escolha == 2)
                {
                    Console.WriteLine("\nSiga o passo-a-passo para se cadastrar em nosso banco: ");
                    Console.WriteLine("");
                    Console.WriteLine("***ATENÇÃO***\nO cadastro é uma avaliação do seu perfil! A criação de uma conta fica a critério de seu interesse.");
                    Console.WriteLine("Aperte ENTER para inicar o cadastro...");
                    Console.ReadKey();
                    Console.Clear();

                    Cabecario();

                    PrimeiroCliente = PrimeiroCliente.CadastrarCliente();
                    Console.WriteLine(PrimeiroCliente.ToString());
                    Console.Clear();

                    Cabecario();
                    Console.WriteLine("O Senhor(a) " + PrimeiroCliente.Nome.ToUpper() + " gostaria de solicitar uma conta bancária em nossa agência?\n01. Sim\n02. Não");
                    int escolhaConta = int.Parse(Console.ReadLine());
                    if (escolhaConta == 1)
                    {
                        Console.WriteLine("\nSolicitação de abertura de conta foi encaminhada!");
                        Console.WriteLine("Por favor, aguarde a autorização...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Cabecario();
                        ClienteBanco.FaixaSalarial = PrimeiroCliente.SolicitarAberturaConta(gerente);
                        PrimeiroCliente.SolicitarTipoConta();
                        string tipoConta = agente.AvaliarTipoConta(ClienteBanco.FaixaSalarial);

                        bool verificarAutorizacao = gerente.AutorizarAberturaConta(ClienteBanco.FaixaSalarial);

                        //MENU CONTA CORRENTE
                        if (verificarAutorizacao == true)
                        {
                            double LimiteCartao = (ClienteBanco.FaixaSalarial * 2);
                            double LimiteChequeEspecial = (ClienteBanco.FaixaSalarial / 4);
                            do
                            {
                                Console.Clear();
                                Cabecario();
                                Console.WriteLine("Olá, " + ClienteBanco + "!");
                                Console.WriteLine("Número da conta: " + ClienteBanco.Telefone * 2);
                                Console.WriteLine("Conta do tipo: " + tipoConta);
                                Console.WriteLine("\nMenu de ações: \n01. Consultar saldo\n02. Saque\n03. Depósito\n04. Consultar extrato\n05. Acessar Cartão de Crédito\n06. Acessar Conta Poupança\n07. Voltar ao menu inicial.");
                                int escolhaAcao = int.Parse(Console.ReadLine());
                                if (escolhaAcao == 1) //SALDO
                                {
                                    Console.Clear();
                                    ClienteBanco.conta.ConsultarSaldo(ClienteBanco.conta.SaldoContaCorrente, ClienteBanco.Nome, ClienteBanco.conta.ValorChequeEspecial);
                                }
                                else if (escolhaAcao == 2) //SAQUE
                                {
                                    Console.Clear();
                                    Console.WriteLine("Opção >Saque< selecionado: \nVALOR DO SAQUE: ");
                                    float valorSaque = float.Parse(Console.ReadLine());
                                    conta.SaldoContaCorrente = conta.Saque(conta.SaldoContaCorrente, valorSaque);
                                    listaExtratoCorrente.Add("Saque de R$" + valorSaque + " realizado!");
                                }
                                else if (escolhaAcao == 3) //DEPOSITO
                                {
                                    Console.Clear();
                                    Console.WriteLine("Opção >Depósito< selecionado: \nVALOR DO DEPÓSITO: ");
                                    float valorDeposito = float.Parse(Console.ReadLine());
                                    conta.SaldoContaCorrente = conta.Depositar(conta.SaldoContaCorrente, valorDeposito);
                                    listaExtratoCorrente.Add("Depósito de R$" + valorDeposito + " realizado!");
                                }
                                else if (escolhaAcao == 4) //EXTRATO CC
                                {
                                    Console.Clear();
                                    Console.WriteLine("Opção >Consultar Extrato< selecionado: ");
                                    Console.WriteLine("As movimentações realizadas na conta:");
                                    listaExtratoCorrente.ForEach(i => Console.WriteLine(i));
                                }
                                else if (escolhaAcao == 5) //CARTAO DE CREDITO
                                {
                                }
                                else if (escolhaAcao == 6) //ACESSO CP
                                {
                                    MenuPoupanca(contaPoupanca.SaldoContaPoupanca, ClienteBanco, contaPoupanca, conta, listaExtratoPoupanca);
                                }
                                else if (escolhaAcao == 7)
                                {
                                    Console.WriteLine("Você escolheu a opção: Voltar ao menu inicial;");
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    Thread.Sleep(2000);
                                    escolha = 4;
                                    saida = false;
                                }
                            } while (saida == true);
                        }
                    }
                    else if (escolhaConta == 2)
                    {
                        Console.WriteLine("Ok!! Vamos voltar ao menu inicial");
                        escolha = 4;
                    }
                }
                else if (escolha == 3)
                {
                    Console.WriteLine("Agradecemos a preferência, volte sempre!");
                }
                else
                {
                    Console.WriteLine("Opção inesxistente!");
                }

                //MENU POUPANÇA
                static void MenuPoupanca(float saldoPoupanca, Cliente PrimeiroCliente, ContaPoupanca contaPoupanca, Conta conta, List<string> listaExtratoPoupanca)
                {
                    bool SaidaMenu = true;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Saldo atual: " + contaPoupanca.SaldoContaPoupanca);
                        Console.WriteLine("Número da Conta Poupança: " + (PrimeiroCliente.FaixaSalarial * 2));
                        Console.WriteLine("Operações possíveis: \n1. Resgatar valor (enviar para Conta Corrente)\n2. Consultar extrato \n3. Saque \n4. Depósito \n5. Menu principal");
                        int escolhaAcao = int.Parse(Console.ReadLine());
                        if (escolhaAcao == 1) //RESGATE
                        {
                            Console.Clear();
                            Console.WriteLine("Voce escolheu a opção: Resgatar valor.");
                            Console.WriteLine("Digite um valor à ser resgatado para sua Conta Corrente: ");
                            float valoResgate = float.Parse(Console.ReadLine());
                            contaPoupanca.SaldoContaPoupanca = contaPoupanca.ResgatarPoupanca(contaPoupanca.SaldoContaPoupanca, valoResgate);
                            conta.SaldoContaCorrente = conta.SaldoContaCorrente + valoResgate;
                            listaExtratoPoupanca.Add("Resgate de " + valoResgate + " Realizado");
                        }
                        else if (escolhaAcao == 2) //EXTRATO
                        {
                            conta.ConsultarExtrato(listaExtratoPoupanca);
                        }
                        else if (escolhaAcao == 3) //SAQUE
                        {
                            Console.Clear();
                            Console.WriteLine("Voce escolheu a opção: Saque.");
                            Console.WriteLine("Informe o valor que deseja retirar: ");
                            float valorSaque = float.Parse(Console.ReadLine());
                            if (contaPoupanca.SaldoContaPoupanca - valorSaque <= 0)
                            {
                                Console.WriteLine("Impossivel realizar tal operação, saldo insuficiente");
                            }
                            else
                            {
                                contaPoupanca.SaldoContaPoupanca = contaPoupanca.Saque(contaPoupanca.SaldoContaPoupanca, valorSaque);
                                listaExtratoPoupanca.Add("Saque de " + valorSaque + " Realizado");
                            }
                        }
                        else if (escolhaAcao == 4) //DEPOSITO 
                        {
                            Console.Clear();
                            Console.WriteLine("Voce escolheu a opção: Deposito.");
                            Console.Write("Insira o valor que deseja depositar: ");
                            float valorDeposito = float.Parse(Console.ReadLine());
                            contaPoupanca.SaldoContaPoupanca = contaPoupanca.Depositar(contaPoupanca.SaldoContaPoupanca, valorDeposito);
                            listaExtratoPoupanca.Add("Deposito de " + valorDeposito + " Realizado.");
                        }
                        else if (escolhaAcao == 5) //MENU PRINCIPAL
                        {
                            Console.Clear();
                            Console.WriteLine("Opcão Menu Principal selecionada!");
                            Thread.Sleep(2000);
                            SaidaMenu = false;
                        }
                    } while (SaidaMenu == true);
                }
            }
        }
    }
}
