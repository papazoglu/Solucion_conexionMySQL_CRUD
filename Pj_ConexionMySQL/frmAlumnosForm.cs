using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pj_ConexionMySQL
{
    public partial class frmAlumnosForm : Form
    {
        private MySqlConnection _coneccion;
        int _accion;
        private frmAlumnos _form1;


        public frmAlumnosForm(MySqlConnection con, int accion, frmAlumnos form1)
        {
            InitializeComponent();
            _accion = accion;
            _coneccion = con;
            this._form1 = form1;
        }

        public frmAlumnosForm(MySqlConnection conexionActual, int id, String nombre, String dni, int accion, frmAlumnos form1)
        {
            InitializeComponent();
            this._coneccion = conexionActual;
            this.txtNombre.Text = nombre;
            this.txtDni.Text = dni;
            this.txtId.Text = Convert.ToString(id);
            _accion = accion;
            this._form1 = form1;


            //this.textBox2.Text = nombre;
        }

        private void frmAlumnos_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //_coneccion.Open();
            if (_accion == 1)
            {
                string query = "insert into alumnos(nombre,dni)values(@nombre,@dni);";
                MySqlCommand comando = new MySqlCommand(query, _coneccion);
                //comando.Parameters.AddWithValue("@id", Convert.ToInt32(this.label3.Text) + 10);
                comando.Parameters.AddWithValue("@nombre", this.txtNombre.Text);
                comando.Parameters.AddWithValue("@dni", this.txtDni.Text);
                int resul = comando.ExecuteNonQuery();
                MessageBox.Show($"La consulta devolvio: {resul}");
            }
            else
            {
                string query = "update alumnos set nombre=@nombre, dni=@dni where id=@id";
                MySqlCommand comando = new MySqlCommand(query, _coneccion);
                comando.Parameters.AddWithValue("@id", this.txtId.Text);
                comando.Parameters.AddWithValue("@nombre", this.txtNombre.Text);
                comando.Parameters.AddWithValue("@dni", this.txtDni.Text);
                int resul = comando.ExecuteNonQuery();
                MessageBox.Show($"La consulta devolvio: {resul}");
            }
            this._form1.obtenerTodos();
            this.Close();

        }

        private void frmAlumnosForm_Shown(object sender, EventArgs e)
        {
            this.txtDni.Focus();
        }
              

        
    }
}
