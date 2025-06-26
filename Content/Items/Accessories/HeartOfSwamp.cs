using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Bismuth.Utilities;
using Bismuth.Content.Buffs;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class HeartOfSwamp : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heart Of the Swamp");
            // Tooltip.SetDefault("Increases maximum life by 60 and life regeneration\nGrants immunity to swamp water");
            //DisplayName.AddTranslation(GameCulture.Russian, "Сердце болота");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальный запас здоровья на 60, а также \nрегенерацию здоровья, игрок получает иммунитет к болотной воде");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.accessory = true;
            //item.headSlot = 26;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 60;
            player.buffImmune[ModContent.BuffType<HealthDevourment>()] = true;
            player.buffImmune[20] = true;
            player.lifeRegen += 8;
            player.GetModPlayer<BismuthPlayer>().IsEquippedHeartOfSwamp = true;
            if (!hideVisual)
                BismuthPlayer.HoSvisual = true;
        }
    }
}