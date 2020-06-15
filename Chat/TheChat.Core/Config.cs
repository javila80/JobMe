using System;
using System.Collections.Generic;
using System.Text;

namespace TheChat.Core
{
    public static class Config
    {
        public static string MainEndpoint =
            "https://jobmechatfunctions.azurewebsites.net";     
        public static string NegotiateEndpoint =
            $"{MainEndpoint}/api/negotiate";
        public static string MessagesEndpoint =
            $"{MainEndpoint}/api/Messages";
        public static string AddToGroupEndpoint =
            $"{MainEndpoint}/api/AddToGroup";
        public static string LeaveGroupEndpoint =
            $"{MainEndpoint}/api/RemoveFromGroup";
        public static string RoomsEndpoint =
            $"{MainEndpoint}/api/Users";
        public static string UserEndpoint =
            $"{MainEndpoint}/api/User";
    }
}
