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
using HotelDatos;

namespace HotelWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InicioVentanaOff();
            dpLlegadaBook.SelectedDate = DateTime.Today;
            dpSalidaBook.SelectedDate = DateTime.Today;
        }

        string rutCliente;
        string NumReserva;
        string direccion = "Duoc Uc";

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            

        }

        #region Reservar Hotel


        private void BtnHReservar_Click(object sender, RoutedEventArgs e)
        {
            ServiceCliente cli = new ServiceCliente();
            Cliente c = new Cliente();
            ServiceReserva res = new ServiceReserva();
            Reserva r = new Reserva();

            try
            {
                c.RutCliente = txtRutClienteBook.Text;
                rutCliente = c.RutCliente;
                c.Nombre = txtNombreBook.Text;
                c.Apellidos = txtApellidosBook.Text;
                c.Email = txtEmailBook.Text;
                c.Direccion = txtDireccionBook.Text;
                c.Telefono = txtTelefonoBook.Text;

                cli.AgregarEntidad(c);
            }
            catch (Exception)
            {

                MessageBox.Show("Cliente ya existe en la base de datos");
            }


            try
            {
                r.IdReserva = DateTime.Now.ToString("yyyyMMddHHmm");
                r.RutCliente = rutCliente;
                r.FechaIngreso = dpLlegadaBook.Text;
                r.FechaSalida = dpSalidaBook.Text;
                r.TipoHabitacion = comboTipoHabitacionBook.Text;
                r.CantHuespedes = comboCantPersonasBook.SelectedIndex;
                NumReserva = r.IdReserva;
                res.AgregarEntidad(r);
                MessageBox.Show("Reserva exitosa\n" + "Numero Reserva :" + NumReserva, "Hotel Harmann");
                LimpiarVentanaReserva();
                tabControl.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Reserva ya existe en la base de datos");
            }

            
        }

        private void LimpiarVentanaReserva()
        {
            txtRutClienteBook.Text = string.Empty;
            txtNombreBook.Text = string.Empty;
            txtApellidosBook.Text = string.Empty;
            txtEmailBook.Text = string.Empty;
            txtDireccionBook.Text = string.Empty;
            txtTelefonoBook.Text = string.Empty;
            comboTipoHabitacionBook.Text = string.Empty;
            comboCantPersonasBook.SelectedIndex = -1;
            dpLlegadaBook.SelectedDate = DateTime.Today;
            dpSalidaBook.SelectedDate = DateTime.Today;
        }


        #endregion Reservar Hotel

        #region Portal Admnistracion

        private void BtnIngresarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreUsuario.Text == string.Empty || txtContraseña.Password == string.Empty)
            {
                MessageBox.Show("No deben haber campos vacios", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                if (txtNombreUsuario.Text != "admin" || txtContraseña.Password != "123")
                {
                    MessageBox.Show("Los datos igresados son incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
                else
                {
                    if (txtNombreUsuario.Text == "admin" || txtContraseña.Password == "123")
                    {

                        InicioVentanaOn();
                        txtNombreUsuario.Text = string.Empty;
                        txtContraseña.Password = string.Empty;


                    }
                }
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
                ServiceCliente cli = new ServiceCliente();
                Cliente c = new Cliente();
                ServiceReserva res = new ServiceReserva();
                Reserva r = new Reserva();

            
                c.RutCliente = txtRutCliente.Text;
                rutCliente = c.RutCliente;
                c.Nombre = txtNomCliente.Text;
                c.Apellidos = txtApeCliente.Text;
                c.Email = txtEmail.Text;
                c.Telefono = txtTelefono.Text;
                c.Direccion = direccion;

                r.IdReserva = txtIdReserva.Text;
                r.FechaIngreso = txtFechaIngreso.Text;
                r.FechaSalida = txtFechaSalida.Text;
                r.RutCliente = rutCliente;
                r.TipoHabitacion = comboTipo.Text;
                r.CantHuespedes = comboCantPer.SelectedIndex;

            try
            {
                cli.ActualizarEntidad(c);
                res.ActualizarEntidad(r);
                MessageBox.Show("Reserva modificada con exito");
                LimpiarBtnsAdmReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBuscarPorNumero_Click(object sender, RoutedEventArgs e)
        {
            HotelEntities bbdd = new HotelEntities();

            try
            {
                CargarBusquedaxIdReserva(bbdd);
            }
            catch (Exception)
            {
                MessageBox.Show("Numero de Reserva no existe", "Atencion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            

        }
       
        private void BtnBuscarPorRut_Click(object sender, RoutedEventArgs e)
        {
            HotelEntities bbdd = new HotelEntities();

            try
            {
                CargarBusquedaxPorRut(bbdd);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Reserva no existe", "Atencion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void InicioVentanaOff()
        {
            txtRutBusqueda.IsEnabled = false;
            btnBuscarPorRut.IsEnabled = false;
            txtIdReservaBusqueda.IsEnabled = false;
            btnBuscarPorNumero.IsEnabled = false;
            txtIdReserva.IsEnabled = false;
            txtFechaIngreso.IsEnabled = false;
            txtFechaSalida.IsEnabled = false;
            txtRutCliente.IsEnabled = false;
            comboTipo.IsEnabled = false;
            comboCantPer.IsEnabled = false;
            txtNomCliente.IsEnabled = false;
            txtApeCliente.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtTelefono.IsEnabled = false;
        }

        private void InicioVentanaOn()
        {
            txtRutBusqueda.IsEnabled = true;
            btnBuscarPorRut.IsEnabled = true;
            txtIdReservaBusqueda.IsEnabled = true;
            btnBuscarPorNumero.IsEnabled = true;
            txtIdReserva.IsEnabled = true;
            txtFechaIngreso.IsEnabled = true;
            txtFechaSalida.IsEnabled = true;
            txtRutCliente.IsEnabled = true;
            comboTipo.IsEnabled = true;
            comboCantPer.IsEnabled = true;
            txtNomCliente.IsEnabled = true;
            txtApeCliente.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtTelefono.IsEnabled = true;
        }

        private void CargarBusquedaxPorRut(HotelEntities bbdd)
        {
            Reserva res = bbdd.Reserva.Where(c => c.RutCliente == txtRutBusqueda.Text).First<Reserva>();
            txtRutBusqueda.Text = res.RutCliente;


            Cliente cl = bbdd.Cliente.Where(c => c.RutCliente == txtRutBusqueda.Text).First<Cliente>();

            txtNomCliente.Text = cl.Nombre;
            txtApeCliente.Text = cl.Apellidos;
            txtEmail.Text = cl.Email;
            txtTelefono.Text = cl.Telefono;

            txtIdReserva.Text = res.IdReserva;
            txtRutCliente.Text = res.RutCliente;
            txtFechaIngreso.Text = res.FechaIngreso;
            txtFechaSalida.Text = res.FechaSalida;
            comboTipo.Text = res.TipoHabitacion;
            comboCantPer.Text = res.CantHuespedes.ToString();

            txtRutBusqueda.Text = string.Empty;
        }

        private void CargarBusquedaxIdReserva(HotelEntities bbdd)
        {
            Reserva res = bbdd.Reserva.Where(c => c.IdReserva == txtIdReservaBusqueda.Text).First<Reserva>();

            txtIdReserva.Text = res.IdReserva;
            txtRutCliente.Text = res.RutCliente;
            txtFechaIngreso.Text = res.FechaIngreso;
            txtFechaSalida.Text = res.FechaSalida;
            comboTipo.Text = res.TipoHabitacion;
            comboCantPer.Text = res.CantHuespedes.ToString();

            Cliente cli = bbdd.Cliente.Where(c => c.RutCliente == txtRutCliente.Text).First<Cliente>();

            txtNomCliente.Text = cli.Nombre;
            txtApeCliente.Text = cli.Apellidos;
            txtEmail.Text = cli.Email;
            txtTelefono.Text = cli.Telefono;

            txtIdReservaBusqueda.Text = string.Empty;
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarBtnsAdmReservas();

        }

        private void LimpiarBtnsAdmReservas()
        {
            txtIdReserva.Text = string.Empty;
            txtFechaIngreso.Text = string.Empty;
            txtFechaSalida.Text = string.Empty;
            txtRutCliente.Text = string.Empty;
            comboTipo.Text = string.Empty;
            comboCantPer.SelectedIndex = -1;
            txtNomCliente.Text = string.Empty;
            txtApeCliente.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ServiceCliente cli = new ServiceCliente();
            ServiceReserva res = new ServiceReserva();

            try
            {
                MessageBox.Show("Reserva eliminada con exito\n" + " N° Reserva : " + txtIdReserva.Text, "Hotel Harmann");
                cli.EliminarEntidad(txtRutCliente.Text);
                res.EliminarEntidad(txtIdReserva.Text);

                LimpiarBtnsAdmReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        #endregion Portal Administracion

        private void BtnHotel_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void BtnHotel_Copy1_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void BtnReservarAhora_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }
    }
}
