using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheChat.Core.EventHandlers;
using TheChat.Core.Models;
using TheChat.Messages;

namespace TheChat.Core.Services
{
    public interface IChatService
    {
        bool IsConnected { get; }
        string ConnectionToken { get; set; }
        Task InitAsync(string userId);
        Task DisconnectAsync();
        Task SendMessageAsync(ChatMessage message);
        Task JoinChannelAsync(UserConnectedMessage message);
        Task<List<Room>> GetRooms();
        Task LeaveChannelAsync(UserConnectedMessage message);
        Task<List<User>> GetUsersGroup(string group);
        Task<User> GetUser(string userId);
        event EventHandler<MessageEventArgs> OnReceivedMessage;
    }
}
