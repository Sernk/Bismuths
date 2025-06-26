using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class TribeCurse : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tribe Curse");
            // Description.SetDefault("Ancient magic absorbs you from the inside...");
            //DisplayName.AddTranslation(GameCulture.Russian, "Племенное проклятие");
            //Description.AddTranslation(GameCulture.Russian, "Древняя магия пожирает вас изнутри");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BismuthPlayer>().timer++;
            player.GetModPlayer<BismuthPlayer>().TribeCurse = true;
        }
    }
}
