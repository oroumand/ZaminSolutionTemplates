﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Zamin.EndPoints.Web.Extensions.ModelBinding;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;
using ZaminTemplate.Infra.Data.Sql.Commands.Common;
using ZaminTemplate.Infra.Data.Sql.Queries.Common;

namespace ZaminTemplate.Endpoints.API.Extentions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        //zamin
        builder.Services.AddZaminApiCore("Zamin", "ZaminTemplate");

        //microsoft
        builder.Services.AddEndpointsApiExplorer();

        //zamin
        builder.Services.AddZaminWebUserInfoService(configuration, "WebUserInfo", true);

        //zamin
        builder.Services.AddZaminParrotTranslator(configuration, "ParrotTranslator");

        //zamin
        //builder.Services.AddSoftwarePartDetector(configuration, "SoftwarePart");

        //zamin
        builder.Services.AddNonValidatingValidator();

        //zamin
        builder.Services.AddZaminMicrosoftSerializer();

        //zamin
        builder.Services.AddZaminAutoMapperProfiles(configuration, "AutoMapper");

        //zamin
        builder.Services.AddZaminInMemoryCaching();
        //builder.Services.AddZaminSqlDistributedCache(configuration, "SqlDistributedCache");

        //CommandDbContext
        builder.Services.AddDbContext<DbContextNameCommandDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
            .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));

        //QueryDbContext
        builder.Services.AddDbContext<DbContextNameQueryDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("QueryDb_ConnectionString")));

        //PollingPublisher
        builder.Services.AddZaminPollingPublisherDalSql(configuration, "PollingPublisherSqlStore");
        //builder.Services.AddZaminPollingPublisher(configuration, "PollingPublisher");

        //MessageInbox
        builder.Services.AddZaminMessageInboxDalSql(configuration, "MessageInboxSqlStore");
        //builder.Services.AddZaminMessageInbox(configuration, "MessageInbox");

        //builder.Services.AddZaminRabbitMqMessageBus(configuration, "RabbitMq");

        //builder.Services.AddZaminTraceJeager(configuration, "OpenTeletmetry");
        
        //API Documentation
        builder.Services.AddZaminScalar(builder.Configuration, "Scalar");




        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        //zamin
        app.UseZaminApiExceptionHandler();

        //Serilog
        app.UseSerilogRequestLogging();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseZaminScalar();
        }

        app.UseStatusCodePages();

        app.UseCors(delegate (CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

        app.UseHttpsRedirection();

        //app.Services.ReceiveEventFromRabbitMqMessageBus(new KeyValuePair<string, string>("MiniAggregateName", "AggregateNameCreated"));

        //var useIdentityServer = app.UseIdentityServer("OAuth");

        var controllerBuilder = app.MapControllers();

        //if (useIdentityServer)
        //    controllerBuilder.RequireAuthorization();

        //app.Services.GetService<SoftwarePartDetectorService>()?.Run();

        return app;
    }
}