using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class Ringril : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.knockBack = 5.5f;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var source = player.GetSource_ItemUse(Item);
            bool IsGrounded = WorldGen.SolidTile(player.position.ToTileCoordinates().X, player.position.ToTileCoordinates().Y + 3) && WorldGen.SolidTile(player.position.ToTileCoordinates().X + 1, player.position.ToTileCoordinates().Y + 3);
            if (IsGrounded)
            {
                int X = player.position.ToTileCoordinates().X + (player.direction > 0 ? 4 : -2);
                int Y = player.position.ToTileCoordinates().Y + 2;
                while (!(WorldGen.SolidTile(X, Y) && !WorldGen.SolidTile(X, Y - 1) && !WorldGen.SolidTile(X, Y - 2)))
                {
                    Y++;
                    if (Y - (player.position.ToTileCoordinates().Y + 2) > 2)
                    {
                        Y = -1;
                        break;
                    }
                }
                if (Y != -1)
                {
                    Projectile.NewProjectile(source, new Vector2(X * 16 + (player.direction > 0 ? 8 : -8), (Y - 1) * 16), Vector2.Zero, ModContent.ProjectileType<IceSpikeP>(), 20, 4f, Main.LocalPlayer.whoAmI, 0f);
                    int X1 = X + 1;
                    int Y1 = player.position.ToTileCoordinates().Y + 2;
                    while (!(WorldGen.SolidTile(X1, Y1) && !WorldGen.SolidTile(X1, Y1 - 1) && !WorldGen.SolidTile(X1, Y1 - 2)))
                    {
                        Y1++;
                        if (Y1 - (player.position.ToTileCoordinates().Y + 2) > 2)
                        {
                            Y1 = -1;
                            break;
                        }
                    }
                    if (Y1 != -1)
                    {
                        if (Math.Abs(Y - Y1) <= 1)
                            Projectile.NewProjectile(source, new Vector2(X1 * 16 + (player.direction > 0 ? 8 : -8), (Y1 - 1) * 16), Vector2.Zero, ModContent.ProjectileType<IceSpikeP>(), 20, 4f, Main.LocalPlayer.whoAmI, 1f);
                    }

                    int X2 = X + 2;
                    int Y2 = player.position.ToTileCoordinates().Y + 2;
                    while (!(WorldGen.SolidTile(X2, Y2) && !WorldGen.SolidTile(X2, Y2 - 1) && !WorldGen.SolidTile(X2, Y2 - 2)))
                    {
                        Y2++;
                        if (Y2 - (player.position.ToTileCoordinates().Y + 2) > 2)
                        {
                            Y2 = -1;
                            break;
                        }
                    }
                    if (Y2 != -1)
                    {
                        if (Math.Abs(Y1 - Y2) <= 1)
                            Projectile.NewProjectile(source, new Vector2(X2 * 16 + (player.direction > 0 ? 8 : -8), (Y2 - 1) * 16), Vector2.Zero, ModContent.ProjectileType<IceSpikeP>(), 20, 4f, Main.LocalPlayer.whoAmI, 2f);
                    }
                    int X3 = X - 1;
                    int Y3 = player.position.ToTileCoordinates().Y + 2;
                    while (!(WorldGen.SolidTile(X3, Y3) && !WorldGen.SolidTile(X3, Y3 - 1) && !WorldGen.SolidTile(X3, Y3 - 2)))
                    {
                        Y3++;
                        if (Y3 - (player.position.ToTileCoordinates().Y + 2) > 2)
                        {
                            Y3 = -1;
                            break;
                        }
                    }
                    if (Y3 != -1)
                    {
                        if (Math.Abs(Y - Y3) <= 1)
                            Projectile.NewProjectile(source, new Vector2(X3 * 16 + (player.direction > 0 ? 8 : -8), (Y3 - 1) * 16), Vector2.Zero, ModContent.ProjectileType<IceSpikeP>(), 20, 4f, Main.LocalPlayer.whoAmI, 1f);
                    }
                    int X4 = X - 2;
                    int Y4 = player.position.ToTileCoordinates().Y + 2;
                    while (!(WorldGen.SolidTile(X4, Y4) && !WorldGen.SolidTile(X4, Y4 - 1) && !WorldGen.SolidTile(X4, Y4 - 2)))
                    {
                        Y4++;
                        if (Y4 - (player.position.ToTileCoordinates().Y + 2) > 2)
                        {
                            Y4 = -1;
                            break;
                        }
                    }
                    if (Y4 != -1)
                    {
                        if (Math.Abs(Y3 - Y4) <= 1)
                            Projectile.NewProjectile(source, new Vector2(X4 * 16 + (player.direction > 0 ? 8 : -8), (Y4 - 1) * 16), Vector2.Zero, ModContent.ProjectileType<IceSpikeP>(), 20, 4f, Main.LocalPlayer.whoAmI, 2f);
                    }
                }              
            }               
        }
    }
}