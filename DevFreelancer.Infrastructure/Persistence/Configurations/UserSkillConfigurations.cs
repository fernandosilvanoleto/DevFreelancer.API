using DevFreelancer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreelancer.Infrastructure.Persistence.Configurations
{
    public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
                .HasKey(us => us.Id);

            builder
                .HasOne(us => us.User)
                .WithMany(user => user.Skills)
                .HasForeignKey(us => us.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(us => us.Skills)
                .WithMany(skill => skill.Skills)
                .HasForeignKey(us => us.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
