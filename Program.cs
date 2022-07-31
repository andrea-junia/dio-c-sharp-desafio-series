using System;

namespace DIO.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            Console.Clear();
            string opcaoUsuario = ObterOpcao();

            while (opcaoUsuario.ToUpper() != "X")
            {   
                switch (opcaoUsuario)
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
                        Console.WriteLine("Opcao invalida.");
                        break;
                }
                opcaoUsuario = ObterOpcao();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine("Presione qualquer tecla para encerrar.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada");
                return;
            }
            foreach( var serie in lista)
            {
                var excluido = serie.retornaExcluido();
				Console.WriteLine("#ID: {0} {1} {2} ", serie.retornaID, serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        
        private static void InserirSerie()
		{
            int    entradaGenero    = 0;
            int    entradaAno       = 0;
            string entradaTitulo    = "";
            string entradaDescricao = "";

			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            
            Console.Write("");
            Console.Write("Digite o gênero entre as opções acima: ");
            try
            {
                entradaGenero = int.Parse(Console.ReadLine());    
            }
            catch
            {
                Console.WriteLine("Genero invalido");
                return;    
            }
            
            if (!Enum.IsDefined(typeof(Genero), entradaGenero))
            {
                Console.WriteLine("Genero invalido");
                return;                
            }                        

			Console.Write("Digite o Título da Série: ");
			entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			//entradaAno = int.Parse(Console.ReadLine());
            try
            {
                entradaAno = int.Parse(Console.ReadLine());    
            }
            catch
            {
                entradaAno = 0;   
            }
            
			Console.Write("Digite a Descrição da Série: ");
			entradaDescricao = Console.ReadLine();

            /*convencionei o ano como 1895. nesse ano os irmao Lumiere realizaram a 1a exibicao cinematografica publica
            //fonte
            //https://www.brasilparalelo.com.br/artigos/historia-do-cinema-mundial?gclid=CjwKCAjwrZOXBhACEiwA0EoRD91Fzu-e-yjdDV7XoOrRSfI7yaHdpvAKzksTqF50Lg5l_GkLrhtoOxoCBf0QAvD_BwE
            */
            if ( entradaTitulo == "" || entradaAno < 1895 || entradaDescricao == "" )
            {
                Console.WriteLine("Titulo, Ano ou Descricao em branco. Verifique parametros e tente novamente");
                return;
            }

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}
        
        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Série nao cadastrada");
                return;
            }

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            Console.Write("");
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

            if(!Enum.IsDefined(typeof(Genero), entradaGenero))
            {
                Console.WriteLine("Genero invalido");
                return;
            }

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Série nao cadastrada");
                return;
            }

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Série nao cadastrada");
                return;
            }

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
        private static string ObterOpcao()
        {   
            Console.WriteLine(); 
            Console.WriteLine("+----------------------------------+");
            Console.WriteLine("|    DIO Séries a seu dispor!!!    |");
            Console.WriteLine("+----------------------------------+");
            Console.WriteLine("| 1 - Listar séries                |");           
            Console.WriteLine("| 2 - Inserir nova série           |");             
            Console.WriteLine("| 3 - Atualizar série              |");             
            Console.WriteLine("| 4 - Excluir série                |");            
            Console.WriteLine("| 5 - Visualizar série             |");             
            Console.WriteLine("| C - Limpar Tela                  |");             
            Console.WriteLine("| X - Sair                         |");    
            Console.WriteLine("+----------------------------------+");        
            Console.WriteLine();    
            Console.Write("Informe a opção desejada: ");    

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

