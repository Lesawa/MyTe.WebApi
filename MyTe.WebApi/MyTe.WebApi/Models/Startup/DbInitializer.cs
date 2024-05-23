using MyTe.WebApi.Models.Contexts;

namespace MyTe.WebApi.Models.Startup
{
    public class DbInitializer
    {
        public static void Initialize(MyTeContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
