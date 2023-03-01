using Dapper;
using Microsoft.Data.SqlClient;
using Model;
using ServiceLayer.Interface;
using System.Data;

namespace ServiceLayer.Services
{
    public class UserService : ConnectionManager, IUserService
    {
        public UserService(string dbConnection) : base(dbConnection)
        {


        }

        public bool UserAlreadyExists(string Email)
        {

            string storedProcName = "dbo.UserAlreadyExists";
            int result = -1;
            var parameter = new DynamicParameters();

            parameter.Add("@Email", Email, DbType.String, ParameterDirection.Input);
            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        result = connection.ExecuteScalar<int>(storedProcName, parameter, commandType: CommandType.StoredProcedure);
                        connection.Close();


                    }
                }
            }
            catch (Exception ex)
            {

            }


            if (result > 0)
            {
                return true;
            }
            return false;
        }



        public CustomerModel AddCustomerDetails(CustomerModel customer)
        {
            string storedProcName = "dbo.AddCustomer";
            var parameter = new DynamicParameters();
            parameter.Add("@Name", customer.Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", customer.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Password", customer.Password, DbType.String, ParameterDirection.Input);
            parameter.Add("@Mobile", customer.Mobile, DbType.Int64, ParameterDirection.Input);
            parameter.Add("@Gender", customer.Gender, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", customer.Address, DbType.String, ParameterDirection.Input);
            parameter.Add("@StateId", customer.StateId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@CityId", customer.CityId, DbType.Int32, ParameterDirection.Input);
            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        var obj = connection.ExecuteScalar(storedProcName, parameter, commandType: CommandType.StoredProcedure);

                    }
                }
            }
            catch (Exception ex)
            {
                //handle exception
            }


            return customer;
        }

        public CustomerModel AuthenticateUser(string Email, string Password)
        {
            CustomerModel customer = new();
            string storedProcName = "dbo.AuthenticateUser";
            var parameter = new DynamicParameters();
            parameter.Add("@Email", Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Password", Password, DbType.String, ParameterDirection.Input);

            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        var obj = connection.Query(storedProcName, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                        if (obj != null)
                            customer = new CustomerModel
                            {
                                CustomerId = obj.CustomerId,
                                Name = obj.Name,
                                Email = obj.Email,
                                Mobile = obj.Mobile,
                                Gender = obj.Gender,
                                Address = obj.Address,
                                Role = obj.Role,
                                RoleId = obj.RoleId,
                                StateId = obj.StateId,
                                CityId = obj.CityId,
                                UserStatus = obj.UserStatus,
                                CreatedAt = obj.CreatedAt,

                            };

                    }
                }
            }
            catch (Exception ex)
            {
                //handle exception
            }


            return customer;
        }


    }
}


