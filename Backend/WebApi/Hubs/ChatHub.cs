using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Guid conversationId, Guid senderId, string message)
        {
            await Clients.Group(conversationId.ToString()).SendAsync("ReceiveMessage", senderId, message);
        }

        public async Task JoinConversation(Guid conversationId)
        {
            // todo loading groups?
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
        }
    }
}
