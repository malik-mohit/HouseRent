using Dapper;
using Microsoft.Data.SqlClient;
using Model;
using ServiceLayer.Interface;
using System.Data;

namespace ServiceLayer.Services
{
    public class CommonService : ConnectionManager, ICommonService
    {
        public CommonService(string dbConnection) : base(dbConnection)
        {

        }

        public List<StateModel> GetStateList()
        {
            List<StateModel> states = new();
            try
            {
                using (SqlConnection connection = GetSqlConnection())
                {
                    string storedProcName = "dbo.GetStateList";
                    connection.Open();
                    var reader = connection.ExecuteReader(storedProcName,commandType:CommandType.StoredProcedure);
                    while (reader.Read())
                    {
                        states.Add(new StateModel
                        {
                            StateId = Convert.ToInt32(reader["StateId"]),
                            StateName = reader["StateName"].ToString()

                        });
                    }

                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                //handle exception
            }

            return states;
        }




        public List<CityModel> GetCityList(int StateId)
        {
            List<CityModel> city = new();
            var parameter = new DynamicParameters();
            parameter.Add("@StateId", StateId, DbType.Int32, ParameterDirection.Input);
            string storedProcName = "dbo.GetCityList";
            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();
                var reader = connection.ExecuteReader(storedProcName,parameter,commandType:CommandType.StoredProcedure);
                {
                    while (reader.Read())
                    {
                        city.Add(new CityModel
                        {
                            CityId = Convert.ToInt32(reader["CityId"]),
                            CityName = reader["CityName"].ToString(),
                            StateId = Convert.ToInt32(reader["StateId"])

                        });
                    }
                }
                connection.Close();

            }

            return city;
        }
    }
}
