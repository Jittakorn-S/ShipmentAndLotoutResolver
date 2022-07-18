using System.Data;
using System.Data.SqlClient;

namespace ShipmentAndLotoutResolver.Models
{
    public class UserRepository : InterfaceUser
    {
        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public UserModel? UserLogin(string UserName)
        {
            using var con = new SqlConnection(configuration.GetConnectionString("DBConnection"));
            try
            {
                UserModel userModel = new();
                con.Open();
                SqlCommand command = new("SelectUser_Authority_table", con);
                command.Parameters.AddWithValue("User_name", UserName);
                if (UserName == null)
                {
                    return null;
                }
                else
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            userModel.User_name = (string)dataReader["user_name"];
                            userModel.Full_name = (string)dataReader["full_name"];
                        }
                        con.Close();
                        return userModel;
                    }
                    else
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
