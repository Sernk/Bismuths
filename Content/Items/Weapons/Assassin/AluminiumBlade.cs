using Terraria;
using Terraria.ID;
using Bismuth.Utilities;
using Bismuth.Content.Items.Placeable;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class AluminiumBlade : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 12, 0);
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AluminiumBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
