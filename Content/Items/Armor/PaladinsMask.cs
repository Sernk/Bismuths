using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PaladinsMask : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paladin's Mask");
            // Tooltip.SetDefault("Melee damage is increased by 10%, damage resistance is increased by 5%. \nMovement speed is decreased by 5%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Маска паладина");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон в ближнем бою на 10%, увеличивает сопротивляемость уронe на 5%. \nСнижает скорость передвижения на 5%.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 3;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.endurance += 0.05f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PaladinsShell>() && legs.type == ModContent.ItemType<PaladinsLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.GetModPlayer<BismuthPlayer>().paladinssetbonus = true;
            string PaladinSetBonus = Language.GetTextValue("Mods.Bismuth.PaladinSetBonus");
            player.setBonus = PaladinSetBonus;
        }
    }
}