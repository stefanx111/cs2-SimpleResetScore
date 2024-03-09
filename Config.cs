using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;

namespace ResetScore
{
	public class ResetScoreConfig : BasePluginConfig
	{
		[JsonPropertyName("ResetScoreChatTag")]
		public string ResetScoreChatTag { get; set; } = "{Red}[Resetscore]{Default}";

		[JsonPropertyName("ResetScoreOnlyVip")]
		public bool ResetScoreOnlyVip { get; set; } = false;

		[JsonPropertyName("SetScoreAdminFlag")]
		public string SetScoreAdminFlag { get; set; } = "@css/cheats";

		[JsonPropertyName("ResetScoreVipFlag")]
		public string ResetScoreVipFlag { get; set; } = "@css/vip";

		[JsonPropertyName("DisableResetScoreMVP")]
		public bool DisableResetScoreMVP { get; set; } = false;
	
        public int Version { get; set; } = 4;
    }
}