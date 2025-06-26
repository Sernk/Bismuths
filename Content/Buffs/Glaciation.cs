using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class Glaciation : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Glaciation");          
            // Description.SetDefault("You can't move, but your health regeneration is significantly increased");
            //DisplayName.AddTranslation(GameCulture.Russian, "Оледенение");
            //Description.AddTranslation(GameCulture.Russian, "Вы не можете двигаться, однако ваша регенерация здоровья серьезно увеличена");
            Main.debuff[Type] = false;
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
            player.gravity *= 2;
            player.gravDir = 1f;
            player.lifeRegen += 80;
            BismuthPlayer.GlaciationCounter++;
        }
    }
}