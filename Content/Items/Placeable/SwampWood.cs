using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class SwampWood : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Swamp Wood");
            //DisplayName.AddTranslation(GameCulture.Russian, "Болотная древесина");
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.SwampWood>();
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = 0;
        }
    }
}
