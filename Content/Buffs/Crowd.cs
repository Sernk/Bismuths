using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class Crowd : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Crowd");
            //Description.SetDefault("Your max minions count is increased");
            //DisplayName.AddTranslation(GameCulture.Russian, "Толпа");
            //Description.AddTranslation(GameCulture.Russian, "Максимальное количество миньонов увеличено");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill39lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill40lvl == 0)
            {
                player.maxMinions += 4;
            }
         
            if (player.GetModPlayer<BismuthPlayer>().skill40lvl > 0)
            {
                player.maxMinions *= 2;               
            }
        }
    }
}