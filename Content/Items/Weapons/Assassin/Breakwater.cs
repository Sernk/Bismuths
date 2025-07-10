using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Breakwater : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.noMelee = false;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 27;
            Item.useAnimation = 27;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useTurn = false;
            Item.noUseGraphic = true;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<BreakwaterHitboxP>()] < 1;
        }
        public override bool? UseItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<BreakwaterHitboxP>()] < 1)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(5.656f * player.direction, -5.656f), ModContent.ProjectileType<BreakwaterHitboxP>(), Item.damage, 4f, Main.player[Main.myPlayer].whoAmI, 0f);
                SoundEngine.PlaySound(SoundID.Item1);
            }
            return base.UseItem(player);
        }
    }
}