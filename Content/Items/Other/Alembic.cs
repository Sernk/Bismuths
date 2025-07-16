using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class Alembic : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 3, 50, 0);
            Item.rare = 2;
        }
        public override void UpdateInventory(Player player)
        {
            player.alchemyTable = true;
        }
    }
}