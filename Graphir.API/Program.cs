global using System.Security.Claims;
global using System.Threading.Tasks;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Hosting;
global using Newtonsoft.Json;
global using Hl7.Fhir.Rest;
global using Hl7.Fhir.Model;
global using Graphir.API.Extensions;
global using Graphir.API.Patients;
global using Graphir.API.Practitioners;
global using Graphir.API.Services;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Identity.Web;
global using GreenDonut;
global using System.Collections.Generic;
global using Graphir.API.Schema;

global using System;
global using System.Linq;
global using HotChocolate.Types.Pagination;
global using Graphir.API.Utils;

global using HotChocolate;
global using HotChocolate.Execution;
global using HotChocolate.Execution.Instrumentation;
global using Microsoft.Extensions.Logging;

global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Threading;
global using HotChocolate.Execution.Configuration;
global using HotChocolate.Types;

namespace Graphir.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
