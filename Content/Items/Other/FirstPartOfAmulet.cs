using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class FirstPartOfAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("First Fragment of the Amulet");
            // Tooltip.SetDefault("Piece of a powerful artifact");
            //DisplayName.AddTranslation(GameCulture.Russian, "Первый фрагмент амулета");
            //Tooltip.AddTranslation(GameCulture.Russian, "Часть могущественного артефакта");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = 3;
            Item.material = true;
        }
    }
}
