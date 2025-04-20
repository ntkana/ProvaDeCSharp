using ProvaC_.Models;

namespace ProvaC_.Interfaces
{
    public interface ILivroService
    {
        void InserirLivro(Livro livro);
        List<Livro> ListarLivros();
        void EditarLivro(Livro livro);
        void RemoverLivro(int id);
        void BuscarLivroPorTitulo(string titulo);
    }
}

// concluído, só falta arrumar os errinhos