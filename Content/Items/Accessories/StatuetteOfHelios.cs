using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bismuth.Content.Items.Accessories
{
    public class StatuetteOfHelios : ModItem
    {        
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(3, 10));
        }
        public override void SetDefaults()
        {           
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.scale = 0.1f;
           // item.Size = new Vector2(20f, 20f);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.statManaMax2 += 50;
            if (Main.dayTime)
                player.manaCost -= 0.2f;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            scale = 0.7f;
            return true;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            scale = 0.7f;
        }
    }
}