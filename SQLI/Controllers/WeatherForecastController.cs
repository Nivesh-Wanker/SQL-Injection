using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SQLI.DTO;
using SQLI.Models;

namespace SQLI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly JarvisContext _context;
        private readonly String connectionString = "Data Source=JARVIS;Initial Catalog=Jarvis;Integrated Security=True;Trust Server Certificate=True";
        public WeatherForecastController(ILogger<WeatherForecastController> logger,JarvisContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetUser")]
        public List<TestDTO> GetUser(String s,int id)
        {
            List<TestDTO> testDTO = new List<TestDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Test WHERE Name= '" + s + "' and id"+id;
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TestDTO test = new TestDTO();
                        test.Id = reader.GetInt32(0);
                        test.Name = reader.GetString(1);
                        test.Created = reader.GetDateTime(2); 
                        testDTO.Add(test);
                        Console.WriteLine($"Id: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, DateTime: {reader.GetDateTime(2)}");
                    }
                }
            }
            //List<Test> test = _context.Tests.ToList();
            return testDTO;
        }
        //[HttpGet("ValidUserCreds")]
        //public List<TestDTO> ValidUserCreds(String s)
        //{
        //    List<TestDTO> testDTO = new List<TestDTO>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string sql = "SELECT * FROM Test WHERE Name= '" + s + "'";
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                TestDTO test = new TestDTO();
        //                test.Id = reader.GetInt32(0);
        //                test.Name = reader.GetString(1);
        //                test.Created = reader.GetDateTime(2);
        //                testDTO.Add(test);
        //                Console.WriteLine($"Id: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, DateTime: {reader.GetDateTime(2)}");
        //            }
        //        }
        //    }
        //    //List<Test> test = _context.Tests.ToList();
        //    return testDTO;
        //}
    }
}


