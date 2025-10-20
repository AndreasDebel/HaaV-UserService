var builder = WebApplication.CreateBuilder(args);
// testcomment

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseCors(policy => policy
   .SetIsOriginAllowed(origin =>
   {
       if (string.IsNullOrEmpty(origin)) return false;
       try { return new Uri(origin).Host == "localhost"; }
       catch { return false; }
   })
   .AllowAnyHeader()
   .AllowAnyMethod()
   .AllowCredentials()
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
