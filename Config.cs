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
	
        public int Version { get; set; } = 1;
    }
}