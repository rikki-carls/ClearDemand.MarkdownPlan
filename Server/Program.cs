using ClearDemand.MarkdownPlan.Server.Repository;
using ClearDemandCodeExcercise.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ProductTestContext>(opt =>
opt.UseMySQL("server=cleardemandtest.cnm9ggxlc1hi.us-east-2.rds.amazonaws.com;uid=;pwd=;database=TestDB"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMarkdownPlanRepository, MarkdownPlanRepository>();
builder.Services.AddScoped<ISalesDataRepository, SalesDataRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin  
    .AllowCredentials());               // allow credentials 

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
