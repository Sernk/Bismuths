using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class BismuthumCrossbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 58;          
            Item.DamageType = DamageClass.Ranged;             
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 12;      
            Item.useAnimation = 12;   
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;       
            Item.shoot = AmmoID.Arrow; 
            Item.shootSpeed = 13f;   
            Item.useStyle = 5;  
            Item.useAmmo = AmmoID.Arrow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BismuthumBar>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }     
    }
}