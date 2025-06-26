using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class SwampChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Swamp Chest");
            //DisplayName.AddTranslation(GameCulture.Russian, "Болотный сундук");
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.createTile = ModContent.TileType<Tiles.SwampChest>();
        }
    }
}
