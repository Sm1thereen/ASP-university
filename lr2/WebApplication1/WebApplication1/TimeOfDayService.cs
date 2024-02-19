using WebApplication1;
public class TimeOfDayService
{
    public string GetTimeOfDay()
    {
        var currentTime = DateTime.Now.Hour;
        if (currentTime >= 6 && currentTime < 12)
        {
            return "ранок";
        }
        else if (currentTime >= 12 && currentTime < 18)
        {
            return "день";
        }
        else if (currentTime >= 18 && currentTime < 24)
        {
            return "вечір";
        }
        else
        {
            return "ніч";
        }
    }
}