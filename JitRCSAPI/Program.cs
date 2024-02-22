using JitRCSAPI.Data;
using JitRCSAPI.Service.DepartmentService;
using JitRCSAPI.Service.EmployeeService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"));
});

builder.Services.AddCors(options => options.AddPolicy(name: "jitrcsfrontend", policy =>
{
    policy.WithOrigins("http://localhost:3000",
        "http://localhost:3001", 
        "http://192.168.43.246:3001",
        "http://192.168.43.246:3000")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("jitrcsfrontend");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
