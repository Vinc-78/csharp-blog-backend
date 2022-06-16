//per il context aggiungiamo:
using Microsoft.EntityFrameworkCore;
using csharp_blog_backend.Models;
//end per il context aggiungiamo:


var builder = WebApplication.CreateBuilder(args);


// MODIFICA AGGIUNTA PER IL CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});


builder.Services.AddControllers();

//per il context aggiungiamo
builder.Services.AddDbContext<BlogContext>(opt =>
    opt.UseInMemoryDatabase("posts"));
//end per il context aggiungiamo:


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(); // MODIFICA AGGIUNTA PER IL CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
