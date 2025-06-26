using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class DwarvenBrokenArmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Broken Dwarven Armor");
            //DisplayName.AddTranslation(GameCulture.Russian, "Сломанная гномья броня");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
          //  item.rare = 2;
            Item.maxStack = 30;
            Item.questItem = true;
        }

    }
}
