namespace lambdawebapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient(typeof( System.Collections.Generic.IList<>), typeof(System.Collections.Generic.List<>));

            services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.MapGet(
                "/",
                () => "Welcome to running ASP.NET Core on AWS Lambda (minimal api)");

            app.MapGet(
                "/env",
                (IConfiguration configuration) =>
                {
                    var someKey = configuration["SOME_KEY"];
                    return $"some key {someKey}";
                });

        }
    }
}
