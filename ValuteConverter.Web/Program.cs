using ValuteConverter.Core;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Core.Services.CalulatorServices;
using ValuteConverter.Core.Services.ClientServices;
using ValuteConverter.Core.Services.CurrencyCourseServices;
using ValuteConverter.Core.Services.CurrencyServices;
using ValuteConverter.Core.Services.Reports;
using ValuteConverter.Core.Services.Transactions;
using ValuteConverter.EntityFrameworkCore.Repository;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<ValuteConverterDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(config => config.AddProfile<MappingProfile>());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyCourseService, CurrencyCourseService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITransactionsServices, TransactionsServices>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
