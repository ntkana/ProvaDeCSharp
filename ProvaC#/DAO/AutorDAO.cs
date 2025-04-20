using Microsoft.Data.SqlClient;
using ProvaC_.Services;
using Autor = ProvaC_.Models.Autor;

namespace ProvaC_.DAO
{
    public class AutorDAO
    {
        private string _connectionString;
        public AutorDAO(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public void InserirAutor(Autor autor)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Autor (NomeAutor, NacionalidadeAutor) VALUES (@NomeAutor, @NacionalidadeAutor)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NomeAutor", autor.Nome);
                cmd.Parameters.AddWithValue("@NacionalidadeAutor", autor.Nacionalidade);

                con.Open();
                cmd.ExecuteNonQuery();
            }


        }

        public List<Autor> ListarAutores()
        {
            List<Autor> autores = new List<Autor>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Autor autor = new Autor
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Nacionalidade = reader.GetString(2)
                    };
                    autores.Add(autor);
                }
            }
            return autores;
        }

        public void EditarAutor(Autor autor)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Autor SET NomeAutor = @NomeAutor, NacionalidadeAutor = @NacionalidadeAutor WHERE IdAutor = @IdAutor";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NomeAutor", autor.Nome);
                cmd.Parameters.AddWithValue("@NacionalidadeAutor", autor.Nacionalidade);
                cmd.Parameters.AddWithValue("@IdAutor", autor.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoverAutor(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Autor WHERE IdAutor = @IdAutor";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdAutor", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void BuscarAutorNome(string nome)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor WHERE NomeAutor LIKE @NomeAutor";
                SqlCommand cmd = new SqlCommand(query, con);
                Console.WriteLine("Digite o nome do autor que deseja buscar:");
                string Nome = Console.ReadLine();
                cmd.Parameters.AddWithValue("@NomeAutor", "%" + Nome + "%");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Autor autor = new Autor
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Nacionalidade = reader.GetString(2)
                    };
                    Console.WriteLine($"Id: {autor.Id}, Nome: {autor.Nome}, Nacionalidade: {autor.Nacionalidade}");
                }
            }
        }

    }
}


// concluído, só falta corrigir esses errinhos