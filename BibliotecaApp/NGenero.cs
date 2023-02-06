using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BibliotecaApp
{
    static class NGenero
    {
        private static List<Genero> generos = new List<Genero>();

        public static void Inserir(Genero g)
        {
            Abrir();
            generos.Add(g);
            Salvar();
        }

        public static void Excluir(Genero g)
        {
            Abrir();
            generos.Remove(Listar(g.Id));
            Salvar();
        }

        public static void Atualizar(Genero g)
        {
            Abrir();
            Genero obj = Listar(g.Id);
            obj.Nome = g.Nome;
            Salvar();
        }

        public static List<Genero> Listar()
        {
            Abrir();
            return generos;
        }

        public static Genero Listar(int id)
        {
            foreach (Genero g in generos)
            {
                if (g.Id == id)
                {
                    return g;
                }
            }

            return null;
        }

        public static void Abrir()
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

        public static void Salvar()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Genero>));
            using (StreamWriter writer = new StreamWriter("./genero.xml"))
            {
                serializer.Serialize(writer, generos);
            }
        }
    }
}
