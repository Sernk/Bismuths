using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class BerserksRing : ModItem
    {

        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Berserk's Ring");
        //    Tooltip.SetDefault("Item use speed is increased by 30% \n30% less damage resistance, -25 defence");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Кольцо берсерка");
        //    Tooltip.AddTranslation(GameCulture.Russian, "Использование любых предметов ускоряется на 30%\nСопротивляемость урону снижается на 30%, -25 защиты");
        //}
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedBerserksRing = true;
            player.endurance -= 0.3f;
            player.statDefense -= 25;          
        }
    }
}