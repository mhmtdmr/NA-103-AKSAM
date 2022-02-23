using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFisrt_01.Controllers
{
    public class HomeController : Controller
    {
        public  ActionResult Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://eronsoftware.com:55301/KULLANICI/authentication/");
            request.Method = HttpMethod.Post;

            request.Headers.Add("islem", "LOGIN");
            request.Headers.Add("ptoken", "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt");

            var bodyString = "{\"e_kullanici_adi\":\"networkAkademi029\",\"e_sifre\":\"sifre029\"}";
            //var content = new StringContent(bodyString, Encoding.UTF8, "application/json");
            //request.Content = content;

            //var response = await client.SendAsync(request);
            //var result = await response.Content.ReadAsStringAsync();

            ViewBag.request = bodyString;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}