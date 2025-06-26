using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class SteelSkin : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steel Skin");
            // Description.SetDefault("You get bonus stats when you stay");
            //DisplayName.AddTranslation(GameCulture.Russian, "Стальная кожа");
            //Description.AddTranslation(GameCulture.Russian, "Ваши характеристики увеличиваются, пкоа вы не двигаетесь");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.velocity.X == 0 && player.velocity.Y == 0)
            {
                if (player.GetModPlayer<BismuthPlayer>().skill4lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill5lvl == 0)
                {
                    player.lifeRegen += 12;
                    player.statDefense += 6;
                }
                if (player.GetModPlayer<BismuthPlayer>().skill5lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill6lvl == 0 && player.GetModPlayer<BismuthPlayer>().skill7lvl == 0)
                {
                    player.lifeRegen += 20;
                    player.statDefense += 12;
                }
                if (player.GetModPlayer<BismuthPlayer>().skill6lvl > 0 || player.GetModPlayer<BismuthPlayer>().skill7lvl > 0)
                {
                    player.lifeRegen += 30;
                    player.statDefense += 20;
                }
            }
        }
    }
}