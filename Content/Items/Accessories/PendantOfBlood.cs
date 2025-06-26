using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class PendantOfBlood : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pendant Of Blood");
            // Tooltip.SetDefault("20% hunger reduction, less satiety - more assassin damage");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кулон крови");
            //Tooltip.AddTranslation(GameCulture.Russian, "Снижение скорости голодания на 33%. Чем меньше сытости - тем\nбольше урона головореза");
        }
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 7, 50, 0);
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedPendant = true;
        }
    }
}