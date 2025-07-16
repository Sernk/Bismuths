using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class RuneRim : ModItem
    {
        public override void SetDefaults()
        {     
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 3, 50, 0);
            Item.rare = 5;             
        }
    }
}