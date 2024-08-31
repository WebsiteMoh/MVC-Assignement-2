namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Home", async context => {

                    await context.Response.WriteAsync("You are in home");

                });
                endpoints.MapGet("/Home/{id}", async context => {
                    String id = (string)context.Request.RouteValues["id"];
                    await context.Response.WriteAsync($"You are in home and your ID={id}");

                });
            });
           
          


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
             name: "doctor",
             pattern: "{controller=Doctor}/{action=Index}");

            app.Run();
        }
    }
}