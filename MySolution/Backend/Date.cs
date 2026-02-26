namespace Backend;

public class Date
{
    // These are the private fields for the Date class, they are used to store the values of the year, month and day.
    private int _year;
    private int _month;
    private int _day;


    //this is the default constructor for the Date class, it initializes the year to 1900, month to 1 and day to 1.
    public Date()
    {
        _year = 1900;
        _month = 1;
        _day = 1;
    }

    // This is the constructor for the Date class, it takes in three parameters, year, month and day, and assigns them to the private fields.
    public Date(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    //These are the properties for the Date class, they allow us to get and set the values of the year, month and day.
    public int Year
    {
        get => _year;
        set => _year = ValidateYear(value);
    }
    
    public int Month
    {
        get => _month;
        set => _month = ValidateMonth(value);
    }

    public int Day
    {
        get => _day;
        set => _day = ValidateDay(value);
    }

    public override string ToString()
    {
        return $"{Year:0000}/{Month:00}/{Day:00}";
    }

    private int ValidateYear(int year)
    {
        if (year < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be greater than 0.");
        }
        return year;
    }

    private int ValidateMonth(int month)
    {
        if (month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
        }
        return month;
    }

    private int ValidateDay(int day)
    {
        if (day < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(day), "Day must be greater than 0.");
        }
        if (day == 29 && Month == 2 && IsLeapYear(Year))
        {
            return day;
        }
        int[] daysInMonth = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        if (day > daysInMonth[Month - 1])
        {
            throw new ArgumentOutOfRangeException(nameof(day), $"Day must be between 1 and {daysInMonth[Month - 1]} for month {Month}.");
        }
        return day;
    }

    private bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
