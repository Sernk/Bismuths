using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Bismuth.Content.Items.Placeable
{
    public class BismuthumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;        
            //DisplayName.SetDefault("Bismuthum Bar");         
            //DisplayName.AddTranslation(GameCulture.Russian, "Висмутовый слиток");            
        }
        public override void SetDefaults()
        {           
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 70, 0);
            Item.rare = 8;
            Item.maxStack = 9999;
            Item.createTile = ModContent.TileType<Tiles.BismuthumBar>();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BismuthumOre>(), 4);
            recipe.AddTile(77);
            recipe.Register();
        }
    }
}
