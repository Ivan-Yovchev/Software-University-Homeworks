using System;
using System.Web.Http;

namespace WebApplicationRest.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("distance")]
        public double CalcDistance(int startX, int startY, int endX, int endY)
        {
            var deltaX = startX - endX;
            var deltaY = startY - endY;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
