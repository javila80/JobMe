﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheChat.Messages
{
    public class SimpleTextMessage : ChatMessage
    {
        public string Text { get; set; }
        public SimpleTextMessage() {}

        public SimpleTextMessage(string sender) : base(sender)
        {
            
        }
    }
}
