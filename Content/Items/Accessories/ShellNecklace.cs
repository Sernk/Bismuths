using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class ShellNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shell Necklace");
            // Tooltip.SetDefault("+1% throwing damage and critical strike chance for every 5 wetness points");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ожерелье из ракушек");
            //Tooltip.AddTranslation(GameCulture.Russian, "+1 к урону метателя и его шансу критического урона за каждые 5 влажности");
        }
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedNecklace = true;
        }
    }
}