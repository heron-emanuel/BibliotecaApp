using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BibliotecaApp
{
    class NLivro
    {
        private List<Livro> livros = new List<Livro>();

        public void Inserir(Livro l)
        {
            Abrir();
            livros.Add(l);
            Salvar();
        }

        public void Excluir(Livro l)
        {
            Abrir();
            livros.Remove(Listar(l.Id));
            Salvar();
        }

        public void Atualizar(Livro l)
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

        public List<Livro> Listar()
        {
            Abrir();
            return livros;
        }

        public Livro Listar(int id)
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

        public List<Livro> Listar(Genero g)
        {
            Abrir();
            List<Livro> ls = new List<Livro>();
            foreach (Livro obj in livros)
                if (obj.IdGenero == g.Id) ls.Add(obj);
            return ls;
        }

        

        public void Abrir()
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

        public void Salvar()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Livro>));
            using (StreamWriter writer = new StreamWriter("./livro.xml"))
            {
                serializer.Serialize(writer, livros);
            }
        }

        public void AtribuirGenero(Livro l, Genero g)
        {
            Abrir();
            Livro obj = Listar(l.Id);
            obj.IdGenero = g.Id;
            Salvar();
        }
    }
}
