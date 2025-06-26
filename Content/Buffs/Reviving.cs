using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Reviving : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Reviving");
            // Description.SetDefault("Heroes never die");
            //DisplayName.AddTranslation(GameCulture.Russian, "Возрождение");
            //Description.AddTranslation(GameCulture.Russian, "Герои не умирают");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.invis = true;
            player.controlJump = false;
            player.controlDown = false;
            player.controlLeft = false;
            player.controlRight = false;
            player.controlUp = false;
            player.controlUseItem = false;
            player.controlUseTile = false;
            player.controlThrow = false;
            player.velocity.X = 0f;
            player.velocity.Y = 0f;
            player.gravity = 0f;
            player.oldVelocity.Y = 0f;
            player.immune = true;
            player.statLife = 1;
        }
    }
}