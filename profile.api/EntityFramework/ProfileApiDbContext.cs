using Microsoft.EntityFrameworkCore;
using profile.data.ProfileModels;

namespace profile.api.EntityFramework {
    public class ProfileApiDbContext : DbContext, IProfileApiDbContext {
        public ProfileApiDbContext (DbContextOptions<ProfileApiDbContext> options) : base (options) {

        }

        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<MediaModel> Media { get; set; }
        public DbSet<EventsModel> Events { get; set; }
        public DbSet<ExperienceModel> Experience { get; set; }
        public DbSet<GearModel> GearModels { get; set; }

    }
}