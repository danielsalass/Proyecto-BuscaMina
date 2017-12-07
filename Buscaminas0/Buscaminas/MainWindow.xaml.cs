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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Buscaminas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ResourceManager AdministradorDeRecursos;
        CultureInfo cultura;
        string lenguaje;

        public MainWindow()
        {
            InitializeComponent();
            AdministradorDeRecursos = new ResourceManager("Buscaminas.lenguaje.Resource", typeof(MainWindow).Assembly);
            lenguaje = "es-MX";
            PonerTexto();
        }

        private void PonerTexto()
        {
            cultura = CultureInfo.CreateSpecificCulture(lenguaje);
            Usuario.Text = AdministradorDeRecursos.GetString("Usuario", cultura);
            Contraseña.Text = AdministradorDeRecursos.GetString("Contraseña", cultura);
            Ingresar.Content = AdministradorDeRecursos.GetString("Ingresar", cultura);
            Crear.Text = AdministradorDeRecursos.GetString("CrearCuenta", cultura);
            Español.Text = AdministradorDeRecursos.GetString("Español", cultura);
            Ingles.Text = AdministradorDeRecursos.GetString("Ingles", cultura);

        }

        private void Crear_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CrearUsuario crearUsuario = new CrearUsuario();
            crearUsuario.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu= new Menu();
            menu.Show();
            Close();
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
