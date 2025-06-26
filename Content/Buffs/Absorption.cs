using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Absorption : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Absorption");
            //DisplayName.AddTranslation(GameCulture.Russian, "Поглощение");
            // Description.SetDefault("Your damage reflection is increased");
            //Description.AddTranslation(GameCulture.Russian, "Поглощение урона увеличено");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        int timealive = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            timealive++;
            if (timealive > 480)
                player.endurance += 0.5f;
        }
    }
}