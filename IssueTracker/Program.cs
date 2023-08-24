using IssueTracker.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;


namespace IssueTracker
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, config) =>    //loglama
            {
                config.WriteTo.File("log.txt");
                
            });

            // Add services to the container.

            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<IssueDbContext>(o => o.UseSqlite("filename=Data/Database/Issue.db"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}