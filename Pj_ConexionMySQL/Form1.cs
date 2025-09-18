using MySql.Data.MySqlClient;
using System.Data;

namespace Pj_ConexionMySQL
{

    public partial class frmAlumnos : Form
    {
        //variables de clase (globales)
        public MySqlConnection conexion;
        DataTable tabla;
       

        public frmAlumnos()
        {
            InitializeComponent();
            String cadenaConexion = "server=localhost;user=root;password=root;database=lenguaje1";
            conexion = new MySqlConnection(cadenaConexion);

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "SELECT * FROM alumnos";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex.Message);
                return;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from alumnos";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                tabla = new DataTable();
                tabla.Load(reader);
                dataGridView1.DataSource = tabla;
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader["nombre"].ToString());
                //    MessageBox.Show(reader["nombre"].ToString());   
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Revise el usuario y contraseña de la base de datos");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView vista = new DataView(tabla);
            //vista.RowFilter = "nombre LIKE '%" + this.textBox1.Text + "%'";
            if (string.IsNullOrEmpty(this.txtBuscar.Text))
                vista.RowFilter = "";
            else
            {
                vista.RowFilter = "id = " + this.txtBuscar.Text;
            }
            
            //vista.RowFilter = "Convert(id, 'System.String') LIKE '%" + this.textBox1.Text + "%'";

            if (vista.Count > 0)
            {
                String id = vista[0]["id"].ToString();
                String nombre = vista[0]["nombre"].ToString() ?? "";
                int dni = Convert.ToInt32(vista[0]["dni"]);
                MessageBox.Show($"Id: {id} - Nombre: {nombre} - DNI: {dni}");
            }

            dataGridView1.DataSource = vista;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentRow != null)
                {
                    String nombre = this.dataGridView1.CurrentRow.Cells["nombre"].Value?.ToString() ?? "";
                    String dni = this.dataGridView1.CurrentRow.Cells["dni"].Value?.ToString() ?? "";
                    int id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["id"].Value);
                    MessageBox.Show($"nombre seleccionado: {nombre}");

                    Form alumno = new frmAlumnosForm(conexion, id, nombre, dni,2);
                    alumno.Show();
                }
                else
                {
                    MessageBox.Show("no hay filas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //String nombre = this.dataGridView1.CurrentRow.Cells["nombre"].Value?.ToString() ?? "";
            //String dni = this.dataGridView1.CurrentRow.Cells["dni"].Value?.ToString() ?? "";
            //int id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["id"].Value);
            //MessageBox.Show($"nombre seleccionado: {nombre}");

            Form alumno = new frmAlumnosForm(conexion, 1,this);
            alumno.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            string query = "delete from alumnos where id=" + id;
            MySqlCommand comando = new MySqlCommand(query, conexion);
            int resul = comando.ExecuteNonQuery();
            MessageBox.Show($"La consulta devolvio: {resul}");
            obtenerTodos();
        }

        private void frmAlumnosLista_Load(object sender, EventArgs e)
        {
         
            try
            {
                conexion.Open();
                this.txtBuscar.Enabled = true;
                obtenerTodos();//nada
                //MessageBox.Show("Conexión exitosa");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        public void obtenerTodos()
        {
            try
            {
                String query = "select * from alumnos";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                tabla = new DataTable();
                tabla.Load(reader);
                dataGridView1.DataSource = tabla;
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader["nombre"].ToString());
                //    MessageBox.Show(reader["nombre"].ToString());   
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Revise el usuario y contraseña de la base de datos");
            }
        }
    }
}
