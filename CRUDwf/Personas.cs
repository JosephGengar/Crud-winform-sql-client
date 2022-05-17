using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDwf
{
    public class Personas
    {
        private string connectionString = "Data Source=.;Initial Catalog=AgendaNueva;Integrated Security=True";
    
        public bool Ok()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public List<PersonasModel> Obtener()
        {
            List<PersonasModel> personasGet = new List<PersonasModel>();
            string query = "select ID, nombre, apellido from tContacto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        PersonasModel oPersonasM = new PersonasModel();
                        oPersonasM.Id = reader.GetInt32(0);
                        oPersonasM.Nombre = reader.GetString(1);
                        oPersonasM.Apellido = reader.GetString(2);
                        personasGet.Add(oPersonasM);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error" + ex.Message);
                }
            }
            return personasGet;
        }

        //necesito una lista que devuelva un elemento para meter
        //informacion al dialog asi q copia el metodo obtener:

        public PersonasModel Obtener(int id)
        {
            string query = "select ID, nombre, apellido from tContacto" + " where ID=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();                  
                        PersonasModel oPersonasM = new PersonasModel();
                        oPersonasM.Id = reader.GetInt32(0);
                        oPersonasM.Nombre = reader.GetString(1);
                        oPersonasM.Apellido = reader.GetString(2);                                     
                    reader.Close();
                    connection.Close();
                    return oPersonasM;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error" + ex.Message);
                }
            }

        }


        public void Agregar(string FirstName, string LastName)
        {
            // a traves de @ evitamos la sql inyeccion mediante alias
            string query = "insert into tContacto(nombre, apellido) values" + "(@FirstName, @LastName)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                  
                }
                catch (Exception ex)
                {

                    throw new Exception("Error" + ex.Message);
                }
            }         
        }
        public void Editar(string FirstName, string LastName, int id)
        {
            // a traves de @ evitamos la sql inyeccion mediante alias
            string query = "update tContacto set nombre=@FirstName, apellido=@LastName" + " where ID=@id " ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception ex)
                {

                    throw new Exception("Error" + ex.Message);
                }
            }
        }

        public void Borrar(int id)
        {
            // a traves de @ evitamos la sql inyeccion mediante alias
            string query = "delete from tContacto" + " where ID=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error" + ex.Message);
                }
            }
        }
    }
    public class PersonasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
