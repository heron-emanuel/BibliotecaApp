using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BibliotecaApp
{
    class NGenero
    {
        private List<Genero> generos = new List<Genero>();

        public void Inserir(Genero g)
        {
            Abrir();
            generos.Add(g);
            Salvar();
        }

        public void Excluir(Genero g)
        {
            Abrir();
            generos.Remove(Listar(g.Id));
            Salvar();
        }

        public void Atualizar(Genero g)
        {
            Abrir();
            Genero obj = Listar(g.Id);
            obj.Nome = g.Nome;
            Salvar();
        }

        public List<Genero> Listar()
        {
            Abrir();
            return generos;
        }

        public Genero Listar(int id)
        {
            Abrir();
            foreach (Genero g in generos)
            {
                if (g.Id == id)
                {
                    return g;
                }
            }

            return null;
        }

        public void Abrir()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Genero>));
                using (StreamReader reader = new StreamReader("./genero.xml"))
                {
                    generos = (List<Genero>)serializer.Deserialize(reader);
                }
            }
            catch
            {
                generos = new List<Genero>();
            }
        }

        public void Salvar()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Genero>));
            using (StreamWriter writer = new StreamWriter("./genero.xml"))
            {
                serializer.Serialize(writer, generos);
            }
        }
    }
}
