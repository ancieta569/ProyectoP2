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
using System.Windows.Threading;

namespace ProyectoP2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Config co;

        public MainWindow()
        {
            InitializeComponent();
            co = new Config();
            co.VeriTxt();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTinker;
            dt.Start();
        }

        private void dtTinker(object sender, EventArgs e)
        {
            lblHora.Content = System.DateTime.Now.Hour.ToString("00") + ":" +
                System.DateTime.Now.Minute.ToString("00") + ":" +
                System.DateTime.Now.Second.ToString("00");
            lblFecha.Content = System.DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Realmete deseas salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            try
            {
                string usuario, contra;
                co = new Config();
                usuario = txtUsuario.Text.Trim();
                contra = co.Md5(pwdContra.Password.Trim());
                if (usuario != "" && contra != "")
                {
                    if (co.ValidarUsuario(usuario, contra))
                    {
                        Menu menu = new Menu();
                        menu.Show();
                        this.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lblSms.Content = "Datos Incorrectos";
                    }
                }
                else
                {
                    lblSms.Content = "Ingresa el usuario y la contraseña";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
}
