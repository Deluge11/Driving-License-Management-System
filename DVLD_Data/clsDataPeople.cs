using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDataPeople
    {

        public static bool GetPersonById(int id, out stPersonInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE PersonID = @Id";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", id);

            info = new stPersonInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.Id = (int)reader["PersonID"];
                    info.NationalNo = (string)reader["NationalNo"];
                    info.FirstName = (string)reader["FirstName"];
                    info.SecondName = (string)reader["SecondName"];
                    info.ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : null;
                    info.LastName = (string)reader["LastName"];
                    info.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    info.Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null;
                    info.Address = (string)reader["Address"];
                    info.NationalityCountryId = (int)reader["NationalityCountryId"];
                    info.Phone = (string)reader["Phone"];
                    info.ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;
                    info.Gender = (byte)reader["Gender"];

                    isFound = true;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isFound;
        }
        public static bool Update(stPersonInfo info)
        {
            bool isFound = false;
            string query = "UPDATE People SET ";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            info = new stPersonInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

              

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isFound;
        }

    }
}
