using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;

namespace ResetScore
{
	public class ResetScoreConfig : BasePluginConfig
	{
		[JsonPropertyName("ResetScoreChatTag")]
		public string ResetScoreChatTag { get; set; } = "{Red}[Resetscore]{Default}";

		[JsonPropertyName("OnlyAdmins")]
		public bool OnlyAdmins { get; set; } = false;

		[JsonPropertyName("ResetScoreMessage")]
		public string ResetScoreMessage { get; set; } = "Your score has been reset!";

		[JsonPropertyName("SetScoreMessage")]
		public string SetScoreMessage { get; set; } = "{Gold}{PLAYER}{Default} score has been set!";

		[JsonPropertyName("OnlyAdminsMessage")]
		public string OnlyAdminsMessage { get; set; } = "This command is only for admins!";
	
        public int Version { get; set; } = 1;
    }
}