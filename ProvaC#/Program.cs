using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProvaC_.Models;
using ProvaC_.Services;

var builder = new ConfigurationBuilder()
    .SetBasePath("\\Users\\AnaLe\\OneDrive\\Desktop\\TREINAMENTO\\ProvaC#\\ProvaC#")
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

 string connectionString = configuration.GetConnectionString("ConexaoPadrao");

AutorService objAutor = new AutorService(connectionString);
LivroService objLivro = new LivroService(connectionString);

int opcao;

do
{
    Console.Clear();
    Console.WriteLine("==== MENU ====");
    Console.WriteLine("1 - Cadastrar Autor");
    Console.WriteLine("2 - Listar Autores");
    Console.WriteLine("3 - Atualizar Autor");
    Console.WriteLine("4 - Remover Autor");
    Console.WriteLine("5 - Cadastrar Livro");
    Console.WriteLine("6 - Listar Livros (com Nome e Nacionalidade do Autor)");
    Console.WriteLine("7 - Atualizar Livro");
    Console.WriteLine("8 - Remover Livro");
    Console.WriteLine("9 - Buscar Autor por Nome");
    Console.WriteLine("10 - Buscar Livro por Título");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1: InserirAutor(objAutor); break;
        case 2: ListarAutores(objAutor); break;
        case 3: EditarAutor(objAutor); break;
        case 4: RemoverAutor(objAutor); break;
        case 5: InserirLivro(objLivro); break;
        case 6: ListarLivros(objLivro); break;
        case 7: EditarLivro(objLivro); break;
        case 8: RemoverLivro(objLivro); break;

    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (opcao != 0);

void InserirAutor(AutorService objAutor)
{
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Nacionalidade: ");
    string nacionalidade = Console.ReadLine();
    objAutor.Inserir(new Autor { Nome = nome, Nacionalidade = nacionalidade });
}
void ListarAutores(AutorService objAutor)
{
    var autores = objAutor.Listar();
    foreach (var autor in autores)
    {
        Console.WriteLine($"Id: {autor.Id} - Nome: {autor.Nome} - Nacionalidade: {autor.Nacionalidade}");
    }
}
void EditarAutor(AutorService objAutor)
{
    Console.Write("Id do autor: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Novo nome: ");
    string nome = Console.ReadLine();
    Console.Write("Nova nacionalidade: ");
    string nacionalidade = Console.ReadLine();

    objAutor.Editar(new Autor { Id = id, Nome = nome, Nacionalidade = nacionalidade });
}
void RemoverAutor(AutorService objAutor)
{
    Console.Write("Id do autor: ");
    int id = int.Parse(Console.ReadLine());
    objAutor.Remover(id);
}
void InserirLivro(LivroService objLivro)
{
   

    Console.Write("Título: ");
    string titulo = Console.ReadLine();
    Console.Write("Gênero: ");
    string genero = Console.ReadLine();
    Console.Write("Ano de Publicação: ");
    int anoPublicacao = int.Parse(Console.ReadLine());
    Console.Write("Id do Autor: ");
    int idAutor = int.Parse(Console.ReadLine());

    objLivro.InserirLivro(new Livro { Titulo = titulo, Genero = genero, AnoPublicacao = anoPublicacao, IdAutor = idAutor });

}
void ListarLivros(LivroService objLivro)
{
    var livros = objLivro.ListarLivros();
    foreach (var livro in livros)
    {
        Console.WriteLine($"Id: {livro.Id} - Título do livro: {livro.Titulo} - Gênero: {livro.Genero}");
    }
}
void EditarLivro(LivroService objLivro)
{
    Console.Write("Id do livro: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Novo título: ");
    string titulo = Console.ReadLine();
    Console.Write("Novo gênero: ");
    string genero = Console.ReadLine();
    Console.Write("Novo ano de publicação: ");
    int anoPublicacao = int.Parse(Console.ReadLine());
    Console.Write("Id do Autor: ");
    int idAutor = int.Parse(Console.ReadLine());

    objLivro.EditarLivro(new Livro { Id = id, Titulo = titulo, Genero = genero, AnoPublicacao = anoPublicacao, IdAutor = idAutor });
}
void RemoverLivro(LivroService objLivro)
{
    Console.Write("Id do livro: ");
    int id = int.Parse(Console.ReadLine());
    objLivro.RemoverLivro(id);
}