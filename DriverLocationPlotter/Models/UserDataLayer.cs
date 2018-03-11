using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DriverLocationPlotter.Infrastructure;

namespace DriverLocationPlotter.Models
{
    public class UserDataLayer
    {

        public bool UserAuthenticate(string Username,string Password)
        {
           
            using (SqlConnection con = new SqlConnection(SqlConnect.GetConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from AddDriver Where DriverName=@Username and Password=@Password", con);
                    cmd.Parameters.AddWithValue("@Username",Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    return rdr.HasRows;
                }
                catch (Exception)
                {
                    
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}