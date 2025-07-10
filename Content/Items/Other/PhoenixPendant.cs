using Bismuth.Content.Buffs;
using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class PhoenixPendant : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useStyle = 4;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.rare = 4;
            Item.value = Item.sellPrice(0, 2, 0, 0);
        }
        public override bool CanUseItem(Player player)
        {
            return Main.dayTime && !player.HasBuff(ModContent.BuffType<PhoenixBlessing>());
        }
        public override bool? UseItem(Player player)
        {
            if(player.itemAnimation == 1)
                Projectile.NewProjectile(player.GetSource_FromThis(), player.position + new Vector2(-6f, -70f), Vector2.Zero, ModContent.ProjectileType<PhoenixP>(), 0, 0f, player.whoAmI);
            player.AddBuff(ModContent.BuffType<PhoenixBlessing>(), 600);
            return base.UseItem(player);
        }
        public override void HoldItem(Player player)
        {
            player.itemLocation.X = player.Center.X - 8f * player.direction;
            player.itemLocation.Y = player.Center.Y + (player.mount.PlayerOffsetHitbox - player.height * 0.5f + 50f) * player.gravDir;
        }
    }
}