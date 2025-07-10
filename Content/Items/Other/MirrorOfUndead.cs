using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Bismuth.Utilities;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Other
{
    public class MirrorOfUndead : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mirror Of Undead");
            //Tooltip.SetDefault("Teleports you to the location of your last death");
            //DisplayName.AddTranslation(GameCulture.Russian, "Зеркало нежити");
            //Tooltip.AddTranslation(GameCulture.Russian, "Перемещает вас на место последней смерти");
        }
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
        public override bool? UseItem(Player player)
        {
            if (player.GetModPlayer<BismuthPlayer>().DeathPos != Vector2.Zero && player.itemAnimation == 1)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.position + new Vector2(-6f, -24f), new Vector2(0f, -0.3f), ModContent.ProjectileType<MirrorSkullP>(), 0, 0f, Main.player[Main.myPlayer].whoAmI);
                player.immune = true;
                player.immuneTime = 10;
                player.velocity.Y = 0;
                player.noFallDmg = true;
                player.GetModPlayer<BismuthPlayer>().cursepts++;
            }
            return UseItem(player);
        }
        public override void HoldItem(Player player)
        {
            player.itemLocation.Y = player.Center.Y + (player.mount.PlayerOffsetHitbox - player.height * 0.5f + 14f) * player.gravDir;
        }
    }
}

