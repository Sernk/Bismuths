using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    //ПОФИКСИТЬ ВОЛОСЫ
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class MarbleMask : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.1f;
            player.GetCritChance(DamageClass.Melee) += 8;
            player.GetCritChance(DamageClass.Ranged) += 8;
            player.GetCritChance(DamageClass.Magic) += 8;
            player.GetCritChance(DamageClass.Throwing) += 8;
            player.GetModPlayer<ModP>().assassinCrit += 8;
            player.GetModPlayer<BismuthPlayer>().IsEquippedMarbleMask = true;
        }
    }
}