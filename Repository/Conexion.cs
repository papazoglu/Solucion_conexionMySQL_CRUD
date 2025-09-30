using MySql.Data.MySqlClient;

namespace Repository
{
    public class Conexion
    {
        //atributos
        private string _base_de_datos;
        private string _servidor;
        private string _puerto;
        private string _usuario;
        private string _password;

        //variable o atributo de clase, accesible por todas la instancias de Conexion
        private static Conexion conn = null;

        //constructores
        private Conexion()
        {
            this._servidor = "localhost";
            this._base_de_datos = "lenguaje1";
            this._puerto = "3306";
            this._usuario = "root";
            this._password = "root";
        }
        private Conexion(string user, string pass)
        {
            this._servidor = "localhost";
            this._base_de_datos = "lenguaje1";
            this._puerto = "3306";
            this._usuario = user;
            this._password = pass;
        }

        //metodo que devuelve un objeto MySqlConnection inicializado listo para abrir y hacer consultas a la BD
        public MySqlConnection CrearConexion()
        {
            var cadena = new MySqlConnection();
            cadena.ConnectionString = "Host=" + this._servidor +
                                      "; User=" + this._usuario +
                                      ";password=" + this._password +
                                      ";database=" + this._base_de_datos;
            return cadena;
        }

        public static Conexion getInstancia(string a, string b)
        {
            if (conn == null)
            {
                conn = new Conexion(a, b);
            }
            return conn;
        }


    }
}
