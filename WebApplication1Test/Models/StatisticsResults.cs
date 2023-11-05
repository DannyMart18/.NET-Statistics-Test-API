namespace WebApplication1Test.Models;

public class StatisticsResults
{
    public int Sum { get; set; }
    public double Average { get; set; }
    public double Median { get; set; }
    public int Mode { get; set; }
    
}
/*Sum: A property to hold the total of all numbers in the list.
   Average: A property for the average value of the list, which could be a floating-point number, even if the list contains integers.
   Median: A property for the median value. Remember, the median must account for both even and odd-sized lists.
   Mode: This can be tricky since there can be more than one mode. You can decide to return only one mode or modify your model to return a list of modes.*/