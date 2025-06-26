using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class MinotaurHorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Horn of the Minotaur");
            //DisplayName.AddTranslation(GameCulture.Russian, "Рог минотавра");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 100000;
            Item.questItem = true;
            Item.rare = -11;
        }

    }
}
