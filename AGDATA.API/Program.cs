using AGDATA.BL.Service;
using AGDATA.DAL;

using AGDATA.Common.Interfaces;

namespace AGDATA.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

             builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAngularApp",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:4200")
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                        });
                });

                builder.Services.AddControllers();


            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IDBContact, InMemoryDB>();

            var app = builder.Build();

            app.UseCors("AllowAngularApp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
