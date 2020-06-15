using System;
using System.Collections.Generic;
using System.Text;

namespace TheChat.Messages
{
    public class PhotoUrlMessage : ChatMessage
    {
        public string Url { get; set; }
        public bool IsFile { get; set; }

        public string Message { get; set; }

        public PhotoUrlMessage()  { }
        public PhotoUrlMessage(string sender) : base(sender)
        {

        }
    }
}
