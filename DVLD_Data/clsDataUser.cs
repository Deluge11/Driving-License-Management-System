using DVLD_Data.InfoStructs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsDataUser
    {
        public static DataTable GetAll()
        {
            string query =
@"SELECT 
UserID,
P.PersonID,
P.FirstName + ' '+ P.SecondName +' '+ P.LastName AS FullName,
UserName,
IsActive 
FROM Users U
INNER JOIN People P ON P.PersonID = U.PersonID";

            SqlConnection connection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand command = new SqlCommand(query, connection);

            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetById(int id, out stUserInfo info)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Users WHERE UserID = @UserID";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@UserID", id);

            info = new stUserInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.UserID = (int)reader["UserID"];
                    info.PersonID = (int)reader["PersonID"];
                    info.UserName = (string)reader["UserName"];
                    info.Password = (string)reader["Password"];
                    info.IsActive = (bool)reader["IsActive"];

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

        public static bool Exists(int id)
        {
            bool isFound = false;
            string query = @"SELECT 1 FROM Users WHERE UserID = @Id";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", id);

            try
            {
                sqlConnection.Open();
                isFound = sqlCommand.ExecuteScalar() != null;
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

        public static bool Get(string username, string password, out stUserInfo info)
        {
            bool isFound = false;
            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@UserName", username);
            sqlCommand.Parameters.AddWithValue("@Password", password);

            info = new stUserInfo();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    info.UserID = (int)reader["UserID"];
                    info.PersonID = (int)reader["PersonID"];
                    info.UserName = (string)reader["UserName"];
                    info.Password = (string)reader["Password"];
                    info.IsActive = (bool)reader["IsActive"];

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

        public static bool Update(stUserInfo info)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE Users SET
                UserName = @UserName,
                Password = @Password,
                IsActive = @IsActive
                WHERE UserID = @UserID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@UserID", info.UserID);
            sqlCommand.Parameters.AddWithValue("@UserName", info.UserName);
            sqlCommand.Parameters.AddWithValue("@Password", info.Password);
            sqlCommand.Parameters.AddWithValue("@IsActive", info.IsActive);

            try
            {
                sqlConnection.Open();
                isUpdated = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isUpdated;
        }

        public static bool Add(stUserInfo info, out int userID)
        {
            userID = -1;

            bool isInserted = false;
            string query = @"
                INSERT INTO Users
                (
                PersonID,
                UserName,
                Password,
                IsActive                
                )
                VALUES
                (
                @PersonID,
                @UserName,
                @Password,
                @IsActive
                );
                SELECT SCOPE_IDENTITY();";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@PersonID", info.PersonID);
            sqlCommand.Parameters.AddWithValue("@UserName", info.UserName);
            sqlCommand.Parameters.AddWithValue("@Password", info.Password);
            sqlCommand.Parameters.AddWithValue("@IsActive", info.IsActive);

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null || result != DBNull.Value)
                {
                    userID = Convert.ToInt32(result);
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isInserted = false;
            }
            finally
            {
                sqlConnection.Close();
            }


            return isInserted;
        }

        public static bool Delete(int userID)
        {
            bool isDeleted = false;

            string query = "DELETE FROM Users WHERE userID=@userID";

            SqlConnection sqlConnection = new SqlConnection(ConnectionStrings.Default);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@userID", userID);

            try
            {
                sqlConnection.Open();
                isDeleted = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            return isDeleted;
        }
    }
}
