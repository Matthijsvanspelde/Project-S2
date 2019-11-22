using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System.Threading.Tasks;

namespace SocialNetwork.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserLogic _userLogic;

        public ChatHub(IHttpContextAccessor accessor, IUserLogic userLogic)
        {
            _accessor = accessor;
            _userLogic = userLogic;
        }

        public async Task SendMessage(string username, string message)
        {
            var httpContext = _accessor.HttpContext;
            User user = new User
            {
                Id = (int)httpContext.Session.GetInt32("Id")
            };
            user = _userLogic.GetUserDetails(user);
            username = user.Firstname + " " + user.Middlename + " " + user.Lastname;
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
