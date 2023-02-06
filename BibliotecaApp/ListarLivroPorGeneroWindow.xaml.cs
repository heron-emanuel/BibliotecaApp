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
    /// Lógica interna para ListarLivroPorGeneroWindow.xaml
    /// </summary>
    public partial class ListarLivroPorGeneroWindow : Window
    {
        public ListarLivroPorGeneroWindow()
        {
            InitializeComponent();
            listGenero.ItemsSource = NGenero.Listar();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            if (listGenero.SelectedItem != null)
            {
                Genero g = (Genero)listGenero.SelectedItem;
                listLivros.ItemsSource = null;
                listLivros.ItemsSource = NLivro.Listar(g);
            }
            else
                MessageBox.Show("É preciso selecionar um gênero");
        }
    }
}
