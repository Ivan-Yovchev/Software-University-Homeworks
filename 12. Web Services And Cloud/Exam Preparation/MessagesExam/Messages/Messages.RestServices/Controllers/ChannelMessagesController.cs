namespace Messages.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;

    public class ChannelMessagesController : BaseApiController
    {
        [HttpGet]
        [Route("api/channel-messages/{channelName}")]
        public IHttpActionResult GetChannelMessage(string channelName, [FromUri] string limit = null)
        {
            var channel = this.Data.Channels.FirstOrDefault(c => c.Name == channelName);
            if (channel == null)
            {
                return this.Content(HttpStatusCode.NotFound,
                    new {Message = "No channel with name: " + channelName});
            }

            var messages = channel.Messages
                .OrderByDescending(m => m.DateSent)
                .Select(m => new
                {
                    m.Id,
                    m.Text,
                    m.DateSent,
                    Sender = (m.SenderUser != null) ? m.SenderUser.UserName : null
                });

            if (limit != null)
            {
                var limitCount = 0;
                int.TryParse(limit, out limitCount);
                if (limitCount < 1 || limitCount > 1000)
                {
                    return this.BadRequest("Limit should be integer in range [1..1000].");
                }
                else
                {
                    messages = messages.Take(limitCount);
                }
            }

            return this.Ok(messages);
        }

        [HttpPost]
        [Route("api/channel-messages/{channelName}")]
        public IHttpActionResult SendMessageToChanel(string channelName, MessageBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model data cannot be empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var channel = this.Data.Channels.FirstOrDefault(c => c.Name == channelName);
            if (channel == null)
            {
                return this.Content(HttpStatusCode.NotFound,
                    new
                    {
                        Message = "No channel with name: " + channelName
                    });
            }

            var currentUserId = User.Identity.GetUserId();
            var user = this.Data.Users.Find(currentUserId);

            var newMessage = new ChannelMessage
            {
                Text = model.Text,
                DateSent = DateTime.Now,
                Channel = channel,
                SenderUser = user
            };
            this.Data.ChannelMessages.Add(newMessage);
            channel.Messages.Add(newMessage);
            this.Data.SaveChanges();

            if (newMessage.SenderUser == null)
            {
                return this.Ok(new
                {
                    Id = newMessage.Id,
                    Message = "Anonymous message sent to channel " + channelName + "."
                });
            }

            return this.Ok(new
            {
                Id = newMessage.Id,
                Sender = user.UserName,
                Message = "Anonymous message sent to channel " + channelName + "."
            });
        }
    }
}