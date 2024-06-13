using Microsoft.EntityFrameworkCore;
using WebTest.Data.Context;
using WebTest.Data.Entityes;
using WebTest.Data.Repositories;

namespace WEBTest.DataExetion;
public static class DataExtetion
{
    /// <summary>
    /// Миграция базы данных
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<NasosDbContext>()
                      ?? throw new InvalidOperationException();
        context.Database.Migrate();

        Seed(context);

        return app;
    }

    /// <summary>
    /// Добавление первоначальных значений в базу данных
    /// </summary>
    /// <param name="context"></param>
    public static void Seed(NasosDbContext context)
    {
        if (context.Nasoses.Any())
        {
            return;
        }

        var motors = new MotorEntity[]
        {
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor A", Power = 5, Current = 10, NominalSpeed = 1500, Description = "Высокоэффективный мотор", Price = 5000M , Motor = "Motor_1"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor B", Power = 7, Current = 12, NominalSpeed = 1600, Description = "Среднеэффективный мотор", Price = 6000M , Motor = "Motor_2"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor C", Power = 115, Current = 6, NominalSpeed = 1500, Description = "Высокоэффективный мотор", Price = 5000M , Motor = "Motor_3"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor D", Power = 227, Current = 2, NominalSpeed = 1600, Description = "Среднеэффективный мотор", Price = 26000M , Motor = "Motor_4"},
                new MotorEntity { Id = Guid.NewGuid(),Name = "Motor F", Power = 235, Current = 9, NominalSpeed = 1500, Description = "Высокоэффективный мотор", Price = 15000M , Motor = "Motor_5"},
        };

        var materials = new MaterialEntity[]
        {
                new MaterialEntity { Id = Guid.NewGuid(), Name = "Нержавеющая сталь", Description = "Высококачественная нержавеющая сталь" },
                new MaterialEntity { Id = Guid.NewGuid(), Name = "Чугун", Description = "Высокопрочный чугун" },
                new MaterialEntity { Id = Guid.NewGuid(), Name = "Сталь", Description = "Высокопрочный сталь" }
        };

        var nasoses = new NasosEntity[]
        {
                new NasosEntity { Id = Guid.NewGuid(),Name = "Nasos A", MaxPressure = 10, Temperature = 100, Weight = 50, MotorEntity = motors[0], MaterialHull = materials[0], ImpellerMaterial = materials[0], Description = "Высокопроизводительный насос", Picture = "images/pumpA.jpg", Price = 15000M },
                new NasosEntity { Id = Guid.NewGuid(),Name = "Nasos B", MaxPressure = 15, Temperature = 120, Weight = 60, MotorEntity = motors[1], MaterialHull = materials[1], ImpellerMaterial = materials[1], Description = "Среднепроизводительный насос", Picture = "images/pumpB.jpg", Price = 17000M },
                new NasosEntity { Id = Guid.NewGuid(),Name = "Nasos C", MaxPressure = 20, Temperature = 200, Weight = 70, MotorEntity = motors[3], MaterialHull = materials[3], ImpellerMaterial = materials[2], Description = "Высокопроизводительный насос", Picture = "images/pumpC.jpg", Price = 35000M },
                new NasosEntity { Id = Guid.NewGuid(),Name = "Nasos D", MaxPressure = 25, Temperature = 220, Weight = 80, MotorEntity = motors[1], MaterialHull = materials[2], ImpellerMaterial = materials[3], Description = "Среднепроизводительный насос", Picture = "images/pumpD.jpg", Price = 7000M },
                new NasosEntity { Id = Guid.NewGuid(),Name = "Nasos E", MaxPressure = 30, Temperature = 300, Weight = 5, MotorEntity = motors[0], MaterialHull = materials[2], ImpellerMaterial = materials[0], Description = "Высокопроизводительный насос", Picture = "images/pumpE.jpg", Price = 5000M }
        };

        context.Motors.AddRange(motors);
        context.Materials.AddRange(materials);
        context.Nasoses.AddRange(nasoses);

        context.SaveChanges();
    }
}
/// <summary>
/// Добавление репозиториев доступа к данным
/// </summary>
/// <param name="services"></param>
/// <param name="connectionString"></param>
/// <returns></returns>
/// <exception cref="NotImplementedException"></exception>
//public static IServiceCollection AddMeltData(this IServiceCollection services, string connectionString)
//{
//    Console.WriteLine(connectionString);
//    var connectionModel = ConnectionStringHelper.NormalizeConnectionString(connectionString);

//    return services.AddDbContext<MeltDbContext>(option =>
//    {
//        switch (connectionModel.Provider)
//        {
//            case XpoProvider.Postgres:
//                throw new NotImplementedException();
//            case XpoProvider.MSSqlServer:
//                option.UseSqlServer(connectionModel.ConnectionString, x =>
//                {
//                    Console.WriteLine(connectionModel.ConnectionString);
//                    x.MigrationsAssembly(typeof(SqlServerMarker).Assembly.GetName().Name!);
//                    x.MigrationsHistoryTable(MeltDbContext.MigrationHistoryTableName,
//                        MeltDbContext.DefaultSchema);
//                });
//                break;
//            default:
//                option.UseInMemoryDatabase(connectionModel.ConnectionString);
//                break;
//        }
//    })
//        .AddScoped<MeltUnitOfWork>()
//        .AddScoped<TaskMeltRepository>()
//        .AddScoped<StRepository>()
//        .AddScoped<TaskMeltSampleRepository>()
//        .AddScoped<TaskRepository>()
//        .AddScoped<ProductRepository>()
//        .AddScoped<CpProductRepository>()
//        .AddScoped<AodIntegrationRequestRepository>()
//        .AddScoped<CpRepository>()
//        .AddScoped<UserRepository>()
//        .AddScoped<OrgUnitRepository>()
//        .AddScoped<SampleRepository>()
//        .AddScoped<SampleStatusHistoryRepository>()
//        .AddScoped<TaskStatusHistoryRepository>()
//        .AddScoped<DigitalSetRepository>()
//        .AddScoped<CpOrgUnitRepository>();
//}
