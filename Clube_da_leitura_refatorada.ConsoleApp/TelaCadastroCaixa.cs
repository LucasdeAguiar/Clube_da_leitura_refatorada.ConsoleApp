using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_leitura_refatorada.ConsoleApp
{
   
        public class TelaCadastroCaixa
        {
            public RepositorioCaixa repositorioCaixa;
            public int numeroCaixa;
            public Notificador notificador;

            public string MostrarOpcoes()
            {
                Console.Clear();

                Console.WriteLine("Cadastro de Caixas");

                Console.WriteLine();

                Console.WriteLine("Digite 1 para Inserir");
                Console.WriteLine("Digite 2 para Editar");
                Console.WriteLine("Digite 3 para Excluir");
                Console.WriteLine("Digite 4 para Visualizar");

                Console.WriteLine("Digite s para sair");

                string opcao = Console.ReadLine();

                return opcao;
            }

            public void InserirNovaCaixa()
            {
                MostrarTitulo("Inserindo nova Caixa");

                Caixa novaCaixa = ObterCaixa();
                repositorioCaixa.Inserir(novaCaixa);

                notificador.ApresentarMensagem("Caixa inserida com sucesso!", TipoMensagem.Sucesso);
            }

            private Caixa ObterCaixa()
            {
                Console.Write("Digite a cor: ");
                string cor = Console.ReadLine();

                Console.Write("Digite a etiqueta: ");
                string etiqueta = Console.ReadLine();

                Caixa caixa = new Caixa();

                caixa.etiqueta = etiqueta;
                caixa.cor = cor;

                return caixa;
            }

            public void EditarCaixa()
            {
                MostrarTitulo("Editando Caixa");

                bool temCaixasCadastradas = VisualizarCaixas("Pesquisando");

                if (temCaixasCadastradas == false)
                {
                    notificador.ApresentarMensagem("Nenhuma caixa cadastrada para poder editar", TipoMensagem.Atencao);
                    return;
                }

                int numeroCaixa = ObterNumeroCaixa();

                Caixa caixaAtualizada = ObterCaixa();

                repositorioCaixa.Editar(numeroCaixa, caixaAtualizada);

                notificador.ApresentarMensagem("Caixa editada com sucesso", TipoMensagem.Sucesso);
            }

            public void MostrarTitulo(string titulo)
            {
                Console.Clear();

                Console.WriteLine(titulo);

                Console.WriteLine();
            }

            public void ExcluirCaixa()
            {
                MostrarTitulo("Excluindo Caixa");

                bool temCaixasCadastradas = VisualizarCaixas("Pesquisando");

                if (temCaixasCadastradas == false)
                {
                    notificador.ApresentarMensagem(
                        "Nenhuma caixa cadastrada para poder excluir", TipoMensagem.Atencao);
                    return;
                }

                int numeroCaixa = ObterNumeroCaixa();

                repositorioCaixa.Excluir(numeroCaixa);

                notificador.ApresentarMensagem("Caixa excluída com sucesso", TipoMensagem.Sucesso);
            }

            public bool VisualizarCaixas(string tipo)
            {
                if (tipo == "Tela")
                    MostrarTitulo("Visualização de Caixas");

                Caixa[] caixas = repositorioCaixa.SelecionarTodos();

                if (caixas.Length == 0)
                    return false;

                for (int i = 0; i < caixas.Length; i++)
                {
                    Caixa c = caixas[i];

                    Console.WriteLine("Número: " + c.numero);
                    Console.WriteLine("Cor: " + c.cor);
                    Console.WriteLine("Etiqueta: " + c.etiqueta);

                    Console.WriteLine();
                }

                return true;
            }

            public int ObterNumeroCaixa()
            {
                int numeroCaixa;
                bool numeroCaixaEncontrado;

                do
                {
                    Console.Write("Digite o número da caixa que deseja editar: ");
                    numeroCaixa = Convert.ToInt32(Console.ReadLine());

                    numeroCaixaEncontrado = repositorioCaixa.VerificarNumeroCaixaExiste(numeroCaixa);

                    if (numeroCaixaEncontrado == false)
                        notificador.ApresentarMensagem("Número de caixa não encontrado, digite novamente", TipoMensagem.Atencao);

                } while (numeroCaixaEncontrado == false);
                return numeroCaixa;
            }



        }


    }

