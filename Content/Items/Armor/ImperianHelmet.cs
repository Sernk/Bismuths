using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ImperianHelmet : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Imperian Helmet");
            // Tooltip.SetDefault("Critical strike chance is increased by 3%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Имперский шлем");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает шанс критического удара на 3%.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(0, 0, 35, 0);
            Item.rare = 0;
            Item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 3;
            player.GetCritChance(DamageClass.Ranged) += 3;
            player.GetCritChance(DamageClass.Magic) += 3;
            player.GetCritChance(DamageClass.Throwing) += 3;
            player.GetModPlayer<ModP>().assassinCrit += 3;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Lorica>() && legs.type == ModContent.ItemType<Ocrea>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetDamage(DamageClass.Magic) += 0.05f;
            player.GetDamage(DamageClass.Summon) += 0.05f;
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            string ImperianSetBonus = Language.GetTextValue("Mods.Bismuth.ImperianSetBonus");
            player.setBonus = ImperianSetBonus;
        }        
    }
}