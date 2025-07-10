using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class BronzeSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Placeable.BronzeBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}