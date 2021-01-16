﻿using System.IO;

namespace kop_launcher.Discord.HookRequest
{
    public class DiscordHook
    {
        /// <summary>
        /// Create hook request object, can only be created using DiscordHookBuilder.Build()
        /// </summary>
        internal DiscordHook(MemoryStream BodyData, string Bound)
        {
            Body = BodyData;
            Boundary = Bound;
        }

        /// <summary>
        /// Returns the request boundary, this is used to distinguish the files from the message.
        /// This is generated using Time.Now.Ticks 
        /// </summary>
        public string Boundary { get; private set; }
        /// <summary>
        /// Return the request body
        /// </summary>
        public MemoryStream Body { get; private set; }
    }
}
