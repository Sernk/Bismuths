using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class Luceat : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 3;
            Item.useStyle = 4;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.UseSound = SoundID.Item6;
        } 
        public override bool? UseItem(Player player)
        {
            if (player.itemAnimation == 2)
            {
                player.position = new Vector2((Main.spawnTileX + 43) * 16, (Main.spawnTileY + 1) * 16 + 6);
                player.immune = true;
                player.immuneTime = 10;
                player.velocity.Y = 0;
                player.noFallDmg = true;
            }
            return false;
        }
    }
}