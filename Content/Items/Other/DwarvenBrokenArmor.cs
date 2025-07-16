using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class DwarvenBrokenArmor : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 30;
            Item.questItem = true;
        }
    }
}