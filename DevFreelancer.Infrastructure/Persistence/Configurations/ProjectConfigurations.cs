using DevFreelancer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreelancer.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                 .HasOne(p => p.Freelancer) // ESSSE ATRIBUTO ESTÁ EM PROJECT
                .WithMany(f => f.FreelanceProjects) // ESSE ATRIBUTO ESTÁ EM USER
                .HasForeignKey(p => p.IdFreelancer) // ESSE ATRIBUTO ESTÁ EM PROJECT
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Client) // ESSSE ATRIBUTO ESTÁ EM PROJECT
                .WithMany(f => f.OwnedProjects) // ESSE ATRIBUTO ESTÁ EM USER
                .HasForeignKey(p => p.IdClient) // ESSE ATRIBUTO ESTÁ EM PROJECT
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
