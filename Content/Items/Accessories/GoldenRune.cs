using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Back, EquipType.Front })]
    public class GoldenRune : ModItem
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Golden Fleece");
        //    Tooltip.SetDefault("Increases life regeneration. Allows you to convert \nmana into health if your HP is under 50%.");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Золотое руно");
        //    Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию здоровья. Позволяет вам \nпреобразовывать ману в здоровье, если его меньше 50%");
        //}
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 5;
            Item.accessory = true;
            Item.width = 40;
            Item.height = 40;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 4;
            player.GetModPlayer<BismuthPlayer>().IsEquippedGoldenRune = true;
        }
    }
}