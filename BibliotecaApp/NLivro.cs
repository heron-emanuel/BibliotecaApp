using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BibliotecaApp
{
    static class NLivro
    {
        private static List<Livro> livros = new List<Livro>();

        public static void Inserir(Livro l)
        {
            Abrir();
            livros.Add(l);
            Salvar();
        }

        public static void Excluir(Livro l)
        {
            Abrir();
            livros.Remove(Listar(l.Id));
            Salvar();
        }

        public static void Atualizar(Livro l)
        {
            Abrir();
            Livro obj = Listar(l.Id);
            obj.Autor = l.Autor;
            obj.DataDePublicacao = l.DataDePublicacao;
            obj.Editora = l.Editora;
            obj.IdGenero = l.IdGenero;
            obj.Nome = l.Nome;
            obj.NumPaginas = l.NumPaginas;
            Salvar();
        }

        public static List<Livro> Listar()
        {
            Abrir();
            return livros;
        }

        public static Livro Listar(int id)
        {
            Abrir();
            foreach (Livro l in livros)
            {
                if (l.Id == id)
                {
                    return l;
                }
            }

            return null;
        }

        public static List<Livro> Listar(Genero g)
        {
            Abrir();
            List<Livro> ls = new List<Livro>();
            foreach (Livro obj in livros)
                if (obj.IdGenero == g.Id) ls.Add(obj);
            return ls;
        }

        

        public static void Abrir()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Livro>));
                using (StreamReader reader = new StreamReader("./livro.xml"))
                {
                    livros = (List<Livro>)serializer.Deserialize(reader);
                }
            } catch
            {
                livros = new List<Livro>();
            }
        }

        public static void Salvar()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Livro>));
            using (StreamWriter writer = new StreamWriter("./livro.xml"))
            {
                serializer.Serialize(writer, livros);
            }
        }

        public static void AtribuirGenero(Livro l, Genero g)
        {
            Abrir();
            Livro obj = Listar(l.Id);
            obj.IdGenero = g.Id;
            Salvar();
        }
    }
}
