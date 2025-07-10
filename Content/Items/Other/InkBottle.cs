using Terraria.Audio;
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
    public class InkBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ink Bottle");
            // Tooltip.SetDefault("Creates ink stain at your cursor's position\nRight click to teleport at stain position");
            //DisplayName.AddTranslation(GameCulture.Russian, "Флакон чернил");
            //Tooltip.AddTranslation(GameCulture.Russian, "Создаёт чернильной пятно на месте курсора\nНажмите правую кнопку мыши, чтобы переместиться к пятну");
        }
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
            return UseItem(player);
        }
    }
}

