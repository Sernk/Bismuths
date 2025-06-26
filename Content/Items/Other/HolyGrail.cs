using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class HolyGrail : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Holy Grail");
            //DisplayName.AddTranslation(GameCulture.Russian, "Святой грааль");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GreaterHealingPotion);
            Item.consumable = false;
            Item.value = Item.buyPrice(1, 0, 0, 0);
        }        

    }
}
