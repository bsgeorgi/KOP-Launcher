using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Discord.Webhook.HookRequest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kop_launcher.Discord.HookRequest
{
	public class DiscordHookBuilder
	{
		/// <summary>
		///     Get or set the file to be uploaded
		/// </summary>
		public FileInfo FileUpload { get; set; }

		/// <summary>
		///     Get the embeds, embeds can be added using Embeds.Add()
		/// </summary>
		public List<DiscordEmbed> Embeds { get; }

		/// <summary>
		///     Get or set the message content
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		///     If true, this message will be read using TTS (only works if enabled on server, to hear the message the users need
		///     to be connected to the target channel)
		/// </summary>
		public bool UseTTS { get; set; }

		private readonly string _bound;

		private readonly string _nick;
		private readonly string _avatar;

		private readonly JObject _json;

		/// <summary>
		///     Create hook request builder, can only be created using DiscordHookBuilder.Create()
		/// </summary>
		private DiscordHookBuilder ( string Nickname, string AvatarUrl )
		{
			_bound = $"------------------------{DateTime.Now.Ticks:x}";

			_nick   = Nickname;
			_avatar = AvatarUrl;

			_json = new JObject ( );

			Embeds = new List<DiscordEmbed> ( );
		}

		/// <summary>
		///     Create a hook request builder
		/// </summary>
		/// <param name="Nickname">Webhook custom nickname</param>
		/// <param name="AvatarUrl">Webhook custom avatar</param>
		/// <returns></returns>
		public static DiscordHookBuilder Create ( string Nickname = null, string AvatarUrl = null )
		{
			return new DiscordHookBuilder ( Nickname, AvatarUrl );
		}

		/// <summary>
		///     Create hook request
		/// </summary>
		/// <returns>Hook request object</returns>
		public DiscordHook Build ( )
		{
			var stream = new MemoryStream ( );

			var boundary = Encoding.UTF8.GetBytes ( $"--{_bound}\r\n" );
			stream.Write ( boundary, 0, boundary.Length );

			if ( FileUpload != null )
			{
				var uploadBody =
					$"Content-Disposition: form-data; name=\"file\"; filename=\"{FileUpload.Name}\"\r\n" +
					"Content-Type: application/octet-stream\r\n\r\n";

				var uploadBodyData = Encoding.UTF8.GetBytes ( uploadBody );
				stream.Write ( uploadBodyData, 0, uploadBodyData.Length );

				var fileBuffer = File.ReadAllBytes ( FileUpload.FullName );
				stream.Write ( fileBuffer, 0, fileBuffer.Length );

				var uploadBodyEnd     = $"\r\n--{_bound}\r\n";
				var uploadBodyEndData = Encoding.UTF8.GetBytes ( uploadBodyEnd );
				stream.Write ( uploadBodyEndData, 0, uploadBodyEndData.Length );
			}

			_json.Add ( "username", _nick );
			_json.Add ( "avatar_url", _avatar );
			_json.Add ( "content", Message );
			_json.Add ( "tts", UseTTS );

			var embeds = new JArray ( );
			foreach ( var embed in Embeds ) embeds.Add ( embed.JsonData );
			if ( embeds.Count > 0 ) _json.Add ( "embeds", embeds );

			var jsonBody = "Content-Disposition: form-data; name=\"payload_json\"\r\n" +
						   "Content-Type: application/json\r\n\r\n" +
						   $"{_json.ToString ( Formatting.None )}\r\n" +
						   $"--{_bound}--";
			var jsonBodyData = Encoding.UTF8.GetBytes ( jsonBody );

			stream.Write ( jsonBodyData, 0, jsonBodyData.Length );
			return new DiscordHook ( stream, _bound );
		}
	}
}