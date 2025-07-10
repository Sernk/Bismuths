using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class InkBottle : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useStyle = 1;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.autoReuse = false;
            Item.maxStack = 30;
            Item.rare = 4;
            Item.value = Item.buyPrice(0, 0, 50, 0);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = 1;
                Item.useTime = 16;
                Item.useAnimation = 16;
            }
            else
            {
                Item.useStyle = 1;
                Item.useTime = 16;
                Item.useAnimation = 16;
            }
            return true;
        }
        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2 && player.GetModPlayer<BismuthPlayer>().InkPos != Vector2.Zero)
            {
                SoundEngine.PlaySound(SoundID.Item8, player.position);
                player.position = player.GetModPlayer<BismuthPlayer>().InkPos;
                player.GetModPlayer<BismuthPlayer>().InkPos = Vector2.Zero;
                player.immune = true;
                player.immuneTime = 10;
                player.velocity.Y = 0;
                player.noFallDmg = true;
                player.inventory[player.selectedItem].stack--;
            }
            if (player.altFunctionUse != 2 && player.GetModPlayer<BismuthPlayer>().InkPos == Vector2.Zero)
            {
                SoundEngine.PlaySound(SoundID.Item85, player.position);
                player.GetModPlayer<BismuthPlayer>().InkPos = Main.MouseWorld;
                Projectile.NewProjectile(player.GetSource_FromThis(), Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<InkStainP>(), 0, 0f);
            }
            return base.UseItem(player);
        }
    }
}