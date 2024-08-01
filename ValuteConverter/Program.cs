using Microsoft.EntityFrameworkCore;
using ValuteConverter.Core;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Core.Services.ClientServices;
using ValuteConverter.Core.Services.CurrencyServices;
using ValuteConverter.Core.Services.CurrencyCourseServices;
using ValuteConverter.EntityFrameworkCore;
using ValuteConverter.Core.Services.Transactions;
using ValuteConverter.Core.Services.Reports;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ValuteConverterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddProfile<MappingProfile>());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyCourseService, CurrencyCourseService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITransactionsServices, TransactionsServices>();
builder.Services.AddScoped<IReportServices, ReportServices>();

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
