using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Bismuth.Content.Items.Materials
{
    public class EmptyAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Empty Amulet");
            //DisplayName.AddTranslation(GameCulture.Russian, "Пустой амулет");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 30;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.material = true;
        }
    }
}
