﻿using System;
using System.Collections.Generic;
using System.Text;
using TheChat.Messages;

namespace TheChat.Core.EventHandlers
{
    public class MessageEventArgs
    {
        public ChatMessage Message { get; set; }
        public MessageEventArgs(ChatMessage message)
        {
            Message = message;
        }
    }
}
