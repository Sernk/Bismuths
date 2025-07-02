using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class ArchmagesAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Amulet of the Archmage");
            // Tooltip.SetDefault("Doesn't give any bonuses");
            //DisplayName.AddTranslation(GameCulture.Russian, "Амулет архимага");
            //Tooltip.AddTranslation(GameCulture.Russian, "Не даёт никаких бонусов");
        }
        public override void Load()
        {
            _ = this.GetLocalization("Quests.DivineEquipment").Value;
            _ = this.GetLocalization("Quests.ArchmagesAmulet").Value;
            _ = this.GetLocalization("Quests.ArchmagesAmulet1").Value;
            _ = this.GetLocalization("Quests.ArchmagesAmulet2").Value;
            _ = this.GetLocalization("Quests.ArchmagesAmulet3").Value;
            _ = this.GetLocalization("Quests.ArchmagesAmulet4").Value;
            _ = this.GetLocalization("Quests.ArchmagesAmulet5").Value;
        }    
        public override void SetDefaults()
        {
            Item.value = 3000000;
            Item.rare = 10;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string DivineEquipment = this.GetLocalization("Quests.DivineEquipment").Value;
            string ArchmagesAmulet = this.GetLocalization("Quests.ArchmagesAmulet").Value;
            string ArchmagesAmulet1 = this.GetLocalization("Quests.ArchmagesAmulet1").Value;
            string ArchmagesAmulet2 = this.GetLocalization("Quests.ArchmagesAmulet2").Value;
            string ArchmagesAmulet3 = this.GetLocalization("Quests.ArchmagesAmulet3").Value;
            string ArchmagesAmulet4 = this.GetLocalization("Quests.ArchmagesAmulet4").Value;
            string ArchmagesAmulet5 = this.GetLocalization("Quests.ArchmagesAmulet5").Value;

            tooltips.Add(new TooltipLine(this.Mod, "ItemName", DivineEquipment) { OverrideColor = new Color?(new Color(0, 239, 239)) });

            int progress = 0;

            if (NPC.downedBoss1) { progress++; }
            if (NPC.downedBoss2) { progress++; }
            if (NPC.downedBoss3) { progress++; }
            if (Main.hardMode) { progress++; }
            if (NPC.downedMechBossAny) { progress++; }
            if (NPC.downedPlantBoss) { progress++; }

            if (progress == 1) { tooltips[3].Text = ArchmagesAmulet; }
            if (progress == 2) { tooltips[3].Text = ArchmagesAmulet1; }
            if (progress == 3) { tooltips[3].Text = ArchmagesAmulet2; }
            if (progress == 4) { tooltips[3].Text = ArchmagesAmulet3; }
            if (progress == 5) { tooltips[3].Text = ArchmagesAmulet4; }
            if (progress == 6) { tooltips[3].Text = ArchmagesAmulet5; }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedArchmagesAmulet = true;
            int progress = 0;
            if (NPC.downedBoss1) { progress++; }
            if (NPC.downedBoss2) { progress++; }
            if (NPC.downedBoss3) { progress++; }
            if (Main.hardMode) { progress++; }
            if (NPC.downedMechBossAny) { progress++; }
            if (NPC.downedPlantBoss) { progress++; }
            if (NPC.downedGolemBoss) { progress++; }

            if (progress == 1)
            {
                player.statManaMax2 += 20;
                player.manaCost -= 0.03f;
            }
            if (progress == 2)
            {
                player.statManaMax2 += 30;
                player.manaCost -= 0.05f;
                player.GetCritChance(DamageClass.Magic) += 3;
            }
            if (progress == 3)
            {
                player.statManaMax2 += 50;
                player.manaCost -= 0.08f;
                player.GetCritChance(DamageClass.Magic) += 5;
                player.GetDamage(DamageClass.Magic) += 0.05f;
            }
            if (progress == 4)
            {
                player.statManaMax2 += 80;
                player.manaCost -= 0.14f;
                player.GetCritChance(DamageClass.Magic) += 9;
                player.GetDamage(DamageClass.Magic) += 0.12f;
              
            }
            if (progress == 5)
            {
                player.statManaMax2 += 120;
                player.manaCost -= 0.19f;
                player.GetCritChance(DamageClass.Magic) += 13;
                player.GetDamage(DamageClass.Magic) += 0.16f;
           
            }
            if (progress == 6)
            {
                player.statManaMax2 += 140;
                player.manaCost -= 0.25f;
                player.GetCritChance(DamageClass.Magic) += 15;
                player.GetDamage(DamageClass.Magic) += 0.2f;            
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LightPartOfArchmagesAmulet>());
            recipe.AddIngredient(ModContent.ItemType<DarkPartOfArchmagesAmulet>());
            recipe.Register();
        }
    }
}