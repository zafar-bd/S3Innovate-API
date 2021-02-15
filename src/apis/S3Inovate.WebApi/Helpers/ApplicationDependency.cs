using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using S3Inovate.Core.Context;
using S3Inovate.Core.Servies.Abstractions;
using S3Inovate.Core.Servies.Implementations;
using System.Diagnostics;
using MediatR;
using S3Inovate.Core.Cqrs.Handlers.Queries;
using System.Collections.Generic;
using S3Inovate.Core.ViewModels;
using S3Inovate.Core.Cqrs.Queries;
using AutoMapper;
using S3Inovate.WebApi.AutoMappers;

namespace S3Inovate.WebApi.Helpers
{
    public static class ApplicationDependency
    {
        public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var readingConnectionString = configuration.GetConnectionString("Reading");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.LogTo(x => Debug.Write(x));
                options.UseSqlServer(readingConnectionString);
            });

            services.AddDistributedMemoryCache();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<IReadingService, ReadingService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IObjectService, ObjectService>();
            services.AddScoped<IDataFieldService, DataFieldService>();
            services.AddScoped<IRequestHandler<ReadingQuery, IReadOnlyCollection<ReadingVm>>, ReadingQueryHandler>();
            services.AddScoped<IRequestHandler<BuildingQuery, IReadOnlyCollection<BuildingVm>>, BuildingQueryHandler>();
            services.AddScoped<IRequestHandler<ObjectQuery, IReadOnlyCollection<ObjectVm>>, ObjectQueryHandler>();
            services.AddScoped<IRequestHandler<DataFieldsQuery, IReadOnlyCollection<DataFieldVm>>, DataFieldQueryHandler>();
        }


    }
}
