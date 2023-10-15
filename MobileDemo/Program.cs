using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using MobileDemo.Authentication;
using MobileDemo.Repository;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service;
using MobileDemo.Service.IService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBearerAuthentication>(new BearerAuthentication("ebf1ed9368f3fb3677ae19947ed3d9ab63728cd20a82e5df22186be20e20f26c539fff4d4f01af049df686759acd2bf50de6a82520fd532bc6f6262180daf37aadc321d6882a104da83d3ee15cb5632b204b8c1aefddbf3cbafad17cd412fcdcd3cd2404cd1b1bc3d89e8db70f1efb2873d9db4e9c50a8073a8bc32815db7180de31c2680fa760671bd73bcc489346c0329753f712115f71354ed699dc985985"));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<ISalesReportService, SalesReportService>();
builder.Services.AddTransient<ISalesReportRepository, SalesReportRepository>();

builder.Services.AddTransient<IBrandWiseSalesReportService, BrandWiseSalesReportService>();
builder.Services.AddTransient<IBrandWiseSalesReportRepository, BrandWiseSalesReportRepository>();

builder.Services.AddDbContext<MobileStoreContext>(options => options.UseSqlServer("Server=.;Database=MobileStoreDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiPlayground", Version = "v1" });
    c.AddSecurityDefinition("token", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Scheme = "Bearer"
    });
    // dont add global security requirement
    // c.AddSecurityRequirement(/*...*/);
    c.OperationFilter<SecureEndpointAuthRequirementFilter>();
});
builder.Services.AddAuthentication(authentication =>
{
    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}

            ).AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ebf1ed9368f3fb3677ae19947ed3d9ab63728cd20a82e5df22186be20e20f26c539fff4d4f01af049df686759acd2bf50de6a82520fd532bc6f6262180daf37aadc321d6882a104da83d3ee15cb5632b204b8c1aefddbf3cbafad17cd412fcdcd3cd2404cd1b1bc3d89e8db70f1efb2873d9db4e9c50a8073a8bc32815db7180de31c2680fa760671bd73bcc489346c0329753f712115f71354ed699dc985985")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                bearer.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        context.Response.Headers.Add("Token-Expired", "false");
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }

                };
            }).AddScheme<BasicAuthenticationOptions, SwaggerAuthenticationHandler>("Basic", _ => { }); 

var app = builder.Build();

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
