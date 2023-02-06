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
    /// Lógica interna para ExemplarWindow.xaml
    /// </summary>
    public partial class ExemplarWindow : Window
    {
        public ExemplarWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            Exemplar ex = new Exemplar();
            ex.Id = int.Parse(txtId.Text);
            ex.Estoque = int.Parse(txtEstoque.Text);
            ex.CapaDura = isCapaDura.IsChecked ?? false;
            NExemplar.Inserir(ex);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listExemplares.ItemsSource = null;
            listExemplares.ItemsSource = NExemplar.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            Exemplar ex = new Exemplar();
            ex.Id = int.Parse(txtId.Text);
            ex.Estoque = int.Parse(txtEstoque.Text);
            ex.CapaDura = isCapaDura.IsChecked ?? false;
            NExemplar.Atualizar(ex);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            Exemplar ex = new Exemplar();
            ex.Id = int.Parse(txtId.Text);
            NExemplar.Excluir(ex);
            ListarClick(sender, e);
        }

        private void listExemplares_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listExemplares.SelectedItem != null)
            {
                Exemplar obj = (Exemplar)listExemplares.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtEstoque.Text = obj.Estoque.ToString();
                isCapaDura.IsChecked = obj.CapaDura;
            }
        }
    }
}
