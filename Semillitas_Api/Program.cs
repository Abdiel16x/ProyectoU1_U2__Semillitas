using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Semillitas_Api.Models.Data;
using Semillitas_Api.Repositories;
using Semillitas_Api.Services;
using Semillitas_Api.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var cs = builder.Configuration.GetConnectionString("SemillitasConnectionString");

builder.Services.AddDbContext<SemillitasdbContext>(options => options.UseMySql(cs, ServerVersion.AutoDetect(cs)));

builder.Services.AddScoped(typeof(Repository<>));

builder.Services.AddTransient<CategoriaService>();
builder.Services.AddTransient<TallerService>();
builder.Services.AddTransient<InstructorService>();
builder.Services.AddTransient<PeriodoService>();
builder.Services.AddTransient<TutorService>();
builder.Services.AddTransient<AlumnoService>();
builder.Services.AddTransient<InscripcionService>();
builder.Services.AddTransient<CuentaService>();
builder.Services.AddTransient<ReporteService>();

builder.Services.AddScoped<NewCategoriaValidator>();
builder.Services.AddScoped<NewInstructorValidator>();
builder.Services.AddScoped<NewPeriodoValidator>();
builder.Services.AddScoped<NewTutorValidator>();
builder.Services.AddScoped<NewAlumnoValidator>();
builder.Services.AddScoped<NewTallerValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SemillitasdbContext>();
    context.Database.EnsureCreated();
}

app.MapControllers();
app.Run();
