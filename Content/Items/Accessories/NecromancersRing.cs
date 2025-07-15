using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class NecromancersRing : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions++;
            player.GetDamage(DamageClass.Summon) += 0.07f;
            if (BismuthWorld.TombstoneCounts <= 20)
            {
                player.statManaMax2 += BismuthWorld.TombstoneCounts * 5;
                player.manaRegen += BismuthWorld.TombstoneCounts * 2;
                player.GetDamage(DamageClass.Summon) += BismuthWorld.TombstoneCounts * 0.015f;
            }
            else
            {
                player.statManaMax2 += 100;
                player.manaRegen += 40;
                player.GetDamage(DamageClass.Summon) += 20 * 0.015f;
                player.maxMinions++;
            }
        }
    }
}