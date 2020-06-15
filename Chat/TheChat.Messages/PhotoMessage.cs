using System;
using System.Collections.Generic;
using System.Text;

namespace TheChat.Messages
{
    public class PhotoMessage : ChatMessage
    {
        public string Base64Photo { get; set; }
        public string FileEnding { get; set; }
        public string FileName { get; set; }
        public bool IsFile { get; set; }
        public PhotoMessage() { }

        public PhotoMessage(string sender) : base(sender)
        {

        }
    }
}
