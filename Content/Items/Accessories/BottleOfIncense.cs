using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class BottleOfIncense : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bottle Of Incense");
            // Tooltip.SetDefault("+15 charm");
//            DisplayName.AddTranslation(GameCulture.Russian, "Флакон благовоний");
            //Tooltip.AddTranslation(GameCulture.Russian, "+15 обаяния");
        }
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().Charm += 15;
        }
    }
}