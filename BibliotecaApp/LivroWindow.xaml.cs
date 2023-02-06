using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BibliotecaApp
{
    /// <summary>
    /// Lógica interna para LivroWindow.xaml
    /// </summary>
    public partial class LivroWindow : Window
    {
        public LivroWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            Livro l = new Livro();
            l.Id = int.Parse(txtId.Text);
            l.Nome = txtNome.Text;
            l.Autor = txtAutor.Text;
            l.Editora = txtEditora.Text;
            l.NumPaginas = int.Parse(txtNumPaginas.Text);
            if (datePicker.SelectedDate.HasValue)
            {
                l.DataDePublicacao = datePicker.SelectedDate.Value;
            }
            NLivro.Inserir(l);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listLivros.ItemsSource = null;
            listLivros.ItemsSource = NLivro.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            Livro l = new Livro();
            l.Id = int.Parse(txtId.Text);
            l.Nome = txtNome.Text;
            l.Autor = txtAutor.Text;
            l.Editora = txtEditora.Text;
            l.NumPaginas = int.Parse(txtNumPaginas.Text);
            if (datePicker.SelectedDate.HasValue)
            {
                l.DataDePublicacao = datePicker.SelectedDate.Value;
            }
            NLivro.Atualizar(l);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            Livro l = new Livro();
            l.Id = int.Parse(txtId.Text);
            NLivro.Excluir(l);
            ListarClick(sender, e);
        }

        private void listLivros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLivros.SelectedItem != null)
            {
                Livro obj = (Livro)listLivros.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                txtAutor.Text = obj.Autor;
                txtEditora.Text = obj.Editora;
                txtNumPaginas.Text = obj.NumPaginas.ToString();
                datePicker.SelectedDate = obj.DataDePublicacao;
            }
        }
    }
}
