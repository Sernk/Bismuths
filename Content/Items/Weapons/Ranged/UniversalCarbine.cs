using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class UniversalCarbine : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.damage = 10;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.shoot = AmmoID.Arrow;
            Item.useAmmo = AmmoID.Arrow;
            Item.autoReuse = false;
        }   
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = 5;
                Item.useTime = 26;
                Item.useAnimation = 26;
                Item.damage = 10;
                Item.shoot = AmmoID.Arrow;
                Item.useAmmo = AmmoID.Arrow;
                Item.UseSound = SoundID.Item5;
                Item.autoReuse = false;
                Item.shootSpeed = 12f;
            }
            else
            {
                Item.useStyle = 5;
                Item.useTime = 38;
                Item.useAnimation = 38;
                Item.damage = 12;
                Item.shoot = AmmoID.Bullet;
                Item.useAmmo = AmmoID.Bullet;
                Item.UseSound = SoundID.Item11;
                Item.shootSpeed = 20f;
                Item.autoReuse = false;
             
            }
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 0f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Placeable.AluminiumBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 30);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}