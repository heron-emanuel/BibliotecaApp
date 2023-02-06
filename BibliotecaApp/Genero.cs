using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp
{
    public class Genero
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
