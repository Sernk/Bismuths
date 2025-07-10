using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class OrcishSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 6, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<OrcishBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}