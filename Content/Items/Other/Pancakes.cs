using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class Pancakes : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.useStyle = 2;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item2;
            Item.value = Item.buyPrice(0, 0, 20, 0);
            Item.rare = 0;
            Item.consumable = true;
            Item.buffType = 26;
            Item.buffTime = 3600;
        }
    }
}