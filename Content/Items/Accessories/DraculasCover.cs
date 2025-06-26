using Terraria;
using Bismuth.Utilities;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Back, EquipType.Front })]
    public class DraculasCover : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dracula's Cover");
            // Tooltip.SetDefault("Lets you transform into a bat regardless of satiety \nIncreases assassin critical strike chance by 25%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Плащ дракулы");
            //Tooltip.AddTranslation(GameCulture.Russian, "Позволяет превращаться в летучую мышь вне зависимости \nот количества сытости, увеличивает шанс критического урона головореза на 25%");
        }
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 6, 50, 0);
            Item.rare = 5;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedDraculasCover = true;
            player.GetModPlayer<ModP>().assassinCrit += 25;
        }
    }
}