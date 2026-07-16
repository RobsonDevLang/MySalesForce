using Microsoft.EntityFrameworkCore;
using User.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerConfiguration()
    .AddApplicationServices()
    .AddDatabase(builder.Configuration)
    .AddJwtAuthentication(builder.Configuration)
    .AddApplicationCors(builder.Configuration);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<User.Data.UserDbContext>();

    db.Database.Migrate();
}

app.MapControllers();

app.Run();