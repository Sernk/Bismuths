using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Magical
{
    public class BismuthumGlove : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 94;           
            Item.DamageType = DamageClass.Magic;            
            Item.mana = 12;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 25;      
            Item.useAnimation = 25;   
            Item.knockBack = 12;
            Item.value = Item.buyPrice(0, 6, 0, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;       
            Item.shoot = ModContent.ProjectileType<Projectiles.BismuthumGloveP>();  
            Item.shootSpeed = 6f;     
            Item.useTurn = true;
            Item.useStyle = 1;  
            Item.noUseGraphic = true; 
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