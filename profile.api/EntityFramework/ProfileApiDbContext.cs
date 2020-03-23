using Microsoft.EntityFrameworkCore;

namespace profile.api.EntityFramework {
    public class ProfileApiDbContext : DbContext {
        public ProfileApiDbContext (DbContextOptions<ProfileApiDbContext> options) : base (options) {

        }
    }
}