using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Content.Items.Other;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Neck })]
    public class HeartOfDesert : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("Quests.DivineEquipment").Value;
            _ = this.GetLocalization("Quests.HeartOfDesert_1").Value;
            _ = this.GetLocalization("Quests.HeartOfDesert").Value;
            _ = this.GetLocalization("Quests.HeartOfDesert1").Value;
            _ = this.GetLocalization("Quests.HeartOfDesert2").Value;
            _ = this.GetLocalization("Quests.HeartOfDesert3").Value;
            _ = this.GetLocalization("Quests.HeartOfDesert4").Value;
            _ = this.GetLocalization("Quests.HeartOfDesert5").Value;
        }
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Heart of the Desert");
            //Tooltip.SetDefault("Doesn't give any bonuses");
            //DisplayName.AddTranslation(GameCulture.Russian, "Сердце пустыни");
            //Tooltip.AddTranslation(GameCulture.Russian, "Не даёт никаких бонусов");
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

            string HeartOfDesert_1 = this.GetLocalization("Quests.HeartOfDesert_1").Value;
            string HeartOfDesert = this.GetLocalization("Quests.HeartOfDesert").Value;
            string HeartOfDesert1 = this.GetLocalization("Quests.HeartOfDesert1").Value;
            string HeartOfDesert2 = this.GetLocalization("Quests.HeartOfDesert2").Value;
            string HeartOfDesert3 = this.GetLocalization("Quests.HeartOfDesert3").Value;
            string HeartOfDesert4 = this.GetLocalization("Quests.HeartOfDesert4").Value;
            string HeartOfDesert5 = this.GetLocalization("Quests.HeartOfDesert5").Value;

            tooltips.Add(new TooltipLine(this.Mod, "ItemName", DivineEquipment) { OverrideColor = new Color?(new Color(0, 239, 239)) });

            int progress = LocalizationSystem.GetProgress();
            string description = progress switch
            {
                0 => HeartOfDesert_1,
                1 => HeartOfDesert,
                2 => HeartOfDesert1,
                3 => HeartOfDesert2,
                4 => HeartOfDesert3,
                5 => HeartOfDesert4,
                6 => HeartOfDesert5,
                _ => null
            };
            if (description != null)
            {
                tooltips.Add(new TooltipLine(this.Mod, "ProgressDescription", description));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            int progress = LocalizationSystem.GetProgress();

            if (progress == 1)
            {
                player.moveSpeed += 0.03f;
            }
            if (progress == 2)
            {
                player.moveSpeed += 0.05f;
                player.lifeRegen += 2;
            }
            if (progress == 3)
            {
                player.moveSpeed += 0.08f;
                player.lifeRegen += 5;
                Item.defense = 1;
            }
            if (progress == 4)
            {
                player.moveSpeed += 0.12f;
                player.lifeRegen += 8;
                Item.defense = 1;
                if (player.ZoneDesert)
                {
                    player.GetDamage(DamageClass.Melee) += 0.1f;
                    player.GetDamage(DamageClass.Magic) += 0.1f;
                    player.GetDamage(DamageClass.Summon) += 0.1f;
                    player.GetDamage(DamageClass.Ranged) += 0.1f;
                    player.GetDamage(DamageClass.Throwing) += 0.1f;
                    player.GetCritChance(DamageClass.Melee) += 5;
                    player.GetCritChance(DamageClass.Magic) += 5;
                    player.GetCritChance(DamageClass.Ranged) += 5;
                    player.GetCritChance(DamageClass.Throwing) += 5;
                }             
            }
            if (progress == 5)
            {
                player.moveSpeed += 0.20f;
                player.lifeRegen += 12;
                Item.defense = 2;
                if (player.ZoneDesert)
                {
                    player.GetDamage(DamageClass.Melee) += 0.12f;
                    player.GetDamage(DamageClass.Magic) += 0.12f;
                    player.GetDamage(DamageClass.Summon) += 0.12f;
                    player.GetDamage(DamageClass.Ranged) += 0.12f;
                    player.GetDamage(DamageClass.Throwing) += 0.12f;
                    player.moveSpeed += 0.20f;
                    player.GetCritChance(DamageClass.Melee) += 8;
                    player.GetCritChance(DamageClass.Magic) += 8;
                    player.GetCritChance(DamageClass.Ranged) += 8;
                    player.GetCritChance(DamageClass.Throwing) += 8;
                }
                player.buffImmune[194] = true;
            }
            if (progress == 6)
            {
                player.moveSpeed += 0.25f;
                player.lifeRegen += 20;
                Item.defense = 3;
                player.moveSpeed += ((player.statLifeMax2 - player.statLife) / player.statLifeMax2) / 3;
                if (player.ZoneDesert)
                {
                    player.GetDamage(DamageClass.Melee) += 0.15f;
                    player.GetDamage(DamageClass.Magic) += 0.15f;
                    player.GetDamage(DamageClass.Summon) += 0.15f;
                    player.GetDamage(DamageClass.Ranged) += 0.15f;
                    player.GetDamage(DamageClass.Throwing) += 0.15f;
                    player.moveSpeed += 0.25f;
                    player.GetCritChance(DamageClass.Melee) += 10;
                    player.GetCritChance(DamageClass.Magic) += 10;
                    player.GetCritChance(DamageClass.Ranged) += 10;
                    player.GetCritChance(DamageClass.Throwing) += 10;
                }
                player.buffImmune[194] = true;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FirstPartOfAmulet>());
            recipe.AddIngredient(ModContent.ItemType<SecondPartOfAmulet>());
            recipe.AddIngredient(ModContent.ItemType<ThirdPartOfAmulet>());
            recipe.AddIngredient(ModContent.ItemType<FourthPartOfAmulet>());
            recipe.AddIngredient(ModContent.ItemType<FifthPartOfAmulet>());
            recipe.Register();
        }
    }
}
