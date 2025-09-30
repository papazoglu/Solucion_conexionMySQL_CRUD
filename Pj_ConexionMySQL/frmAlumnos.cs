using MySql.Data.MySqlClient;
using Repository;
using System.Configuration;
using System.Data;

namespace Pj_ConexionMySQL
{

    public partial class frmAlumnos : Form
    {
        //variables de clase (globales)
        //public MySqlConnection conexion;
        DataTable tabla;
       

        public frmAlumnos()
        {
            InitializeComponent();
            //String cadenaConexion = "server=localhost;user=root;password=root;database=lenguaje1";
            //conexion = new MySqlConnection(cadenaConexion);

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader dataReader = null;
                var sqlConn = new MySqlConnection();
                sqlConn = Conexion.getInstancia("root", "root").CrearConexion();
                sqlConn.Open();

                String query = "SELECT * FROM alumnos";
                MySqlCommand comando = new MySqlCommand(query, sqlConn);
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
                var sqlConn=new MySqlConnection();
                sqlConn = Conexion.getInstancia("root", "root").CrearConexion();
                sqlConn.Open();

                String query = "select * from alumnos";
                MySqlCommand comando = new MySqlCommand(query, sqlConn);
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
                vista.RowFilter = "nombre LIKE '%" + this.txtBuscar.Text + "%'";
                //vista.RowFilter = "id = " + this.txtBuscar.Text;
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

                    Form alumno = new frmAlumnosForm(id, nombre, dni,2,this);
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

            Form alumno = new frmAlumnosForm(1,this);
            alumno.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eliminarAlumno(this.dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            obtenerTodos();
        }

        private void eliminarAlumno(string id)
        {
            
            DialogResult a = MessageBox.Show("Esta seguro que desea eliminar al alumno?","Sistema alumnado",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(a == DialogResult.Yes)
            {
                using (var sqlConn = Conexion.getInstancia("root", "root").CrearConexion())
                {
                    sqlConn.Open();

                    string query = "delete from alumnos where id=" + id;
                    MySqlCommand comando = new MySqlCommand(query, sqlConn);
                    int resul = comando.ExecuteNonQuery();
                    MessageBox.Show($"La consulta devolvio: {resul}");
                }
                
            }

            
        }

        private void frmAlumnosLista_Load(object sender, EventArgs e)
        {
         
            try
            {
                //conexion.Open();
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
                //var sqlConn = new MySqlConnection();
                //using llama a Dispose() es decir cierra la conexión automaticamente
                //no hace falta sqlConn.Close(); 
                using (var sqlConn = Conexion.getInstancia("root", "root").CrearConexion())
                {
                    sqlConn.Open();

                    String query = "select * from alumnos";
                    MySqlCommand comando = new MySqlCommand(query, sqlConn);
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Revise el usuario y contraseña de la base de datos");
            }
            finally
            {
                
            }
        }
    }
}
