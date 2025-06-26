using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class WarriorsRemains : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Remains of a Warrior");
            //DisplayName.AddTranslation(GameCulture.Russian, "Останки воина");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = -11;
            Item.questItem = true;
        }
    }
}
