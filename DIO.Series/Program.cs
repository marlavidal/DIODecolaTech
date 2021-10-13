using System;

namespace DIO.Series
{
    internal class NewBaseType
    {
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("| * DIO Séries & Filmes a seu dispor! * |");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }

    class Program : NewBaseType
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmeRepositorio repositorio2 = new FilmeRepositorio();
        static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();
			while (opcaoUsuario.ToUpper() !="X")
			{
				 switch (opcaoUsuario)
				 {
					 case "1":
					 	Console.Clear();
                        MenuFilmes();
                        Console.ReadLine();
                        break;
					 case "2":
					 	Console.Clear();
                        MenuSeries();
                        Console.ReadLine();
                        break;
					
					 default:
						 throw new ArgumentOutOfRangeException();
				 }

				 opcaoUsuario = ObterOpcaoUsuario();
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.Clear();
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("| * Menu Principal Fimes & Series * |");
			Console.WriteLine("-------------------------------------");
			Console.WriteLine();
			Console.WriteLine("Escolha uma opção!");
			Console.WriteLine();
			Console.WriteLine(" 1 - Series");
			Console.WriteLine(" 2 - Filmes");
			Console.WriteLine(" X - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static void MenuFilmes()
		{
			string menuFilmes = ObterOpcaoFilme();

			while (menuFilmes.ToUpper() != "X")
			{ 
				switch (menuFilmes)
				{
					case "1":
						Console.Clear();
                        ListarFilmes();
                        Console.ReadLine();
                        break;
					case "2":
						Console.Clear();
                        InserirFilme();
                        Console.ReadLine();
                        break;
					case "3":
						Console.Clear();
                        AtualizarFilme();
                        Console.ReadLine();
                        break;
					case "4":
						Console.Clear();
                        ExcluirFilme();
                        Console.ReadLine();
                        break;
					case "5":
						Console.Clear();
                        VisualizarFilme();
                        Console.ReadLine();
                        break;
		
					default:
						throw new ArgumentOutOfRangeException();
				}
				
				menuFilmes = ObterOpcaoUsuario();
			}

		}

		private static string ObterOpcaoFilme()
		{
			Console.WriteLine();
			Console.WriteLine("----------------------");
			Console.WriteLine("| * Menu de Filmes * |");
			Console.WriteLine("----------------------");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();
			Console.WriteLine("1 - Listar filmes");
			Console.WriteLine("2 - Inserir novo filme");
			Console.WriteLine("3 - Atualizar filme");
			Console.WriteLine("4 - Excluir filme");
			Console.WriteLine("5 - Visualizar filme");
			Console.WriteLine("X - Menu anterior");
			Console.WriteLine();

			string opcaoFilme = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoFilme;
		}

        private static void MenuSeries()
		{
			string menuSeries = ObterOpcaoSerie();

			while (menuSeries.ToUpper() != "X")
			{ 
				switch (menuSeries)
				{
					case "1":
						Console.Clear();
                        ListarSeries();
                        Console.ReadLine();
                        break;
					case "2":
						Console.Clear();
                        InserirSerie();
                        Console.ReadLine();
                        break;
					case "3":
						Console.Clear();
                        AtualizarSerie();
                        Console.ReadLine();
                        break;
					case "4":
						Console.Clear();
                        ExcluirSerie();
                        Console.ReadLine();
                        break;
					case "5":
						Console.Clear();
                        VisualizarSerie();
                        Console.ReadLine();
                        break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				
				menuSeries = ObterOpcaoUsuario();
			}

		}

		private static string ObterOpcaoSerie()
		{
			Console.WriteLine();
			Console.WriteLine("----------------------");
			Console.WriteLine("| * Menu de Series * |");
			Console.WriteLine("----------------------");
			Console.WriteLine();
			Console.WriteLine("");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Listar series");
			Console.WriteLine("2 - Inserir nova serie");
			Console.WriteLine("3 - Atualizar series");
			Console.WriteLine("4 - Excluir serie");
			Console.WriteLine("5 - Visualizar serie");
			Console.WriteLine("X - Menu anterior");
			Console.WriteLine();

			string opcaoSerie = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoSerie;
		}


        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

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
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

		public static void ListarFilmes() {
			Console.WriteLine("Listar filmes");

			var lista = repositorio2.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		public static void InserirFilme() {
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorio2.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio2.Insere(novoFilme);	
		}
		public static void AtualizarFilme() {
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio2.Atualiza(indiceFilme, atualizaFilme);
		}
		public static void ExcluirFilme() {
			 Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorio2.Exclui(indiceFilme);
		}
		public static void VisualizarFilme() {
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio2.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}
    }
}
