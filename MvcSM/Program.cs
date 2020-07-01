using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MvcSM.Data;
using MvcSM.Models;
using System;
using MvcSM;
using StackExchange.Redis;
namespace MvcSM
{
    public class Program
  {
      public static void Main(string[] args)
      {
        // // Tạo kết nối
        //     ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,password=quang1604");

        //     // Lấy DB
        //     IDatabase db = redis.GetDatabase(1);

        //     // Ping thử
        //     if (db.Ping().TotalSeconds > 5 ) {
        //         throw new TimeoutException("Server Redis không hoạt động");
        //     }

        //     // Lưu dữ liệu
        //     db.StringSet("hello", "Xin chào Redis C#");

        //     // Đọc lại dữ liệu
        //     var vl  = db.StringGet("hello");
        //     Console.WriteLine(vl);

        //     // Xóa một key
        //     db.KeyDelete("mykey");

        //     // Lấy tất cả các key
        //     IServer server =  redis.GetServer("127.0.0.1:6379");
        //     var keys = server.Keys(pattern: "*");

        //     foreach (var k in keys) {
        //         Console.WriteLine(k);
        //     }

        //     // Xóa tất cả các key
        //     //server.FlushAllDatabases();


        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        host.Run();

      }

      public static IHostBuilder CreateHostBuilder(string[] args)
      {
        Action<IWebHostBuilder> configure = webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            };
        return Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(configure);
      }
    }
}