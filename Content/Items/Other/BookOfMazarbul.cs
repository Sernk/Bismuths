using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Other
{
    public class BookOfMazarbul : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Book Of Mazarbul");
            // Tooltip.SetDefault("Gives you extra skill point");
            //DisplayName.AddTranslation(GameCulture.Russian, "Книга Мазарбул");
            //Tooltip.AddTranslation(GameCulture.Russian, "Даёт вам дополнительное очко умений");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 3;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
            Item.consumable = true;
        }
        public override bool? UseItem(Player player)
        {
            if (!player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
            {
                player.GetModPlayer<BismuthPlayer>().SkillPoints++;
                player.GetModPlayer<BismuthPlayer>().IsReadMazarbul = true;
            }
            return true;
        }
    }
}
