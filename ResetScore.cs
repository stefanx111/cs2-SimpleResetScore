using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using System.Threading;

namespace ResetScore;
public class ResetScore : BasePlugin
{
    public override string ModuleAuthor => "StefanX";
    public override string ModuleName => "ResetScore";
    public override string ModuleVersion => "1.0";

    public override void Load(bool hotReload)
    {
        Console.WriteLine("ResetScore loaded!");
    }
   
    [ConsoleCommand("rs", "ResetScore")]
    public void OnResetScoreCommand(CCSPlayerController? player, CommandInfo command)
    {
        player.ActionTrackingServices!.MatchStats.Kills = 0;
        player.ActionTrackingServices!.MatchStats.Deaths = 0;
        player.ActionTrackingServices!.MatchStats.Damage = 0;
        player.ActionTrackingServices!.MatchStats.Assists = 0;
        player.Score = 0;
        player.MVPs = 0;

        player.PrintToChat($"[ResetScore] Your score has been reset !");
    }
}