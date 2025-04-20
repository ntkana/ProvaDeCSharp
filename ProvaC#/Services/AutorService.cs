using ProvaC_.DAO;
using ProvaC_.Models;

namespace ProvaC_.Services
{
    public class AutorService
    {
        private AutorDAO autorDAO;
        public AutorService(string connectionString)
        {
            autorDAO = new AutorDAO(connectionString);
        }
        public void Inserir(Autor autor)
        {

            autorDAO.InserirAutor(autor);
        }

        public List<Autor> Listar()
        {
            return autorDAO.ListarAutores();
        }

        public void Editar(Autor autor)
        {
            autorDAO.EditarAutor(autor);
        }

        public void Remover(int id)
        {
            autorDAO.RemoverAutor(id);
        }
    }
}

// concluído, só falta arrumar os errinhos