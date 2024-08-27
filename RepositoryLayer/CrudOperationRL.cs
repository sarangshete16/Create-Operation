using Crud_Operations.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Crud_Operations.RepositoryLayer
{
    public class CrudOperationRL : ICrudOperationRL
    {
        public readonly SqlConnection _sqlConnection;
        public readonly IConfiguration _configuration;

        public CrudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]);


        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "successful";
            try
            {
                string SqlQuery = "Insert Into CrudOperationTable (UserName, Age) values (@UserName, @Age)";
                using(SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "something went wrong";
                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally { _sqlConnection.Close(); } 
            return response;
        }
    }
}
