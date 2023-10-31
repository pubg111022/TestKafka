using Manonero.MessageBus.Kafka.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;
using TestKafka.Application;
using TestKafka.BackgroundTasks;
using TestKafka.Core.Database;
using TestKafka.Core.Database.InMemory;
using TestKafka.Core.IServices;
using TestKafka.Core.Services;
using TestKafka.Settings;

var builder = WebApplication.CreateBuilder(args);
var appsetting = AppSetting.MapValue(builder.Configuration);
// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddControllers();
builder.Services.AddSingleton(appsetting);  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOracle<StudentDbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddKafkaProducers(producerBuilder =>
{
    producerBuilder.AddProducer(appsetting.GetProducerSetting(Constants.CashSettingId));
});
builder.Services.AddKafkaConsumers(consumerBuilder =>
{
    consumerBuilder.AddConsumer<CashConsumingTask>(appsetting.GetConsumerSetting(Constants.CashSettingId));
});
builder.Services.AddSingleton<StudentMemory>();
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
app.UseKafkaMessageBus(mess =>
{
    mess.RunConsumer(Constants.CashSettingId);
});
app.Run();
