namespace Messages.RestServices.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new MessagesDbContext())
        {
        }

        public BaseApiController(MessagesDbContext data)
        {
            this.Data = data;
        }

        public MessagesDbContext Data { get; set; }
    }
}