using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
    }

    [HttpPost("violation")]
    public IActionResult LogViolation([FromBody] ViolationLog log)
    {
        if (log == null || string.IsNullOrEmpty(log.Violation))
        {
            return BadRequest("Invalid log data.");
        }

        _logger.LogWarning($"Security Violation Detected: {log.Violation}");
        return Ok(new { message = "Violation logged successfully." });
    }

    public class ViolationLog
    {
        public string Violation { get; set; }
    }
}