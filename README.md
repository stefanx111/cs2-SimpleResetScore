# cs2-SimpleResetScore

A simple Reset Score plugin for CS2.

# Requirements:
[CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp) 

# How to use:
1. Install [CounterStrike Sharp](https://github.com/roflmuffin/CounterStrikeSharp) and [Metamod:Source](https://www.sourcemm.net/downloads.php/?branch=master)
3. Download [cs2-SimpleResetScore](https://github.com/stefanx111/cs2-SimpleResetScore/releases/download/1.0.5/cs2-SimpleResetScore.zip)
4. Unzip the archive and upload `ResetScore` folder in the `plugins` folder.

# Commands:
- !rs - Resets your score
- !setscore <target> <kiils> <deaths> <assists> <damage> <mvps> <score> - Set a player's score (only for admins with `@css/cheats`)

# Configure

addons/counterstrikesharp/configs/plugins/ResetScore/ResetScore.json

```json
{
  "ResetScoreChatTag": "{Red}[Resetscore]{Default}",
  "ResetScoreOnlyVip": false,
  "SetScoreAdminFlag": "@css/cheats",
  "ResetScoreVipFlag": "@css/vip",
  "Version": 4, 
  "ConfigVersion": 1
}
```
- ResetScoreChatTag -> Is the chat tag
- OnlyAdmins -> If false `!rs` work for everyone. If true `!rs` works for vips with `ResetScoreVipFlag`
- SetScoreAdminFlag -> Admin flag for !setscore
- ResetScoreVipFlag -> Vip flag for using `!rs` if `ResetScoreOnlyVip` is true 
