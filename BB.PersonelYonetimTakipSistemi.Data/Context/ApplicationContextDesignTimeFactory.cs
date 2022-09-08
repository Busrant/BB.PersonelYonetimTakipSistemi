using Microsoft.EntityFrameworkCore.Design;

namespace BB.PersonelYonetimTakipSistemi.Data.Context
{
    public class ApplicationContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var context = new ApplicationContext();
            return context;
        }
    }
}
