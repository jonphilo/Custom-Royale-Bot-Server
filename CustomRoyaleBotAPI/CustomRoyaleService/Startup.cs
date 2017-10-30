using Autofac;
using Autofac.Integration.WebApi;
using CustomRoyaleService.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CustomRoyaleService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<IGameModeService>().SingleInstance();
            //register services

            IContainer container = builder.Build();

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            var formatter = new JsonMediaTypeFormatter();
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            settings.Converters.Add(new DateTimeConverter());
            formatter.SerializerSettings = settings;
            formatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.Add(formatter);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.EnableCors(new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS"));

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);

        }
    }

    public class DateTimeConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime dt = (DateTime)value;
            writer.WriteValue(dt.ToFileTimeUtc());
        }
    }
}
