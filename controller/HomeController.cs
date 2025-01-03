using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private static List<string> ViolationLogs = new List<string>();

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok(new { status = "Safe Browser đang hoạt động", timestamp = DateTime.Now });
    }

    [HttpPost("report")]
    public IActionResult ReportViolation([FromBody] ViolationReport report)
    {
        string log = $"[{DateTime.Now}] Vi phạm: {report.Activity}";
        ViolationLogs.Add(log);
        Console.WriteLine(log);
        return Ok(new { message = "Vi phạm đã được ghi nhận." });
    }

    [HttpGet("violations")]
    public IActionResult GetViolations()
    {
        return Ok(ViolationLogs);
    }
}

public class ViolationReport
{
    public string Activity { get; set; }
    public DateTime Timestamp { get; set; }
}