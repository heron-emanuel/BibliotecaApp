using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BibliotecaApp
{
    static class NExemplar
    {
        private static List<Exemplar> exemplares = new List<Exemplar>();

        public static void Inserir(Exemplar e)
        {
            Abrir();
            exemplares.Add(e);
            Salvar();
        }

        public static void Excluir(Exemplar e)
        {
            Abrir();
            exemplares.Remove(Listar(e.Id));
            Salvar();
        }

        public static void Atualizar(Exemplar e)
        {
            Abrir();
            Exemplar obj = Listar(e.Id);
            obj.CapaDura = e.CapaDura;
            obj.Estoque = e.Estoque;
            obj.IdLivro = e.IdLivro;
            Salvar();
        }

        public static List<Exemplar> Listar()
        {
            Abrir();
            return exemplares;
        }

        public static Exemplar Listar(int id)
        {
            Abrir();
            foreach (Exemplar e in exemplares)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }

            return null;
        }

        public static List<Exemplar> Listar(Livro l)
        {
            Abrir();
            List<Exemplar> exs = new List<Exemplar>();
            foreach (Exemplar obj in exemplares)
                if (obj.IdLivro == l.Id) exemplares.Add(obj);
            return exemplares;
        }
        public static void Abrir()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Exemplar>));
                using (StreamReader reader = new StreamReader("./exemplar.xml"))
                {
                    exemplares = (List<Exemplar>)serializer.Deserialize(reader);
                }
            }
            catch
            {
                exemplares = new List<Exemplar>();
            }
        }

        public static void Salvar()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Exemplar>));
            using (StreamWriter writer = new StreamWriter("./exemplar.xml"))
            {
                serializer.Serialize(writer, exemplares);
            }
        }

        public static void AtribuirLivro(Exemplar e, Livro l) 
        {
            Abrir();
            Exemplar obj = Listar(e.Id);
            obj.IdLivro = l.Id;
            Salvar();
        }
    }
}
