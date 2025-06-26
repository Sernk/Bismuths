using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace Bismuth.Content.Items.Other
{
    public class MasterToolBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Master Tool Box");
            // Tooltip.SetDefault("Lets you destroy scructure tiles");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ящик инструментов мастера");
            //Tooltip.AddTranslation(GameCulture.Russian, "Позволяет разрушать блоки структур");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(5, 0, 0, 0);
            Item.rare = 7;
        }
    }
}