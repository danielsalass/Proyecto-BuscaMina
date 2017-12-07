using Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.ServiceModel;
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
        public ChannelFactory<IServicioCuenta> canal = new ChannelFactory<IServicioCuenta>("ExtremoServicioCuenta");
        public IServicioCuenta proxy;

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
            proxy = canal.CreateChannel();

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
            
           
            var usuario = Usuario.Text;
            var contra = Contraseña.Text;
            var resultado = proxy.IniciarSesion(usuario, Sha256(contra));
            MessageBox.Show(resultado);
            
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

        public string Sha256(string contrasena)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(contrasena), 0, Encoding.UTF8.GetByteCount(contrasena));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}

