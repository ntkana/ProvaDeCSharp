using Microsoft.Data.SqlClient;
using ProvaC_.Models;

namespace ProvaC_.DAO
{
    public class LivroDAO
    {
        private string _connectionString;
        public LivroDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

            public void Inserir(Livro livro)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Livro (TituloLivro, GêneroLivro, AnoPublicacaoLivro, IdAutor) VALUES (@TituloLivro, @GêneroLivro, @AnoPublicacaoLivro, @IdAutor)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TituloLivro", livro.Titulo);
                cmd.Parameters.AddWithValue("@GêneroLivro", livro.Genero);
                cmd.Parameters.AddWithValue("@AnoPublicacaoLivro", livro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@IdAutor", livro.IdAutor);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Livro> Listar()
        {
            var livros = new List<Livro>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    livros.Add(new Livro
                    {
                        Id = Convert.ToInt32(reader["IdLivro"]),
                        Titulo = reader["TituloLivro"].ToString(),
                        Genero = reader["GêneroLivro"].ToString(),
                        AnoPublicacao = Convert.ToInt32(reader["AnoPublicacaoLivro"]),
                        IdAutor = Convert.ToInt32(reader["IdAutor"])
                    });
                }
            }

            return livros;
        }

        public void Editar(Livro livro)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Livro 
                                 SET TituloLivro = @TituloLivro, GêneroLivro = @GêneroLivro, AnoPublicacaoLivro = @AnoPublicacaoLivro, IdAutor = @IdAutor
                                 WHERE IdLivro = @IdLivro";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TituloLivro", livro.Titulo);
                cmd.Parameters.AddWithValue("@GêneroLivro", livro.Genero);
                cmd.Parameters.AddWithValue("@AnoPublicacaoLivro", livro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@IdAutor", livro.IdAutor);
                cmd.Parameters.AddWithValue("@IdLivro", livro.Id);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Remover(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Livro WHERE IdLivro = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void BuscarLivroTitulo(string titulo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro WHERE TituloLivro LIKE @TituloLivro";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TituloLivro", "%" + titulo + "%");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["IdLivro"]}, Título: {reader["TituloLivro"]}, Gênero: {reader["GêneroLivro"]}, Ano de Publicação: {reader["AnoPublicacaoLivro"]}, Id Autor: {reader["IdAutor"]}");
                }
            }
        }
    }
}