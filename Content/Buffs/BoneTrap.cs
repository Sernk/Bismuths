using Microsoft.Xna.Framework;
using Bismuth.Utilities;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class BoneTrap : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bone Trap");
            //DisplayName.AddTranslation(GameCulture.Russian, "Костяная ловушка");
            // Description.SetDefault("You can't move");
            //Description.AddTranslation(GameCulture.Russian, "Вы не можете двигаться");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.controlJump = false;
            player.controlDown = false;
            player.controlLeft = false;
            player.controlRight = false;
            player.controlUp = false;
            player.controlUseItem = false;
            player.controlUseTile = false;
            player.controlThrow = false;
            player.gravDir = 1f;
            player.noKnockback = true;
            BismuthPlayer.BoneTrapCounter++;
            BismuthPlayer.BoneTrap = true;
        }
    }
}