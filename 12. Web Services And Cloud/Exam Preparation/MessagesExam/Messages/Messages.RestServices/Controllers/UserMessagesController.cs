namespace Messages.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    public class UserMessagesController : BaseApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/user/personal-messages")]
        public IHttpActionResult GetPersonalMessages()
        {
            var username = User.Identity.GetUserName();

            IQueryable<UserMessage> messages = this.Data.UserMessages
                .Where(m => m.RecieverUser.UserName == username)
                .OrderByDescending(m => m.DateSent);

            return this.Ok(messages.Select(m => new UserMessageViewModel
            {
                Id = m.Id,
                Text = m.Text,
                DateSent = m.DateSent,
                Sender = (m.SenderUser != null) ? m.SenderUser.UserName : null
            }));
        }

        [HttpPost]
        [Route("api/user/personal-messages")]
        public IHttpActionResult SendMessageToUser(UserMessageBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No data");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var reciever = this.Data.Users.FirstOrDefault(u => u.UserName == model.Recipient);
            if (reciever == null)
            {
                return this.BadRequest("No user with username: " + model.Recipient);
            }

            var senderId = User.Identity.GetUserId();
            var sender = this.Data.Users.Find(senderId);

            var newUserMessage = new UserMessage
            {
                Text = model.Text,
                DateSent = DateTime.Now,
                RecieverUser = reciever,
                SenderUser = sender
            };
            this.Data.UserMessages.Add(newUserMessage);
            this.Data.SaveChanges();

            if (newUserMessage.SenderUser == null)
            {
                return this.Ok(new
                {
                    Id = newUserMessage.Id,
                    Message = "Anonymous message sent successfully to user " + reciever.UserName + "."
                });
            }

            return this.Ok(new
            {
                Id = newUserMessage.Id,
                Sender = sender.UserName,
                Message = "Message sent to user " + reciever.UserName + "."
            });
        }
    }
}