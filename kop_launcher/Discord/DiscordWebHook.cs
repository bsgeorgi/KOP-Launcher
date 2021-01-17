using System.Net;
using kop_launcher.Discord.HookRequest;

namespace kop_launcher.Discord
{
	public class DiscordWebhook
	{
		/// <summary>
		///     Set or get webhook url
		/// </summary>
		public string HookUrl { get; set; }

		/// <summary>
		///     Send webhook request
		/// </summary>
		/// <param name="HookRequest">Webhook request content</param>
		public void Hook ( DiscordHook HookRequest )
		{
			ServicePointManager.DefaultConnectionLimit = 20;
			using ( var client = new WebClient ( ) )
			{
				client.Proxy = null;
				client.Headers.Add ( "Content-Type", $"multipart/form-data; boundary={HookRequest.Boundary}" );
				client.UploadData ( HookUrl, HookRequest.Body.ToArray ( ) );
			}
		}
	}
}