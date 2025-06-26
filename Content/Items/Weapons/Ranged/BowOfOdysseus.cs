using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class BowOfOdysseus : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bow Of Odysseus");
            //DisplayName.AddTranslation(GameCulture.Russian, "Лук Одиссея");
            // Tooltip.SetDefault("<right> to charge the bow with three powerfull arrows");
           // Tooltip.AddTranslation(GameCulture.Russian, "<right> чтобы зарядить лук тремя мощными стрелами");
        }

        public override void SetDefaults()
        {                  
            //   item.UseSound = SoundID.Item1;
            Item.damage = 21;
            Item.knockBack = 4f;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 22;
            Item.height = 22;
            Item.useStyle = 5;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 3;
            Item.autoReuse = false;
            Item.useTurn = false;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.shoot = AmmoID.Arrow;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            var bPlayer = player.GetModPlayer<BismuthPlayer>();
            if (player.altFunctionUse != 2)
            {
                if (bPlayer.ArrowCharge < 100)
                {
                    SoundEngine.PlaySound(SoundID.Item5);
                    return true;
                }
                else
                {
                    Vector2 perturbedSpeed1 = new Vector2(speed.X, speed.Y).RotatedBy(MathHelper.ToRadians(5));
                    Vector2 perturbedSpeed2 = new Vector2(speed.X, speed.Y).RotatedBy(MathHelper.ToRadians(-5));
                    Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, ModContent.ProjectileType<MarbleArrow>(), damage, knockback, player.whoAmI, 0.0f, 0.0f);
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed1.X, perturbedSpeed1.Y, ModContent.ProjectileType<MarbleArrow>(), damage, knockback, player.whoAmI, 0.0f, 0.0f);
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, ModContent.ProjectileType<MarbleArrow>(), damage, knockback, player.whoAmI, 0.0f, 0.0f);
                    bPlayer.ArrowCharge = 0;
                    SoundEngine.PlaySound(SoundID.Item5);
                    return false;
                }             
                
            }
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            var bPlayer = player.GetModPlayer<BismuthPlayer>();
            if (player.altFunctionUse == 2 && bPlayer.ArrowCharge == 100)
            {
                return false;
            }
            else if (player.altFunctionUse == 2 && bPlayer.ArrowCharge < 100)
            {
                Item.useTime = 100;
                Item.useAnimation = 100;
                Item.autoReuse = false;
            }
            else 
            {
                if (bPlayer.ArrowCharge < 100)
                {
                    Item.shoot = AmmoID.Arrow;
                    Item.useAmmo = AmmoID.Arrow;
                    Item.useTime = 20;
                    Item.useAnimation = 20;
                    Item.shootSpeed = 20f;
                    Item.damage = 21;
                    Item.knockBack = 4f;
                    Item.autoReuse = true;
                }
                else
                {
                    Item.useAmmo = AmmoID.Arrow;
                    Item.shoot = ModContent.ProjectileType<MarbleArrow>();
                    Item.useTime = 20;
                    Item.useAnimation = 20;
                    Item.shootSpeed = 27f;
                    Item.knockBack = 4f;
                    Item.autoReuse = false;
                }

            }
            return base.CanUseItem(player);
        }
    }
}
