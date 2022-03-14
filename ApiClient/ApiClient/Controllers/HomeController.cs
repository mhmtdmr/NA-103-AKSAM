using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApiClient.Models;

namespace ApiClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var response = APILogin();
            string utoken = response.UTOKEN;
            ViewBag.response = utoken;
            //ViewBag.mesaj = response.MESAJ;
            var categories = APIGetCategories(utoken);
            ViewBag.categories = categories;
            //ViewBag.categoriestype = categories.GetType();
            List<Category> cats = categories.ToObject<List<Category>>();
            ViewBag.cats = cats;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View( );
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public dynamic APILogin()
        {
            var url = "http://eronsoftware.com:55301/KULLANICI/authentication/";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["islem"] = "LOGIN";
            httpRequest.Headers["ptoken"] = "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt";
            httpRequest.ContentType = "text";

            var data = @"{""e_kullanici_adi"":""networkAkademi028"",""e_sifre"":""sifre028""}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }
            var result = "";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            result = result.Trim('[');
            result = result.Trim(']');
            dynamic user = JsonConvert.DeserializeObject(result);
            user.GetType();
            return user;
        }
        public dynamic APIGetCategories(string utoken)
        {
            var url = "http://eronsoftware.com:55301/KULLANICI/kategori/";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Headers["islem"] = "KATEGORI_LISTESI";
            httpRequest.Headers["ptoken"] = "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt";
            httpRequest.Headers["utoken"] = utoken;
            httpRequest.ContentType = "text";

            var result = "";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            //result = result.Trim('[');
            //result = result.Trim(']');
            dynamic categories = JsonConvert.DeserializeObject(result);
            return categories;
        }
    }
}