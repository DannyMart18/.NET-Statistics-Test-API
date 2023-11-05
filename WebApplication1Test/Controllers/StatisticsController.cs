using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication1Test.Models;

namespace WebApplication1Test.Controllers;

[ApiController]
[Route("[controller]")]
public class StatisticsController: ControllerBase
{
    [HttpPost(Name = "PostStatistics")]
    public ActionResult<StatisticsResults> Post([FromBody] StatisticsInput input)
    {
        if(input.Numbers == null || !input.Numbers.Any())
        {
            return BadRequest();
        }
        
        var sortedNumbers = input.Numbers.OrderBy(x => x).ToList();
        var count = sortedNumbers.Count;
        
        var sum = sortedNumbers.Sum();
        var average = (double)sum / count; // Cast to double to ensure floating-point division.
        
        var median = count % 2 == 0
            ? (sortedNumbers[count / 2 - 1] + sortedNumbers[count / 2]) / 2.0
            : sortedNumbers[count / 2];

        var mode = sortedNumbers
            .GroupBy(n => n)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .FirstOrDefault()
            ?.Key ?? sortedNumbers.First(); // Simple mode calculation (returns one of the modes if multiple)

        
        return new StatisticsResults 
        {
            Sum = sum,
            Average = average,
            Median = median,
            Mode = mode
        };


        
    }


}