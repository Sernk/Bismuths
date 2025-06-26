using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    class TheMoldofaKeyOfTheSun : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mold of the Sun Key");
           // DisplayName.AddTranslation(GameCulture.Russian, "Слепок ключа солнца");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.rare = 2;
            Item.material = true;
        }
    }
}