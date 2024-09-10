using Main;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //var urmom = new Employee();
        //app.MapGet("/", () => urmom.GetDiscount());
        app.Run();
    }
}