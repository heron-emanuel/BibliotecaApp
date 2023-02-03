using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliotecaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Genero_Click(object sender, RoutedEventArgs e)
        {
            GeneroWindow w = new GeneroWindow();
            w.ShowDialog();
        }

        private void Livro_Click(object sender, RoutedEventArgs e)
        {
            LivroWindow w = new LivroWindow();
            w.ShowDialog();
        }

        private void Exemplar_Click(object sender, RoutedEventArgs e)
        {
            ExemplarWindow w = new ExemplarWindow();
            w.ShowDialog();
        }

        private void LivroToGenero_Click(object sender, RoutedEventArgs e)
        {
            LivroToGeneroWindow w = new LivroToGeneroWindow();
            w.ShowDialog();
        }

        private void ExemplarToLivro_Click(object sender, RoutedEventArgs e)
        {
            ExemplarToLivroWindow w = new ExemplarToLivroWindow();
            w.ShowDialog();
        }

        private void ExemplarPorLivro_Click(object sender, RoutedEventArgs e)
        {
            ListarExemplarLivroWindow w = new ListarExemplarLivroWindow();
            w.ShowDialog();
        }

        private void LivroPorGenero_Click(object sender, RoutedEventArgs e)
        {
            ListarLivroPorGeneroWindow w = new ListarLivroPorGeneroWindow();
            w.ShowDialog();
        }
    }
}
