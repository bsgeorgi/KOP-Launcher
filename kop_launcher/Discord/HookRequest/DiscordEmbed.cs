﻿using kop_launcher.Discord.HookRequest;
using Newtonsoft.Json.Linq;

namespace Discord.Webhook.HookRequest
{
	public class DiscordEmbed
	{
		/// <summary>
		///     Get embed request json
		/// </summary>
		public JObject JsonData { get; }

		/// <summary>
		///     Create discord embed
		/// </summary>
		/// <param name="Title">Embed title</param>
		/// <param name="Description">Embed description</param>
		/// <param name="Color">Embed color</param>
		/// <param name="ImageUrl">Embed image</param>
		/// <param name="FooterText">Embed footer text</param>
		/// <param name="FooterIconUrl">Embed footer icon</param>
		/// <param name="Fields">Embed fields</param>
		public DiscordEmbed ( string Title = "",
							  string Description = "",
							  int Color = 0,
							  string ImageUrl = "",
							  string FooterText = "",
							  string FooterIconUrl = "",
							  DiscordEmbedField[] Fields = null )
		{
			var embedData = new JObject {{"title", Title}, {"description", Description}, {"color", Color}};

			var imageData = new JObject {{"url", ImageUrl}};

			var footerData = new JObject {{"text", FooterText}, {"icon_url", FooterIconUrl}};

			embedData.Add ( "image", imageData );
			embedData.Add ( "footer", footerData );

			if ( Fields != null )
			{
				var fieldsData = new JArray ( );
				foreach ( var field in Fields )
					fieldsData.Add ( field.JsonData );
				embedData.Add ( "fields", fieldsData );
			}

			JsonData = embedData;
		}
	}
}