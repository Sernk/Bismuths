using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class GamblersBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gambrel's Bag");
            // Tooltip.SetDefault("Increases the monetary prize in the dice game by 50%");
            //DisplayName.AddTranslation(GameCulture.Russian, "Мешочек игрока");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличение денежного выигрыша в игре в кости на 50%");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedGamblersBag = true;
        }
    }
}