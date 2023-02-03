using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp
{
    public class Livro
    {
        public int Id { get; set; }

        public int IdGenero { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public DateTime DataDePublicacao { get; set; }

        public string Editora { get; set;  }

        public int NumPaginas { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Autor} - {Editora} - {NumPaginas} páginas";
        }
    }
}
