using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class GlamdringBlueprint : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Glamdring Blueprint");
            //DisplayName.AddTranslation(GameCulture.Russian, "Чертеж гламдринга");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.questItem = true;
            Item.rare = -11;
        }

    }
}
