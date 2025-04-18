using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath("\\Users\\AnaLe\\OneDrive\\Desktop\\TREINAMENTO\\ProvaC#\\ProvaC#")
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

string connectionString = configuration.GetConnectionString("ConexaoPadrao");
