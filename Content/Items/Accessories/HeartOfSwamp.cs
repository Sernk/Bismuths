using Bismuth.Content.Buffs;
using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class HeartOfSwamp : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.accessory = true;
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