using DevFreelancer.Application.Commands.ProjectComments.CreateComment;
using DevFreelancer.Application.Commands.Projects.CreateProject;
using DevFreelancer.Application.Services.Implementations;
using DevFreelancer.Application.Services.Interfaces;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using DevFreelancer.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DevFreelancer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("DevFreelancer");

            services.AddDbContext<DevFreelancerDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IProjectCommentService, ProjectCommentService>();

            //services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddMediatR(typeof(CreateProjectCommand));
            services.AddMediatR(typeof(CreateProjectCommentCommand));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreelancer.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreelancer.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
