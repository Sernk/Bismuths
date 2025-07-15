using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class AriadnesTangle : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.07f;
            player.GetCritChance(DamageClass.Melee) += 7;
            player.GetCritChance(DamageClass.Ranged) += 7;
            player.GetCritChance(DamageClass.Magic) += 7;
            player.GetCritChance(DamageClass.Throwing) += 7;
            player.GetModPlayer<ModP>().assassinCrit += 7;
        }
    }
}