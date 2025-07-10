using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Weapons.Magical
{
    public class GalvornStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.DamageType = DamageClass.Magic;
            Item.width = 24;
            Item.height = 28;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = 2;   
            Item.mana = 10;
            Item.staff[Item.type] = true; 
            Item.UseSound = SoundID.Item21;
            Item.autoReuse = true; 
            Item.shoot = ModContent.ProjectileType<Projectiles.GalvornStaffP>();
            Item.shootSpeed = 18f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, -2f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = Item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.08f;
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.04f;
                Projectile.NewProjectile(source, vector2_1.X, vector2_1.Y, SpeedX, SpeedY, Item.shoot, damage, knockback, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalvornBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<EarthEssence>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}