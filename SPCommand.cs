using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth
{
    public class SPCommand : ModCommand
    {
        public override CommandType Type
            => CommandType.Chat;

        public override string Command
            => "getsp";
        public override string Usage => "/getsp amount";
        public override string Description
            => "Gives you Extra SP";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Main.LocalPlayer.GetModPlayer<BismuthPlayer>().SkillPoints += int.Parse(args[0]); 
        }
    }
}