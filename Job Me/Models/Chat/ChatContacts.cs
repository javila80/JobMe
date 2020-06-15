using System;
using System.Collections.Generic;
using System.Text;

namespace JobMe.Models.Chat
{
    public class ChatContact
    {
        public int IDChatContact { get; set; }
        public int UserID { get; set; }
        public int ContactUserID { get; set; }
        public bool Status { get; set; }

        public int IDPosition { get; set; }

    }
}
