namespace Messages.RestServices.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Data.Models;
    using Models;

    public class ChannelsController : BaseApiController
    {
        [HttpGet]
        [Route("api/channels")]
        public IHttpActionResult GetAllChannels()
        {
            var channels = this.Data.Channels
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Id,
                    c.Name
                });
            return this.Ok(channels);
        }

        [HttpGet]
        [Route("api/channels/{id}")]
        public IHttpActionResult GetChannelById(int id)
        {
            var channel = this.Data.Channels.Find(id);
            if (channel == null)
            {
                return this.Content(HttpStatusCode.NotFound,
                    new { Message = "No channel with id: " + id });
            }

            return this.Ok(channel);
        }

        [HttpPost]
        [Route("api/channels")]
        public IHttpActionResult PostChannel(ChannelBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (this.Data.Channels.Any(c => c.Name == model.Name))
            {
                return this.Content(HttpStatusCode.Conflict,
                    new { Message = "Duplicated channel name: " + model.Name });
            }

            var newChannel = new Channel
            {
                Name = model.Name
            };
            this.Data.Channels.Add(newChannel);
            this.Data.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { controller = "ChannelsController", id = newChannel.Id }, newChannel);
        }

        [HttpPut]
        [Route("api/channels/{id}")]
        public IHttpActionResult ModifyChannel(int id, ChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing Data");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var channel = this.Data.Channels.Find(id);
            if (channel == null)
            {
                return this.NotFound();
            }

            if (this.Data.Channels.Any(c => c.Name == model.Name && c.Id != id))
            {
                return this.Content(HttpStatusCode.Conflict,
                    new { Message = "Duplicated channel name: " + model.Name });
            }

            channel.Name = model.Name;
            this.Data.SaveChanges();

            return this.Ok(
                new
                {
                    Message = "Channel #" + id + " edited successfully."
                });
        }

        [HttpDelete]
        [Route("api/channels/{id}")]
        public IHttpActionResult DeleteChannel(int id)
        {
            var channel = this.Data.Channels.Find(id);
            if (channel == null)
            {
                return this.Content(HttpStatusCode.NotFound,
                    new { Message = "No channel with id: " + id });
            }

            if (channel.Messages.Any())
            {
                return this.Content(HttpStatusCode.Conflict,
                    new { Message = "Cannot delete channel #" + id + " because it is not empty." });
            }
            this.Data.Channels.Remove(channel);
            this.Data.SaveChanges();

            return this.Ok(new
            {
                Message = "Channel #" + id + " deleted.",
            });
        }
    }
}