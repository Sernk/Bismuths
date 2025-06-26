using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class ScoutsReport : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scout's Report");
            //DisplayName.AddTranslation(GameCulture.Russian, "Отчет разведчика");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = -11;
            Item.questItem = true;
        }
    }
}
