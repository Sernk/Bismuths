using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Misericorde : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 21;
            Item.crit = 0;
            Item.noMelee = false;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            var source = player.GetSource_FromThis();
            if (Main.rand.Next(0, 20) == 0 && !target.boss)
            {
                Projectile.NewProjectile(source, target.position + new Vector2(0f, -100f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 0f, player.whoAmI, 0f);
                Projectile.NewProjectile(source, target.position + new Vector2(70.71067811f, -70.71067811f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 1f, player.whoAmI, 1f);
                Projectile.NewProjectile(source, target.position + new Vector2(100f, 0f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 2f, player.whoAmI, 2f);
                Projectile.NewProjectile(source, target.position + new Vector2(70.71067811f, 70.71067811f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 3f, player.whoAmI, 3f);
                Projectile.NewProjectile(source, target.position + new Vector2(0f, 100f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 4f, player.whoAmI, 4f);
                Projectile.NewProjectile(source, target.position + new Vector2(-70.71067811f, 70.71067811f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 5f, player.whoAmI, 5f);
                Projectile.NewProjectile(source, target.position + new Vector2(-100f, 0f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 6f, player.whoAmI, 6f);
                Projectile.NewProjectile(source, target.position + new Vector2(-70.71067811f, -70.71067811f), Vector2.Zero, ModContent.ProjectileType<MisericordeP>(), 0, 7f, player.whoAmI, 7f);
                modifiers.SourceDamage *= 10000;
            }
        }
    }
}