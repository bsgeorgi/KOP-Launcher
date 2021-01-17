using Newtonsoft.Json.Linq;

namespace kop_launcher.Discord.HookRequest
{
	public class DiscordEmbedField
	{
		public JObject JsonData { get; }

		/// <summary>
		///     Create embed field object
		/// </summary>
		/// <param name="Name">Embed name</param>
		/// <param name="Value">Embed value</param>
		/// <param name="Line">
		///     True => Embed fields will go from left to right.
		///     False => Embed fields will go from top to down.
		/// </param>
		public DiscordEmbedField ( string Name, string Value, bool Line = true )
		{
			var fieldData = new JObject ( );
			fieldData.Add ( "name", Name );
			fieldData.Add ( "value", Value );
			fieldData.Add ( "inline", Line );

			JsonData = fieldData;
		}
	}
}