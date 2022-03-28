using System;

namespace Clube_da_leitura_refatorada.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();
            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            TelaCadastroAmigo telaCadastroAmigo = new TelaCadastroAmigo();

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.caixas = new Caixa[10];
            telaCadastroCaixa.repositorioCaixa = repositorioCaixa;

            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.amigos = new Amigo[10];
            telaCadastroAmigo.repositorioAmigo = repositorioAmigo;


            Notificador notificador = new Notificador();
            telaCadastroCaixa.notificador = notificador;
            telaCadastroAmigo.notificador = notificador;


            RepositorioRevista repositorioRevista = new RepositorioRevista();
            repositorioRevista.revistas = new Revista[10];

            TelaCadastroRevista telaCadastroRevista = new TelaCadastroRevista();
            telaCadastroRevista.notificador = notificador;
            telaCadastroRevista.telaCadastroCaixa = telaCadastroCaixa;
            telaCadastroRevista.repositorioCaixa = repositorioCaixa;
            telaCadastroRevista.repositorioRevista = repositorioRevista;



            while (true)
            {
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1")
                {
                    string opcao = telaCadastroCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroCaixa.InserirNovaCaixa();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroCaixa.EditarCaixa();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroCaixa.ExcluirCaixa();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroCaixa.VisualizarCaixas("Tela");
                        Console.ReadLine();
                    }
                }
                else if (opcaoMenuPrincipal == "2")
                {
                    string opcao = telaCadastroRevista.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroRevista.InserirNovaRevista();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroRevista.EditarRevista();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroRevista.ExcluirRevista();
                    }
                    else if (opcao == "4")
                    {
                        bool temRevistaCadastrada = telaCadastroRevista.VisualizarRevistas("Tela");

                        if (!temRevistaCadastrada)
                            notificador.ApresentarMensagem("Nenhuma revista cadastrada", TipoMensagem.Atencao);

                        Console.ReadLine();
                    }
                }
                else if (opcaoMenuPrincipal == "3")
                {

                    string opcao = telaCadastroAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroAmigo.InserirNovoAmigo();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroAmigo.EditarAmigo();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroAmigo.ExcluirAmigo();
                    }
                    else if (opcao == "4")
                    {
                        bool temAmigoCadastrado = telaCadastroAmigo.VisualizarAmigos("Tela");
                        if (temAmigoCadastrado == false)
                        {
                            notificador.ApresentarMensagem("Nenhum amigo cadastrado", TipoMensagem.Atencao);
                        }
                        Console.ReadLine();
                    }

                }
            }





        }
    }
}
