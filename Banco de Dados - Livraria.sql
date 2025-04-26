
CREATE TABLE Autor(
IdAutor INT IDENTITY,
NomeAutor VARCHAR (90) NOT NULL,
NacionalidadeAutor VARCHAR (40) NOT NULL,
CONSTRAINT a_id_autor PRIMARY KEY(IdAutor)
);

CREATE TABLE Livro(
IdLivro INT NOT NULL PRIMARY KEY IDENTITY,
TituloLivro VARCHAR (90) NOT NULL,
GêneroLivro VARCHAR (50), 
AnoPublicacaoLivro INT,
IdAutor INT,
CONSTRAINT b_id_autor FOREIGN KEY(IdAutor)
  REFERENCES Autor(IdAutor) ON DELETE CASCADE
);

SELECT * FROM Livro