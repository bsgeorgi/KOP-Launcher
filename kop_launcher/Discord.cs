using System;
using System.IO;
using Discord.Webhook.HookRequest;
using kop_launcher.Discord;
using kop_launcher.Discord.HookRequest;

namespace kop_launcher
{
    class DiscordWebHookHandler
    {
        private DiscordWebhook hook;
        public DiscordWebHookHandler(string uri)
        {
            hook = new DiscordWebhook
            {
                HookUrl = uri
            };
        }

        public bool SendMessage(string messageContent, string embedTitle, string embedDescription,
            bool addFile = false, string filePath = null, int embedColor = 0,
            string embedImageUrl = null, DiscordEmbedField[] embedFields = null,
            string botName = "Champ Bot", string footerImageUrl = null,
            string botImage = "https://cdn.discordapp.com/avatars/794937615224799252/86c77794f7a1a8dfec5a088e94e296db.png?size=256")
        {
            try
            {
                DiscordHookBuilder builder = DiscordHookBuilder.Create(
                    Nickname: botName,
                    AvatarUrl: botImage
                    );

                builder.Message = messageContent;

                if (addFile)
                {
                    builder.FileUpload = new FileInfo(filePath);
                }

                DiscordEmbedField[] fields = embedFields;

                DiscordEmbed embed = new DiscordEmbed(
                    Title: embedTitle,
                    Description: embedDescription,
                    Color: embedColor,
                    ImageUrl: embedImageUrl,
                    FooterText: DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"),
                    FooterIconUrl: footerImageUrl,
                    Fields: fields
                    );

                builder.Embeds.Add(embed);

                DiscordHook discordHook = builder.Build();
                hook.Hook(discordHook);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
