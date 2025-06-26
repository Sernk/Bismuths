using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class RingRim : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ring Rim");
            //DisplayName.AddTranslation(GameCulture.Russian, "Оправа кольца");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.rare = 0;
        }
    }
}