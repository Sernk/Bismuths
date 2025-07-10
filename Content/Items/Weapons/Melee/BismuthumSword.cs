using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class BismuthumSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 76;       
            Item.DamageType = DamageClass.Melee;            
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 10;      
            Item.useAnimation = 10;   
            Item.knockBack = 9;
            Item.value = Item.buyPrice(0, 6, 0, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Placeable.BismuthumBar>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}