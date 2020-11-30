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
using System.Windows.Shapes;

namespace ProyectoP2
{
    /// <summary>
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Window
    {
             
        public Agregar()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxGenero.Items.Add("Masculino");
            cbxGenero.Items.Add("Femenino");
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
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Visibility = Visibility.Visible;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validaciones
                Config c = new Config();
                Persona p = new Persona();
                p.Id = c.GenerarId();
                p.Nombres = txtNombres.Text;
                p.Apellido = txtApellidos.Text;
                p.Genero = cbxGenero.Text;
                p.FNaci = DateTime.Parse(dpFnaci.Text);
                p.Usuario = txtIusuario.Text;
                p.Contra = c.Md5(pwdIcontra.Password);
                c.InsertaDato(p);
                MessageBox.Show("Usuario creado con exito");
                //Metodo limpiar
                Menu m = new Menu();
                m.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
}
