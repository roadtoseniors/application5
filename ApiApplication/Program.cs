
using AvaloniaApplication5.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/api/departmets", (MyDbContext context) =>
{
    return context.Departments.ToList();
});

app.MapGet("/api/divisions", (MyDbContext context) =>
{
    return context.Divisions.ToList();
});

app.MapGet("/api/groups", (MyDbContext context) =>
{
    return context.Groups.ToList();
});

app.MapGet("/api/group_visits", (MyDbContext context) =>
{
    return context.GroupVisits.ToList();
});

app.MapGet("/api/individual_visits", (MyDbContext context) =>
{
    return context.IndividualVisits.ToList();
});

app.MapGet("/api/staffs", (MyDbContext context) =>
{
    return context.Staff.ToList();
});

app.MapGet("/api/staff_code", (MyDbContext context) =>
{
    return context.StaffCodes.ToList();
});


app.Run();
