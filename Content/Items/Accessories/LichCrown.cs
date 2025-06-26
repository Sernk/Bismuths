using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class LichCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crown of a Lich");
            // Tooltip.SetDefault("You have from 20% to 120% of maximum health \ndepending on the amount of killed enemies");
            //DisplayName.AddTranslation(GameCulture.Russian, "Корона лича");
            //Tooltip.AddTranslation(GameCulture.Russian, "Ваше здоровье составляет от 20% до 120% от начального\nв зависимости от количества убитых врагов");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(!hideVisual)
                BismuthPlayer.lichvisual = true;
            player.GetModPlayer<BismuthPlayer>().IsEquippedLichCrown = true;
        }
    }
}