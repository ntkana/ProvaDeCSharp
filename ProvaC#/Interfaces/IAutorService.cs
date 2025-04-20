using ProvaC_.Models;

namespace ProvaC_.Interfaces

{
    public interface IAutorService
    {
        void InserirAutor(Autor autor);
        List<Autor> ListarAutores();
        void EditarAutor(Autor autor);
        void RemoverAutor(int id);
        void BuscarAutorPorNome(string nome);
    }
}

// concluído, só falta arrumar os errinhos
