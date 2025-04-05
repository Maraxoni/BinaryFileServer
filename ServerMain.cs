using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;


namespace BinaryFileServer
{
    public class ServerMain
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddServiceModelServices();

            var app = builder.Build();

            //app.Urls.Add("http://192.168.50.183:8080");
            app.Urls.Add("http://localhost:8080");

            app.UseRouting();

            var binding = new BasicHttpBinding
            {
                MessageEncoding = WSMessageEncoding.Mtom
            };

            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<FileService>();
                serviceBuilder.AddServiceEndpoint<FileService, IFileService>(binding, "/FileService");
            });

            app.Run();
        }
    }
}