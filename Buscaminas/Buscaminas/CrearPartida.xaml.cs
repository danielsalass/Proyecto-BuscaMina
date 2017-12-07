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
    
    public partial class CrearPartida : Window
    {

        ResourceManager AdministradorDeRecursos;
        CultureInfo cultura;
        string lenguaje;

        public CrearPartida()
        {

            InitializeComponent();
            AdministradorDeRecursos = new ResourceManager("Buscaminas.lenguaje.Resource", typeof(CrearUsuario).Assembly);
            lenguaje = "es-MX";
            PonerTexto();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            Close();
        }

        private void PonerTexto()
        {
            cultura = CultureInfo.CreateSpecificCulture(lenguaje);
            Cancelar.Content = AdministradorDeRecursos.GetString("Cancelar", cultura);
            MensajeEspera.Text = AdministradorDeRecursos.GetString("MensajeEspera", cultura);
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
