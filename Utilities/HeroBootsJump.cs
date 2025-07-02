using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class HeroBootsJump: ExtraJump
    {
        public override Position GetDefaultPosition() => new Before(ExtraJump.SandstormInABottle);
        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new Before(ExtraJump.CloudInABottle);
            yield return new Before(ExtraJump.SandstormInABottle);
            yield return new Before(ExtraJump.BlizzardInABottle);
            yield return new Before(ExtraJump.FartInAJar);
            yield return new Before(ExtraJump.TsunamiInABottle);
            yield return new Before(ExtraJump.UnicornMount);
        }
        public override void OnStarted(Player player, ref bool playSound)
        {
            SoundEngine.PlaySound(SoundID.DoubleJump, player.position);

            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
            player.jump = (int)(Player.jumpHeight * 0.75);
            var source = player.GetSource_FromThis();

            Vector2 basePos = player.position + new Vector2(0f, 4f);
            int projType = ModContent.ProjectileType<HeroBootsJumpEffect>();

            Projectile.NewProjectile(source, basePos, new Vector2(-5f, 3f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(5f, 3f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(-3f, 5f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(3f, 5f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(0f, 6f), projType, 0, 0f, player.whoAmI);
        }
        public override float GetDurationMultiplier(Player player) => 1f;
    }
    public class HeroBootsJump2 : ExtraJump
    {
        public override Position GetDefaultPosition() => new Before(ExtraJump.SandstormInABottle);
        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new Before(ExtraJump.CloudInABottle);
            yield return new Before(ExtraJump.SandstormInABottle);
            yield return new Before(ExtraJump.BlizzardInABottle);
            yield return new Before(ExtraJump.FartInAJar);
            yield return new Before(ExtraJump.TsunamiInABottle);
            yield return new Before(ExtraJump.UnicornMount);
        }
        public override void OnStarted(Player player, ref bool playSound)
        {
            SoundEngine.PlaySound(SoundID.DoubleJump, player.position);

            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
            player.jump = (int)(Player.jumpHeight * 0.75);
            var source = player.GetSource_FromThis();

            Vector2 basePos = player.position + new Vector2(0f, 4f);
            int projType = ModContent.ProjectileType<HeroBootsJumpEffect>();

            Projectile.NewProjectile(source, basePos, new Vector2(-5f, 3f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(5f, 3f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(-3f, 5f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(3f, 5f), projType, 0, 0f, player.whoAmI);
            Projectile.NewProjectile(source, basePos, new Vector2(0f, 6f), projType, 0, 0f, player.whoAmI);
        }
        public override float GetDurationMultiplier(Player player) => 1f;
    }
}
