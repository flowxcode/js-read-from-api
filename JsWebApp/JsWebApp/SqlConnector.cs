using System;
using System.Data;
using System.Data.SqlClient;
using JsWebApp.Model;

namespace JsWebApp
{
    public class SqlConnector : ISqlConnector
    {
        public readonly string connectionString = "Data Source=VMWM\\SQLEXPRESS;Initial Catalog=restDB;Integrated Security=SSPI"; 

        public List<Car> ReadCarData()
        {
            string queryString = "SELECT ID, Name FROM dbo.Cars;";

            List<Car> carList = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    carList.Add(new Car()
                    {
                        ID = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1)
                    });
                }
                reader.Close();
            }

            return carList;
        }
    }
}
