using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NomadsHood : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nomad's Hood");
            // Tooltip.SetDefault("Assassin damage is increased by 5%. \nCritical strike chance is increased by 13%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Капюшон кочевника");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон головореза на 5%. \nУвеличивает шанс критического удара на 13%.");

        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.rare = 8;
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 13;
            player.GetCritChance(DamageClass.Ranged) += 13;
            player.GetCritChance(DamageClass.Magic) += 13;
            player.GetCritChance(DamageClass.Throwing) += 13;
            player.GetModPlayer<ModP>().assassinCrit += 13;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<NomadsJacket>() && legs.type == ModContent.ItemType<NomadsBoots>();
        }
        public override void UpdateArmorSet(Player player)
        {
            string NomadSetBonus = Language.GetTextValue("Mods.Bismuth.NomadSetBonus");
            player.setBonus = NomadSetBonus;
            player.GetModPlayer<BismuthPlayer>().nomadsetbonus = true;
        }
    }
}