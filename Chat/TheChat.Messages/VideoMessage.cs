using System;
using System.Collections.Generic;
using System.Text;

namespace TheChat.Messages
{
    public class VideoMessage : ChatMessage
    {
        public bool IsVideo { get; set; }
        public string VideoUrl { get; set; }
        public string VideoImage { get; set; }
        public string Base64Photo { get; set; }
        public string FileEnding { get; set; }
        public string FileName { get; set; }
        public VideoMessage() { }

        public VideoMessage(string sender) : base(sender)
        {

        }
    }
}
