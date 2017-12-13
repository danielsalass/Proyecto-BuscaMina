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
    
    public partial class UnirsePartida : Window
    {

        ResourceManager AdministradorDeRecursos;
        CultureInfo cultura;
        string lenguaje;

        public UnirsePartida()
        {

            InitializeComponent();
            AdministradorDeRecursos = new ResourceManager("Buscaminas.lenguaje.Resource", typeof(CrearUsuario).Assembly);
            lenguaje = "es-MX";
            PonerTexto();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu cancelar = new Menu();
            cancelar.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tablero iniciar = new Tablero();
            iniciar.Show();
            Close();
        }

        private void PonerTexto()
        {
            cultura = CultureInfo.CreateSpecificCulture(lenguaje);
            Iniciar.Content = AdministradorDeRecursos.GetString("Iniciar", cultura);
            Cancelar.Content = AdministradorDeRecursos.GetString("Cancelar", cultura);
            Mensaje.Text = AdministradorDeRecursos.GetString("Mensaje", cultura);
            Español.Text = AdministradorDeRecursos.GetString("Español", cultura);
            Ingles.Text = AdministradorDeRecursos.GetString("Ingles", cultura);

        }


        private void Ingles_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lenguaje = "en-US";
            PonerTexto();
        }

        private void Español_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lenguaje = "es-MX";
            PonerTexto();
        }

       
    }
}
