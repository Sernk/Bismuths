using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class WoodenShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Wooden Shield");
            //Tooltip.SetDefault("+7% damage resistance");
            //DisplayName.AddTranslation(GameCulture.Russian, "Деревянный щит");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличение поглощения урона на 7%");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.defense = 1;
            Item.rare = 1;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.07f;
        }
    }
}