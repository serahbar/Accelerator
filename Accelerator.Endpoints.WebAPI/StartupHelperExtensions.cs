using Accelerator.Core.ApplicationServices.Services;
using Accelerator.Core.Resources.Resources;
using Accelerator.Framework.Commands;
using Accelerator.Framework.Queries;
using Accelerator.Framework.Resources;
using Accelerator.Infrastructures.Data.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace Accelerator.Endpoints.WebAPI
{
    internal static class StartupHelperExtensions
    {
        //public static IConfiguration Configuration { get; }
        // Add services to the container
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddControllers(configure =>
            {
                configure.ReturnHttpNotAcceptable = true;
                configure.CacheProfiles.Add("240SecondsCacheProfile",
                    new() { Duration = 240 });
            })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                                {
                                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                                        factory.Create(typeof(SharedResource));
                                })
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                })
                .AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
            })
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    // create a validation problem details object
                    var problemDetailsFactory = context.HttpContext.RequestServices
                            .GetRequiredService<ProblemDetailsFactory>();

                    var validationProblemDetails = problemDetailsFactory
                        .CreateValidationProblemDetails(
                            context.HttpContext,
                            context.ModelState);

                    // add additional info not added by default
                    validationProblemDetails.Detail =
                            "See the errors field for details.";
                    validationProblemDetails.Instance =
                        context.HttpContext.Request.Path;

                    // report invalid model state responses as validation issues
                    validationProblemDetails.Type =
                            "https://courselibrary.com/modelvalidationproblem";
                    validationProblemDetails.Status =
                        StatusCodes.Status422UnprocessableEntity;
                    validationProblemDetails.Title =
                        "One or more validation errors occurred.";

                    return new UnprocessableEntityObjectResult(
                        validationProblemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });
            builder.Services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters
                      .OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

                if (newtonsoftJsonOutputFormatter != null)
                {
                    newtonsoftJsonOutputFormatter.SupportedMediaTypes
                        .Add("application/vnd.marvin.hateoas+json");
                }
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.CustomSchemaIds(type => type.FullName);
            }
                );
            builder.Services.AddTransient<IResourceManager, ResourceManager<SharedResource>>();
            builder.Services.AddTransient<CommandDispatcher>();
            builder.Services.AddTransient<QueryDispatcher>();
            builder.Services.AddTransient< IPropertyMappingSerivce,
             PropertyMappingSerivce>();

            builder.Services.AddTransient<IPropertyCheckerService,
             PropertyCheckerService>();

            // builder.Services.AddScoped<ICourseLibraryRepository,
            // CourseLibraryRepository>();

            builder.Services.AddDbContext<AcceleratorDbContext>(options =>
            {
                options.UseSqlServer("Server=.; Database=AcceleratorDb;Integrated Security=true;TrustServerCertificate=True");
                //options.UseSqlServer(Configuration.GetConnectionString("AcceleratorCnn"));
                //optionsc => c.UseSqlServer(Configuration.GetConnectionString("AcceleratorCnn"));
            });

            builder.Services.AddAutoMapper(
                AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddResponseCaching();

            builder.Services.AddHttpCacheHeaders(
                (expirationModelOptions) =>
                {
                    expirationModelOptions.MaxAge = 60;
                    expirationModelOptions.CacheLocation =
                        Marvin.Cache.Headers.CacheLocation.Private;
                },
                (validationModelOptions) =>
                {
                    validationModelOptions.MustRevalidate = true;
                });

            return builder.Build();
        }

        // Configure the request/response pipelien
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    //TODO:Log Actuall Propblem In ExceptionHandler!!!!!!
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync(
                            "An unexpected fault happened. Try again later.");
                    });
                });
            }

            //  app.UseResponseCaching();

            app.UseHttpCacheHeaders();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<AcceleratorDbContext>();
                    if (context != null)
                    {
                        await context.Database.EnsureDeletedAsync();
                        await context.Database.MigrateAsync();
                    }
                }
                catch (Exception ex)
                {
                    //var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                    //logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
        }
    }
}
