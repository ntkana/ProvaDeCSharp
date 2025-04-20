using ProvaC_.DAO;
using ProvaC_.Models;

namespace ProvaC_.Services
{
    public class LivroService
    {
        private LivroDAO livroDAO;

        public LivroService(string connectionString)
        {
            livroDAO = new LivroDAO(connectionString);
        }

        public void InserirLivro(Livro livro)
        {
            livroDAO.Inserir(livro);
        }

        public List<Livro> ListarLivros()
        {
            return livroDAO.Listar();
        }

        public void EditarLivro(Livro livro)
        {
            livroDAO.Editar(livro);
        }

        public void RemoverLivro(int id)
        {
            livroDAO.Remover(id);

        }
    }
}
