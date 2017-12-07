using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;


namespace Buscaminas
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Tablero : Window
    {
        Operaciones oper = new Operaciones();
        public Tablero()
        {
            InitializeComponent();
        }
        int contador = 0;
        List<String> minasDesbloqueadas = new List<String>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button boton = sender as System.Windows.Controls.Button;
            string[] coordenadas = BuscarNumeros(boton.Name);
            int columna = Int32.Parse(coordenadas[1]);
            int fila = Int32.Parse(coordenadas[2]);
            int respuesta = oper.revisaMina(columna, fila);

            if (respuesta == 9)
            {
                Uri resourceUri = new Uri("Resources/bomb1.png", UriKind.Relative);
                StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                boton.Background = brush;
                System.Windows.MessageBox.Show("Perdiste :c", "Buscaminas",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Stop);
            }
            if (respuesta == 0)
            {
                Uri resourceUri = new Uri("Resources/7to_tOpy.jpg", UriKind.Relative);
                StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                boton.Background = brush;

                if (contador < 74)
                {
                    if (minasDesbloqueadas.Contains(boton.Name) == false)
                    {
                        minasDesbloqueadas.Add(boton.Name);
                        contador++;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Buscaminas", "Ganaste! c:",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                Console.WriteLine(contador);

            }
            if (respuesta != 0 && respuesta != 9)
            {
                Uri resourceUri = new Uri("Resources/" + respuesta + ".jpg", UriKind.Relative);
                StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;
                boton.Background = brush;

                if (contador < 74)
                {
                    if (minasDesbloqueadas.Contains(boton.Name) == false)
                    {
                        minasDesbloqueadas.Add(boton.Name);
                        contador++;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Buscaminas", "Ganaste! c:",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                Console.WriteLine(contador);
            }

        }

        public string[] BuscarNumeros(string nombre)
        {
            string[] valores = nombre.Split('_');
            return valores;
        }

        private void finalizarJuego(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            Close();
        }

        private void agregarMarca(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Button boton = sender as System.Windows.Controls.Button;
            Uri resourceUri = new Uri("Resources/bandera.jpg", UriKind.Relative);
            StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;
            boton.Background = brush;
        }
    }

}

