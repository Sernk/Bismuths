using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    class UnchargedSoulScythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Uncharged Soul Scythe");
            // DisplayName.AddTranslation(GameCulture.Russian, "Незаряженная коса душ");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = 1;
        }
    }
}