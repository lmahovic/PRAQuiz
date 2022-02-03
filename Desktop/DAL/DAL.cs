using PRAQuiz.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandType = PRAQuiz.DAL.CommandType;

namespace PRAQuiz.DAL
{
  public  class DAL
    {

        public static DataTable ExecuteReader(string commandText, CommandType cmdType, params Parameter[] parameters)
        {
            DataTable tbl = new DataTable();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    if (cmdType == CommandType.SQL)
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                    }
                    else
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Naziv, param.Value);
                    }

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            tbl.Load(r);
                        }
                    }
                }
            }
            return tbl;
        }


        public static int AddEntity(string commandText, params Parameter[] parameters) // poziva storanu proceduru tipa Add i vraća Scope_Identity() kao ID
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Naziv, param.Value);
                    }

                    var returnParameter = cmd.Parameters.Add("@Return", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    return (int)(returnParameter.Value);
                }
            }
        }


        public static void ExecuteCommand(string commandText, params Parameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Naziv, param.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static string GetConnectionString()
        {
            //SQL USER INFORMACIJE ZA SPAJANJE

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.InitialCatalog = "PRA_Quiz";
            csb.DataSource = ".\\SQLEXPRESS";
            csb.IntegratedSecurity = true;

            return csb.ConnectionString;
        }
    }
}
