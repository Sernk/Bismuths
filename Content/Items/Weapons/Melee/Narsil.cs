using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class Narsil : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 18;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;
            Item.useAnimation = 22;
            //Item.reuseDelay = 8;
            Item.knockBack = 5;
            Item.value = Item.buyPrice(0, 6, 0, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        { 
            player.GetModPlayer<BismuthPlayer>().NarsilHitbox = hitbox;
            base.UseItemHitbox(player, ref hitbox, ref noHitbox);
        }
    }
}