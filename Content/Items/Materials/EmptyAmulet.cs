using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class EmptyAmulet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.material = true;
        }
    }
}