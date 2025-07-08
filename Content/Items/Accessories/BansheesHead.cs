using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class BansheesHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Banshee's Head");
            //Tooltip.SetDefault("Decreases all nearest enemies' HP \nby 10% and sets their defence to 0");
            //DisplayName.AddTranslation(GameCulture.Russian, "Голова банши");
            //Tooltip.AddTranslation(GameCulture.Russian, "Уменьшает здоровье ближайших врагов \nна 10%, а также снижает их защиту до нуля");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
            Item.width = 20;
            Item.height = 20;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedBansheesHead = true;
        }
    }
}