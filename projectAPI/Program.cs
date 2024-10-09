using Domian.Interfaces;
using BusinessLogic.Services;
using Domian.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Domian.Wrapper;

namespace projectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<projectDBContext>(
                optionsAction:options => options.UseSqlServer(
                    connectionString:"Server=DESKTOP-CJMJ3I2;Database=testBD; Trusted_Connection = True;"));

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