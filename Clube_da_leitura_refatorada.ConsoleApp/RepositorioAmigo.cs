using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_leitura_refatorada.ConsoleApp
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;



        public void Inserir(Amigo amigo)
        {
            amigo.id = ++numeroAmigo;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;


        }

        public void Editar(int numeroSelecionado, Amigo amigo)
        {

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == numeroSelecionado)
                {
                    amigo.id = numeroSelecionado;
                    amigos[i] = amigo;


                    break;
                }
            }


        }

        public void Excluir(int numeroSelecionado)
        {

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == numeroSelecionado)
                {
                    amigos[i] = null;
                    break;
                }
            }


        }

        public Amigo[] selecionarTodos()
        {
            int quantidadeAmigos = ObterQtdAmigos();
            int contador = 0;
            Amigo[] amigosInseridos = new Amigo[quantidadeAmigos];

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    amigosInseridos[contador] = amigos[i];
                    contador++;
                }
            }

            return amigosInseridos;
        }
        public int ObterQtdAmigos()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    numeroAmigos++;
                }


            }

            return numeroAmigos;
        }
        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

        public bool NomeJaUtilizado(string nomeInformado)
        {
            bool nomeJaUtilizado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].nomeAmigo == nomeInformado)
                {
                    nomeJaUtilizado = true;
                    break;
                }
            }
            return nomeJaUtilizado;
        }

        public bool VerificarNumeroAmigoExiste(int numeroAmigo)
        {
            bool numeroAmigoEncontrado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].id == numeroAmigo)
                {
                    numeroAmigoEncontrado = true;
                    break;
                }
            }

            return numeroAmigoEncontrado;
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel do amigo: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nomeAmigo = nome;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            return amigo;
        }
    }
}
