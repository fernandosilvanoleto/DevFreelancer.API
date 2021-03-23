using DevFreelancer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreelancer.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            //builder
            //    .HasMany(u => u.Skills) // ATRIBUTO EM User
            //    .WithOne()
            //    .HasForeignKey(u => u.IdSkill) // ATRIBUTO EM UserSkill
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
