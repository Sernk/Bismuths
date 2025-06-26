using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Converter : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Magic Shield");
            //Description.SetDefault("When you get damage, you spend your mana firstly");
            //DisplayName.AddTranslation(GameCulture.Russian, "Волшебный щит");
            //Description.AddTranslation(GameCulture.Russian, "При получении урона сначала расходуется мана");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.manaRegenCount = 0;
           
        }
    }
}