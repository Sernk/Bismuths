using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class Alembic : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Alembic");
            // Tooltip.SetDefault("33% chance to not consume potion crafting ingredients");
            //DisplayName.AddTranslation(GameCulture.Russian, "Перегонный куб");
            //Tooltip.AddTranslation(GameCulture.Russian, "33% шанс не потратить ингридиенты при создании зелий");
        }
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