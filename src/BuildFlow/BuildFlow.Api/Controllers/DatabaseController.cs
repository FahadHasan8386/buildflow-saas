using BuildFlow.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DatabaseController(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        [HttpGet("test")]
        public IActionResult TestConnection()
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                connection.Open();

                return Ok(new
                {
                    Success = true,
                    Message = "Database connected successfully!"
                });
            }
            catch
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Database connection failed."
                });
            }
        }
    }
}
