using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp
{
    class Exemplar
    {
        public int Id { get; set; }

        public int IdLivro { get; set; }

        public bool CapaDura { get; set; }

        public int Estoque { get; set; }

        public override string ToString()
        {
            return $"{IdLivro} - Capa dura: {CapaDura} - {Estoque};"
        }
    }
}
