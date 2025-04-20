using ProvaC_.Models;

namespace ProvaC_.Interfaces
{
    public interface ILivroService
    {
        void InserirLivro(Livro livro);
        List<Livro> ListarLivros();
        void EditarLivro(Livro livro);
        void RemoverLivro(int id);
    }
}

// concluído, só falta arrumar os errinhos