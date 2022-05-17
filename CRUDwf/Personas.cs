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
        
    }
    public class PersonasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
