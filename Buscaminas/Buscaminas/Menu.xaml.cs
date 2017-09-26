using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Buscaminas
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        ResourceManager AdministradorDeRecursos;
        CultureInfo cultura;
        string lenguaje;

        public Menu()
        {
            AdministradorDeRecursos = new ResourceManager("Buscaminas.lenguaje.Resource", typeof(MainWindow).Assembly);
            lenguaje = "es-MX";
            PonerTexto();
        
            InitializeComponent();
        }
        private void PonerTexto()
        {
            cultura = CultureInfo.CreateSpecificCulture(lenguaje);
            ConsultarP.Content = AdministradorDeRecursos.GetString("ConsultarPuntaje", cultura);
            CrearP.Content = AdministradorDeRecursos.GetString("CrearPartida", cultura);
            UnirseP.Content = AdministradorDeRecursos.GetString("UnirsePartida", cultura);
            Bienvenido.Text = AdministradorDeRecursos.GetString("Bienvenido", cultura);
            Español.Text = AdministradorDeRecursos.GetString("Español", cultura);
            Ingles.Text = AdministradorDeRecursos.GetString("Ingles", cultura);
            CerrarSesion.Content = AdministradorDeRecursos.GetString("CerrarSesion", cultura);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow cerrarSesion = new MainWindow();
            cerrarSesion.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void UnirseP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void Ingles_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lenguaje = "en-US";
            PonerTexto();
        }
        private void Español_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lenguaje = "es-MX";

        }
    }
}
