using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class WarriorsRemains : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = -11;
            Item.questItem = true;
        }
    }
}