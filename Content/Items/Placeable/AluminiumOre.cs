using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class AluminiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aluminium Ore");
            //DisplayName.AddTranslation(GameCulture.Russian, "Алюминиевая руда");
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
            Item.createTile = ModContent.TileType<Tiles.AluminiumOre>();
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = 0;
        }
    }
}
