using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;

namespace Bismuth.Content.Items.Materials
{
    class PieceOfTabula : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Piece Of the Tabula");
            //DisplayName.AddTranslation(GameCulture.Russian, "Осколок изумрудной скрижали");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.rare = 4;
            Item.maxStack = 30;
        }
    }
}
