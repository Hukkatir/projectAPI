/*using Domian.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Domain.Interfaces;

namespace projectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
     
            builder.Services.AddDbContext<projectDBContext>(
                optionsAction: options => options.UseSqlServer(connectionString: "Server=DESKTOP-CJMJ3I2;Database=projectDB;Trusted_Connection=True; Integrated Security = True; TrustServerCertificate=True;"));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRateService, CommentRateService>();

            builder.Services.AddScoped<IContentService, ContentService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IMediaFileService, MediaFileService>();

            builder.Services.AddScoped<IMediumService, MediumService>();
            builder.Services.AddScoped<IMessagesUserService, MessagesUserService>();
            builder.Services.AddScoped<IMyRatingService, MyRatingService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentUserService, PaymentUserService>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddScoped<IRoomsUserService, RoomsUserService>();
            builder.Services.AddScoped<IGroupMediumService, GroupMediumService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
         
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "���� ��� ��������� ������� API",
                    Description = "����� �� ������ �� �������, �� ������ �����������",
                    Contact = new OpenApiContact
                    {
                        Name = "���������",
                        Url = new Uri("https://www.kinopoisk.ru/")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

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
}*/

using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using DataAccess.Wrapper;
using Domain.Wrapper;
using Domian.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace projectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<projectDBContext>(
                optionsAction: options => options.UseSqlServer(
                    connectionString: "Server=DESKTOP-CJMJ3I2;Database=projectDB; Trusted_Connection = True;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRateService, CommentRateService>();

            builder.Services.AddScoped<IContentService, ContentService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IMediaFileService, MediaFileService>();

            builder.Services.AddScoped<IMediumService, MediumService>();
            builder.Services.AddScoped<IMessagesUserService, MessagesUserService>();
            builder.Services.AddScoped<IMyRatingService, MyRatingService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentUserService, PaymentUserService>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddScoped<IRoomsUserService, RoomsUserService>();
            builder.Services.AddScoped<IGroupMediumService, GroupMediumService>();




            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

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