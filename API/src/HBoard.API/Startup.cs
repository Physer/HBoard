﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBoard.Business.Maps;
using HBoard.Business.PublicTransport.Trains;
using HBoard.Business.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HBoard.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();

            services.AddTransient<IMapsService, GoogleMapsService>();
            services.AddTransient<ITrainStationService, TrainsService>();

            services.Configure<ApplicationSettings>(Configuration.GetSection("Application"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());
            app.UseMvc();
        }
    }
}
