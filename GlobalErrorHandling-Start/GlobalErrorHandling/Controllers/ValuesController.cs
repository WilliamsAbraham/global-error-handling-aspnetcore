using System;
using System.Collections.Generic;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILoggerManager _logger;
        public ValuesController(ILoggerManager logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                _logger.LogInfo("Fetching All students");
                var students = DataManager.GetAllStudents();
                _logger.LogInfo($"Returning {students.Count} students");
                return Ok(students);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal Server Error");
            }


           
        }
    }
}