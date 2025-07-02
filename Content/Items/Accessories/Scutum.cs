using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class Scutum : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scutum");
            // Tooltip.SetDefault("Reduces damage taken by 5%");
            //DisplayName.AddTranslation(GameCulture.Russian, "Скутум");
           // Tooltip.AddTranslation(GameCulture.Russian, "Снижение получаемого урона на 5%");
        }
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 1, 20, 0);
            Item.defense = 2;
            Item.rare = 0;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.05f;
        }
    }
}