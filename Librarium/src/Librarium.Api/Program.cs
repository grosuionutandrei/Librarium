using Librarium.Data;
using Librarium.Data.infrastructure.configuration;
using Librarium.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureOptions(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddDataSourceAndRepositories();
// builder.Services.AddDataSourceAndRepositories();
// builder.Services.AddSingleton<ArticleDbContextFactory>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();