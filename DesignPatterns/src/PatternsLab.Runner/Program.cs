using SRP__Patterns.DesignPatterns.src.PatternsLab.BuilderDesign;
using SRP__Patterns.DesignPatterns.src.PatternsLab.SingletonDesign;

namespace SRP__Patterns;

class Program
{
    static void Main(string[] args)
    {
        var registration =
            new CourseRegistrationBuilder(
                "ahmad@gmail.com",
                "CS101",
                AccessMode.Online)
            .GroupCode("G1")
            .DiscountCode("DISC10")
            .SendWhatsApp(true)
            .SendEmailWelcome(true)
            .MentorNote("Student prefers evening")
            .PreferredStart(new DateOnly(2026, 10, 1))
            .Build();

        Console.WriteLine($"Student: {registration.StudentEmail}");
        Console.WriteLine($"Course: {registration.CourseCode}");
        Console.WriteLine($"Access Mode: {registration.AccessMode}");
        Console.WriteLine($"Group: {registration.GroupCode}");
        Console.WriteLine($"Discount: {registration.DiscountCode}");
        Console.WriteLine($"WhatsApp: {registration.SendWhatsApp}");
        Console.WriteLine($"Email Welcome: {registration.SendEmailWelcome}");
        Console.WriteLine($"Mentor Note: {registration.MentorNote}");
        Console.WriteLine($"Start Date: {registration.PreferredStart}");

        var database = new DatabaseService();
        var ui = new UiService();

        database.Connect();
        ui.Render();

        Console.WriteLine(
            database.Config == ui.Config
        );
    }
}