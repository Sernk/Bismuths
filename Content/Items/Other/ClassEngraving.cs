using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class ClassEngraving : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Class Engraving");
            //DisplayName.AddTranslation(GameCulture.Russian, "Гравировка класса");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 1;
        }
    }
}