using System;

namespace appSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        public static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos servicos.");
            Console.ReadLine();
            
        }
        private static string ObterOpcaoUsuario()
            {
                System.Console.WriteLine();
                System.Console.WriteLine("App Séries a seu dispor :)");
                System.Console.WriteLine("Informe a opcao desejada:");

                System.Console.WriteLine("1- Listar séries");
                System.Console.WriteLine("2- Inserir nova série");
                System.Console.WriteLine("3- Atualizar série");
                System.Console.WriteLine("4- Excluir série");
                System.Console.WriteLine("5- Visualizar série");
                System.Console.WriteLine("C- Limpar Tela");
                System.Console.WriteLine("X - Sair");

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }

            
            
            //Método Listar Séries
            private static void ListarSeries()
            {
                System.Console.WriteLine("Listar séries");
                var lista = repositorio.Lista();
                if(lista.Count == 0)
                {
                    System.Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    if(!excluido)
                    {
                        System.Console.WriteLine($"#ID {serie.retornaId()}: {serie.retornaTitulo()}");
                    }
                    else 
                    {
                        System.Console.WriteLine($"O ID {serie.retornaId} : {serie.retornaTitulo()} foi excluído");
                    }
                    
                }
            }

            //Método Inserir Séries
            private static void InserirSerie()
            {
                System.Console.WriteLine("Inserir nova série");
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
                }
                System.Console.WriteLine("Digite o genero entre as opcoes acima:");
                int entradaGenero = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();
                
                System.Console.WriteLine("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());
                
                System.Console.WriteLine("Digite a Descricao da Série: ");
                string entradaDescricao = Console.ReadLine();
                
                Serie novaSerie = new Serie(id: repositorio.ProximoId(),genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

                repositorio.Insere(novaSerie);
            }
            
            //Método Atualizar Séries
            private static void AtualizarSerie()
            {
                System.Console.WriteLine("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());
                
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
                }
                System.Console.WriteLine("Digite o genero entre as opcoes acima:");
                int entradaGenero = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();
                
                System.Console.WriteLine("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());
                
                System.Console.WriteLine("Digite a Descricao da Série: ");
                string entradaDescricao = Console.ReadLine();
                
                Serie novaSerie = new Serie(id: indiceSerie,genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

                repositorio.Insere(novaSerie);
            }

            //Método Excluir Séries
            private static void ExcluirSerie()
            {
                System.Console.WriteLine("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                System.Console.WriteLine($"Tem certeza que deseja excluir id {indiceSerie}? \nSe sim, aperte [enter]");
                Console.ReadLine();
                
                repositorio.Exclui(indiceSerie);
            }

            //Método Visualizar Séries
            private static void VisualizarSerie()
            {
                System.Console.WriteLine("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(indiceSerie);
                System.Console.WriteLine(serie);
            }
    }
}

