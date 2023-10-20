using TurismoApi.Adapters;
using TurismoApi.Facades;
using TurismoApi.HttpClients;
using TurismoApi.HttpClients.Interfaces;
using TurismoApi.Interfaces;
using TurismoApi.Requests;
using TurismoApi.Responses;

namespace TurismoApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddXmlSerializerFormatters(); // Add this line to support XML;
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<IServiceFacade<HotelLegsFacade>, HotelLegsFacade>();
        builder.Services.AddTransient<IHotelLegsClient,HotelLegsClient>();
        builder.Services.AddTransient<IServiceAdapter<HubRequest, HotelLegsRequest, HotelLegsResponse, HubResponse>, HotelLegsAdapter>();

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

