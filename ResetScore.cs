using System.Text.RegularExpressions;
using System.Reflection;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Core.Translations;
using Microsoft.Extensions.Logging;


namespace ResetScore
{
    [MinimumApiVersion(141)]
    public class ResetScore : BasePlugin, IPluginConfig<ResetScoreConfig>
    {
        public override string ModuleAuthor => "StefanX";
        public override string ModuleName => "ResetScore";
        public override string ModuleVersion => "1.0.5";

        public ResetScoreConfig Config { get; set; } = new();

        public override void Load(bool hotReload)
        {
            Logger.LogInformation($"ResetScore loaded {ModuleVersion} !");
        }

        public void OnConfigParsed(ResetScoreConfig config)
	    {
            config.ResetScoreChatTag    = ModifyColorValue(config.ResetScoreChatTag);
	    	Config = config;
	    }

        [ConsoleCommand("rs", "ResetScore")]
        public void OnResetScoreCommand(CCSPlayerController? player, CommandInfo command)
        {
            if(!ResetScoreVipFlag(player) && Config.ResetScoreOnlyVip){
                player!.PrintToChat($" {Config.ResetScoreChatTag} " + Localizer["resetscore.resetscore.onlyvips"]);
                return;
            }

            SetScore(player, 0, 0, 0, 0, 0, 0);
            player!.PrintToChat($" {Config.ResetScoreChatTag} " + Localizer["resetscore.resetscore.message"]);
        }

        [ConsoleCommand("setscore", "ResetScore")]
        [CommandHelper(minArgs: 7, usage: "<target> <kiils> <deaths> <assists> <damage> <mvps> <score>", whoCanExecute: CommandUsage.CLIENT_ONLY)]
        public void OnSetScoreCommand(CCSPlayerController? player, CommandInfo command)
        {
            if(!SetScoreAdminFlag(player))
            {
                player!.PrintToChat($" {Config.ResetScoreChatTag} " + Localizer["resetscore.setscore.onlyadmins"]);
                return;
            }

            var arg = command.GetCommandString;
            var splitCmdArgs = Regex.Matches(command.ArgByIndex(1), @"[\""].+?[\""]|[^ ]+").Select(m => m.Value).ToArray();

			List<CCSPlayerController> players = Utilities.GetPlayers();
			foreach (CCSPlayerController target in players)
			{
                StringComparison compare = StringComparison.OrdinalIgnoreCase;

				if(target!.PlayerName.Contains(splitCmdArgs[0], compare))
				{
                    SetScore(target!, int.Parse(command.ArgByIndex(2)), int.Parse(command.ArgByIndex(3)), int.Parse(command.ArgByIndex(4)), int.Parse(command.ArgByIndex(5)), int.Parse(command.ArgByIndex(6)), int.Parse(command.ArgByIndex(7)));
                    player!.PrintToChat($" {Config.ResetScoreChatTag} " + Localizer["resetscore.setscore.message", target.PlayerName]);
				}
			}
        }

        private void SetScore(CCSPlayerController? player, int kills, int deaths, int assists, int damage, int mvps, int score)
        {
            player!.ActionTrackingServices!.MatchStats.Kills  = kills;
            player.ActionTrackingServices.MatchStats.Deaths = deaths;
            player.ActionTrackingServices.MatchStats.Assists = assists;
            player.ActionTrackingServices.MatchStats.Damage = damage;
            player.MVPs = mvps;
            player.Score = score;

            Utilities.SetStateChanged(player, "CCSPlayerController", "m_pActionTrackingServices");
            Utilities.SetStateChanged(player, "CCSPlayerController", "m_iMVPs");
            Utilities.SetStateChanged(player, "CCSPlayerController", "m_iScore");
        }

        private string ModifyColorValue(string msg)
		{
			if (msg.Contains('{'))
			{
				string modifiedValue = msg;
				foreach (FieldInfo field in typeof(ChatColors).GetFields())
				{
					string pattern = $"{{{field.Name}}}";
					if (msg.Contains(pattern, StringComparison.OrdinalIgnoreCase))
					{
						modifiedValue = modifiedValue.Replace(pattern, field.GetValue(null)!.ToString(), StringComparison.OrdinalIgnoreCase);
					}
				}
				return modifiedValue;
			}

			return string.IsNullOrEmpty(msg) ? $"{ChatColors.Red}[ResetScore]{ChatColors.Default} " : msg;
		}

        private bool SetScoreAdminFlag(CCSPlayerController? playerController)
        {
            return AdminManager.PlayerHasPermissions(playerController, Config.SetScoreAdminFlag);
        }

        private bool ResetScoreVipFlag(CCSPlayerController? playerController)
        {
            return AdminManager.PlayerHasPermissions(playerController, Config.ResetScoreVipFlag);
        }
    }
}
