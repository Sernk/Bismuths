using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class DiceCup : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dice Cup");
            // Tooltip.SetDefault("Gives you a bonus point in the dice game");
            //DisplayName.AddTranslation(GameCulture.Russian, "Игральный стакан");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает количество очков в игре в кости на 1");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedDiceCup = true;
        }
    }
}