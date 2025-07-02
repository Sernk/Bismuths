using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class DicePlaying : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dice Game");
            //Description.SetDefault("Prepare your money and just enjoy...");
            //DisplayName.AddTranslation(GameCulture.Russian, "Игра в кости");
            //Description.AddTranslation(GameCulture.Russian, "Готовь свои деньги и наслаждайся");
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
            player.controlMount = false;
            player.controlHook = false;
            player.gravDir = 1f;
        }
    }
}