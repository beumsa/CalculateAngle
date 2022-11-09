namespace CalculateAngle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Show a welcome message.
            Console.WriteLine("Welcome to Clock Angle Calculator!");

            // Prompt the user to enter the hour.
            Console.Write("Enter hour: ");
            double hour = double.Parse(Console.ReadLine()!);

            // Prompt the user to enter the minute.
            Console.Write("Enter minute: ");
            double minute = double.Parse(Console.ReadLine()!);

            // Calculate the lesser angle between hour and minute hands.
            double lesserAngle = CalculateLesserAngle(hour, minute);

            if (lesserAngle < 0)
            {
                Console.WriteLine("Invalid Input!");
            }

            // Display result.
            Console.WriteLine($"The angle between the hour hand and the minute hand: {lesserAngle} degrees.");
        }

        static double CalculateLesserAngle(double hour, double minute)
        {
            // Ensure valid argument is passed.
            if (hour < 0 || minute < 0 || hour > 12 || minute > 60)
            {
                return -1;
            }

            // Using 12:00 as reference.
            if (hour == 12)
            {
                hour = 0;
            }

            if (minute == 60)
            {
                minute = 0;
                hour = hour + 1;
                if (hour > 12)
                {
                    hour = hour - 12;
                }
            }

            // Angle subtended by the hour hand with respect to 12:00
            double hourAngle = (hour * 60 + minute) * 0.5;

            // Angle subtended by the minute hand with respect to 12:00
            double minuteAngle = minute * 6;

            // Angle between hour hand and minute hand.
            double angle = Math.Abs(hourAngle - minuteAngle);

            // Calculate the (possibly) acute angle between hour and minute hand.
            return Math.Min(360 - angle, angle);
        }
    }
}