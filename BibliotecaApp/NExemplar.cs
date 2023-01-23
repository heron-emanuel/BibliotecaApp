using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BibliotecaApp
{
    class NExemplar
    {
        private List<Exemplar> exemplares = new List<Exemplar>();

        public void Inserir(Exemplar e)
        {
            Abrir();
            exemplares.Add(e);
            Salvar();
        }

        public void Excluir(Exemplar e)
        {
            Abrir();
            exemplares.Remove(Listar(e.Id));
            Salvar();
        }

        public void Atualizar(Exemplar e)
        {
            Abrir();
            Exemplar obj = Listar(e.Id);
            obj.CapaDura = e.CapaDura;
            obj.Estoque = e.Estoque;
            obj.IdLivro = e.IdLivro;
            Salvar();
        }

        public List<Exemplar> Listar()
        {
            Abrir();
            return exemplares;
        }

        public Exemplar Listar(int id)
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

        public List<Exemplar> Listar(Livro l)
        {
            Abrir();
            List<Exemplar> exs = new List<Exemplar>();
            foreach (Exemplar obj in exemplares)
                if (obj.IdLivro == l.Id) exemplares.Add(obj);
            return exemplares;
        }
        public void Abrir()
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

        public void Salvar()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Exemplar>));
            using (StreamWriter writer = new StreamWriter("./exemplar.xml"))
            {
                serializer.Serialize(writer, exemplares);
            }
        }

        public void AtribuirLivro(Exemplar e, Livro l) 
        {
            Abrir();
            Exemplar obj = Listar(e.Id);
            obj.IdLivro = l.Id;
            Salvar();
        }
    }
}
