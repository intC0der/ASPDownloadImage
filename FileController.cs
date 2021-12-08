using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;

namespace DownloadImageAPI.Controllers
{
    public class FileController : ApiController
    {
        private readonly string DefaultImage = HostingEnvironment.MapPath("~/Content/default.png");

        public HttpResponseMessage Get()
        {
            Image baseImage = Image.FromFile(DefaultImage);

            using (var memoryImage = new MemoryStream())
            {
                baseImage.Save(memoryImage, ImageFormat.Png);

                byte[] imgData = memoryImage.ToArray();
                MemoryStream ms = new MemoryStream(imgData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new
                System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                return response;

            }


            //using (var ms = new MemoryStream())
            //{
            //    baseImage.Save(ms, ImageFormat.Png);
            //    return Request.CreateResponse(HttpStatusCode.OK, ms.ToArray());
            //}

        }
    }

}