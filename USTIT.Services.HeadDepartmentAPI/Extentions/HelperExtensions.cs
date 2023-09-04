using Microsoft.EntityFrameworkCore;
using USTIT.Services.HeadDepartmentAPI.Data;

namespace USTIT.Services.HeadDepartmentAPI.Extentions
{
    public static class HelperExtensions
    {
        public static WebApplication ApplyMigration(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            return app;
        }
    }
}
