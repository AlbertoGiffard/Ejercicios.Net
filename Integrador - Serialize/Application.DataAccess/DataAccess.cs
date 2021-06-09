using Application.Models;
using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess
{
    public static class DataAccess
    {
        private static CustomerRepository customerRepository;
        public static List<Customer> GetCustomers()
        {
            StringBuilder sb = new StringBuilder();
            List<Customer> listado = new List<Customer>();
            //Registro la data de la base de datos
            String conexionStr = @"Data Source = LAPTOP-ALBERTO-; Initial Catalog = TestTable; Integrated Security = True";

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionStr))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Connection = conexion;

                    comando.CommandText = "SELECT * FROM Customers";

                    conexion.Open();

                    SqlDataReader dataReader = comando.ExecuteReader();

                    while (dataReader.Read())
                    {                        
                        listado.Add(new Customer(dataReader["Nombre"].ToString(), dataReader["Apellido"].ToString(), Convert.ToInt32(dataReader["Age"])));
                    }

                    dataReader.Close();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return listado;
        }

        public static Customer GetCustomerById(int id)
        {
            StringBuilder sb = new StringBuilder();
            Customer customer = null;
            //Registro la data de la base de datos
            String conexionStr = @"Data Source = LAPTOP-ALBERTO-; Initial Catalog = TestTable; Integrated Security = True";

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionStr))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Connection = conexion;

                    comando.CommandText = $"SELECT * FROM Customers WHERE ID = {id}";

                    conexion.Open();

                    SqlDataReader dataReader = comando.ExecuteReader();

                    while (dataReader.Read())
                    {
                        customer = new Customer(dataReader["Nombre"].ToString(), dataReader["Apellido"].ToString(), Convert.ToInt32(dataReader["Age"]));
                    }

                    dataReader.Close();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return customer;
        }
    }
}
