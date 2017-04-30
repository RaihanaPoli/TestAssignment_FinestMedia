
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FinestMedia.Controllers
{
    public class HourConsumptionController : Controller
    {
        // GET: HourConsumption
        public ActionResult Index()
        {

                ViewBag.ShowList = false;
                return View();

        }

        [HttpGet]
        public ContentResult XmlExample(string startDate, string EndDate)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://finestmedia.ee/kwh/?start=" + startDate + "&end=" + EndDate + "");
            string xml = null;
            using (WebResponse response = request.GetResponse())
            {
                using (var xmlStream = new StreamReader(response.GetResponseStream()))
                {
                    xml = xmlStream.ReadToEnd();
                }
            }

            return Content(xml, "text/xml");
        }

    }
}