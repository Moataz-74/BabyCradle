namespace BabyCradle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This�is�to�generate�the�Default�UI�of�Swagger�Documentation����
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET�8�Web�API",
                    Description = " BabyCradle"
                });
                //�To�Enable�authorization�using�Swagger�(JWT)����
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter�'Bearer'�[space]�and�then�your�valid�token�in�the�text�input�below.\r\n\r\nExample:�\"Bearer�eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[] {}
                    }
                    });
            });

            builder.Services.AddMemoryCache();

            //__________________________________________________________________
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("Local")));
            builder.Services.AddHangfireServer();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile)); 
            builder.Services.AddScoped<INoteRepository,NoteRepository>();
            builder.Services.AddScoped<NoteService>();
            builder.Services.AddScoped<PresentUserService>();
            builder.Services.AddScoped<IChildRepository,ChildRepository>();
            builder.Services.AddScoped<ChildService>();
            builder.Services.AddScoped<VaccinationService>();
            builder.Services.AddScoped<IVaccinationRepository,VaccinationRepository>();
            builder.Services.AddScoped<SendNotificationService>();
            builder.Services.AddScoped<IMedicineRepository,MedicineRepository>();
            builder.Services.AddScoped<IFeedingRepository,FeedingRepository>();
            //builder.Services.AddHostedService<NotificationService>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Local");
                options.UseSqlServer(connectionString);
            });

            //Identity

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddControllers();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //[authorize]
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                //verified key
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:IssuerIP"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:AudienceIP"],
                    //ValidateLifetime = true,
                    IssuerSigningKey =
                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecritKey"]))
                };
            });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //app.UseAuthentication();

            app.UseHangfireDashboard("/dashboard");

            app.MapControllers();

            app.Run();
        }
    }
}
