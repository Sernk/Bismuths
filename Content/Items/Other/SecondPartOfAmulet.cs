using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class SecondPartOfAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Second Fragment of the Amulet");
            // Tooltip.SetDefault("Piece of a powerful artifact");
            //DisplayName.AddTranslation(GameCulture.Russian, "Второй фрагмент амулета");
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
