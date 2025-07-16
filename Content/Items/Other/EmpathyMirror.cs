using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class EmpathyMirror : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = 4;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
        }
    }
}