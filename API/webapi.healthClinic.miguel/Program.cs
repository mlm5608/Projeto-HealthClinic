using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // Ignora os loopings nas consultas
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        // Ignora valores nulos ao fazer jun��es nas consultas
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parametros de valida��o do token
.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         //Valida quem esta solicitando
         ValidateIssuer = true,

         //Valide que est� recebendo
         ValidateAudience = true,

         //defien se o tempo de expira��o do token ser� validado
         ValidateLifetime = true,

         //forma de criptografia e ainda valida��o da chave de autentica��o
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Webapi_Health_Clinic_Miguel_Tarde_2Semestre")),

         //Valida tempo de expira��o do token
         ClockSkew = TimeSpan.FromMinutes(20),

         //De onde est� vindo (issuer)
         ValidIssuer = "webapi.healthClinic.miguel",

         //Para onde est� indo (audience)
         ValidAudience = "webapi.healthClinic.miguel"
     };
 });

//Adiciona o gerador do Swagger � cole��o de servi�os
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Health Clinic Miguel",
        Description = "API para gerenciamento de Eventos - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Miguel Lamarca",
            Url = new Uri("https://github.com/mlm5608")
        }
    });

    //Configura o Swagger para usar o arquivo XML gerado com as instru��es anteriores
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //usando a autentica��o no swagger

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

//atender � interface do usu�rio do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
