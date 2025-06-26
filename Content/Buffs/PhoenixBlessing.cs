using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class PhoenixBlessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Phoenix Blessing");
            // Description.SetDefault("Your damage reflection is increased by 50%");
            //DisplayName.AddTranslation(GameCulture.Russian, "Благословление феникса");
            //Description.AddTranslation(GameCulture.Russian, "Поглощение урона увеличено на 50%");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;

        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.5f;
        }

    }
}