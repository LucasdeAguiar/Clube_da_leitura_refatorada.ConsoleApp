using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_leitura_refatorada.ConsoleApp
{
    public class TelaCadastroAmigo
    {
        public RepositorioAmigo repositorioAmigo;
        public int numeroAmigos;
        public Notificador notificador;


        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo amigo");

            Amigo novoAmigo = ObterAmigo();
            repositorioAmigo.Inserir(novoAmigo);
          

            notificador.ApresentarMensagem("Amigo cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public Amigo ObterAmigo()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel do amigo: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o email do amigo: ");
            string email = Console.ReadLine();

            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nomeAmigo = nome;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            return amigo;
        }

        public bool VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = repositorioAmigo.selecionarTodos();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {


                Amigo a = amigos[i];

                Console.WriteLine("Id: " + a.id);
                Console.WriteLine("Nome: " + a.nomeAmigo);
                Console.WriteLine("Nome do responsável: " + a.nomeResponsavel);
                Console.WriteLine("Telefone: " + a.telefone);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
            }
            return true;
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            bool temAmigosRegistrados = VisualizarAmigos("Pesquisando");

            if (temAmigosRegistrados == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para poder editar", TipoMensagem.Atencao);
            }

            int numeroAmigo = ObterNumeroAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(numeroAmigo, amigoAtualizado);


            notificador.ApresentarMensagem("Amigo editado com sucesso", TipoMensagem.Sucesso);
        }


        public int ObterNumeroAmigo()
        {
            int numeroAmigo = 0;
            bool numeroAmigoEncontrado;

            do
            {
                Console.Write("Digite o número do amigo que deseja editar: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());

                numeroAmigoEncontrado = repositorioAmigo.VerificarNumeroAmigoExiste(numeroAmigo);

                if (numeroAmigoEncontrado == false)
                    notificador.ApresentarMensagem("Número de caixa não encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroAmigoEncontrado == false);
            return numeroAmigo;

        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhum amigo cadastrado para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroAmigo = ObterNumeroAmigo();

            repositorioAmigo.Excluir(numeroAmigo);


            notificador.ApresentarMensagem("Amigo excluído com sucesso", TipoMensagem.Sucesso);
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }



    }
}
