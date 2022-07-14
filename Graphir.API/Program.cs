#region System
global using System;
global using System.Linq;
global using System.Net.Http;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Security.Claims;
global using System.Net.Http.Headers;
global using System.Collections.Generic;
#endregion

#region Microsoft
global using Microsoft.Identity.Web;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Hosting;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
#endregion

#region Grahpir
global using Graphir.API.Extensions;
global using Graphir.API.Patients;
global using Graphir.API.Practitioners;
global using Graphir.API.Services;
global using Graphir.API.Schema;
global using Graphir.API.Utils;
#endregion

#region Hotchocolate
global using HotChocolate;
global using HotChocolate.Types;
global using HotChocolate.Execution;
global using HotChocolate.Execution.Instrumentation;
global using HotChocolate.Types.Pagination;
global using HotChocolate.Execution.Configuration;
#endregion

#region Hl7
global using Hl7.Fhir.Rest;
global using Hl7.Fhir.Model;
#endregion

#region Others
global using Newtonsoft.Json;
global using GreenDonut;
#endregion


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
