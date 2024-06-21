using System.Globalization;
using System.Linq;

namespace Cashflow.API.MIddlewares
{
    public class CultureMiddleware
    {
        private RequestDelegate _next { get; set; }
        public CultureMiddleware(RequestDelegate next) { 
            _next = next;
        }



        public async Task Invoke(HttpContext context)
        {


            var suportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();


            // captura o idioma atual 


            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

         

            //define um valor padrão
            var cultureInfo = new CultureInfo("en");

            if(string.IsNullOrWhiteSpace(requestedCulture) == false && suportedCultures.Exists(Lenguage => Lenguage.Name.Equals(requestedCulture)))
            {
                cultureInfo = new CultureInfo(requestedCulture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
