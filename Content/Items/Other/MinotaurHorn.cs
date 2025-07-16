using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class MinotaurHorn : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 100000;
            Item.questItem = true;
            Item.rare = -11;
        }
    }
}