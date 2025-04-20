namespace ProvaC_.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int IdAutor { get; set; }
    }
}
// classe livro (entidade)
// concluído