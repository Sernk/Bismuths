using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class RingOfOmnipotence : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("TooltipLine2.DivineEquipment").Value; // Ru: Божественная экипировка En: Divine Equipment
            _ = this.GetLocalization("TooltipLine2.RingOfOmnipotence_1").Value; // Ru: Не даёт никаких бонусов En: Doesn't give any bonuses
            _ = this.GetLocalization("TooltipLine2.RingOfOmnipotence").Value; // Ru: Увеличивает все виды урона на 3% En: All types of damage are increased by 3%
            _ = this.GetLocalization("TooltipLine2.RingOfOmnipotence1").Value; // Ru: Увеличивает все виды урона на 7%, увеличивает \nмаксимальный запас здоровья на 15
                                                                               // En: All types of damage are increased by 7%, +15 HP
            _ = this.GetLocalization("TooltipLine2.RingOfOmnipotence2").Value; // Ru: Увеличивает все виды урона на 10%, увеличивает \nмаксимальный запас здоровья на 25, восстановление здоровья \nна 8 ед/сек, увеличивает отражение урона на 8%
                                                                               // En: +10% for all damages, +25 HP, +1 HP/sec, damage reflection \nis increased by 8%
            _ = this.GetLocalization("TooltipLine2.RingOfOmnipotence3").Value; // Ru: Увеличивает все виды урона на 13%, увеличивает \nмаксимальный запас здоровья на 50, восстановление здоровья \nна 3 ед/сек, увеличивает отражение урона на 12%, \nувеличивает шанс уклонения на 5%, увеличивает шанс критического \nудара на 10%
                                                                               // En: +13% for all damages, +50 HP, +3 HP/sec, damage reflection \nis increased by 12%, dodge chance is increased by \n5%, all crit. strike chances are increased by 10%
            _ = this.GetLocalization("TooltipLine2.RingOfOmnipotence4").Value; // Ru: Увеличивает все виды урона на 18%, увеличивает\n максимальный запас здоровья на 75, восстановление здоровья \nна 5 ед/сек, увеличивает отражение урона на 15%, \nувеличивает шанс блока и уклонения на 10%, увеличивает шанс \nкритического удара на 12%, увеличивает все виды урона \nна 5% за каждое надетое кольцо
                                                                               // En: All types of damage are increased by 18%, +75 HP, +5 HP/sec, \ndamage reflection is increased by 15%, dodge and block \nchance are increased by 10%, all crit. \nstrike chances are increased by 12%, all types of damage \nare increased by 5% for every equipped ring
            _ = this.GetLocalization("TooltipLine2.RingOfOmnipotence5").Value; // Ru: Увеличивает все виды урона на 25%, увеличивает \nмаксимальный запас здоровья на 100, восстановление здоровья \nна 8 ед/сек, увеличивает отражение урона на 20%, \nувеличивает шанс блока и уклонения на 15%, увеличивает шанс \nкритического удара на 15%, увеличивает все виды урона \nна 10% за каждое надетое кольцо
                                                                               // En: All types of damage are increased by 25%, +100 HP, +8 HP/sec, \ndamage reflection is increased by 20%, dodge and block \nchance are increased by 15%, all crit. \nstrike chances are increased by 15%, all types of damage \nare increased by 10% for every equipped ring
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 10;
            Item.accessory = true;
            Item.defense = 1;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string DivineEquipment = this.GetLocalization("TooltipLine2.DivineEquipment").Value;
            string RingOfOmnipotence_1 = this.GetLocalization("TooltipLine2.RingOfOmnipotence_1").Value;
            string RingOfOmnipotence = this.GetLocalization("TooltipLine2.RingOfOmnipotence").Value;
            string RingOfOmnipotence1 = this.GetLocalization("TooltipLine2.RingOfOmnipotence1").Value;
            string RingOfOmnipotence2 = this.GetLocalization("TooltipLine2.RingOfOmnipotence2").Value;
            string RingOfOmnipotence3 = this.GetLocalization("TooltipLine2.RingOfOmnipotence3").Value;
            string RingOfOmnipotence4 = this.GetLocalization("TooltipLine2.RingOfOmnipotence4").Value;
            string RingOfOmnipotence5 = this.GetLocalization("TooltipLine2.RingOfOmnipotence5").Value;

            tooltips.Add(new TooltipLine(this.Mod, "ItemName", DivineEquipment) { OverrideColor = new Color?(new Color(0, 239, 239)) });

            int progress = LocalizationSystem.GetProgress();
            string description = progress switch
            {
                0 => RingOfOmnipotence_1,
                1 => RingOfOmnipotence,
                2 => RingOfOmnipotence1,
                3 => RingOfOmnipotence2,
                4 => RingOfOmnipotence3,
                5 => RingOfOmnipotence4,
                6 => RingOfOmnipotence5,
                _ => null
            };
            if (description != null)
            {
                tooltips.Add(new TooltipLine(this.Mod, "ProgressDescription", description));
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedOneRing = true;

            int progress = LocalizationSystem.GetProgress();

            if (NPC.downedBoss1) { progress++; }
            if (NPC.downedBoss2) { progress++; }
            if (NPC.downedBoss3) { progress++; }
            if (Main.hardMode) { progress++; }
            if (NPC.downedMechBossAny) { progress++; }
            if (NPC.downedPlantBoss) { progress++; }
            if (NPC.downedGolemBoss) { progress++; }

            if (progress == 1)
            {
                player.GetDamage(DamageClass.Melee) += 0.03f;
                player.GetDamage(DamageClass.Magic) += 0.03f;
                player.GetDamage(DamageClass.Ranged) += 0.03f;
                player.GetDamage(DamageClass.Summon) += 0.03f;
                player.GetDamage(DamageClass.Melee) += 0.03f;
                player.GetModPlayer<ModP>().assassinDamage += 0.03f;
                Item.defense = 1;
            }
            if (progress == 2)
            {
                player.GetDamage(DamageClass.Melee) += 0.07f;
                player.GetDamage(DamageClass.Magic) += 0.07f;
                player.GetDamage(DamageClass.Ranged) += 0.07f;
                player.GetDamage(DamageClass.Summon) += 0.07f;
                player.GetDamage(DamageClass.Melee) += 0.07f;
                player.GetModPlayer<ModP>().assassinDamage += 0.07f;
                Item.defense = 1;
                player.statLifeMax2 += 15;
            }
            if (progress == 3)
            {
                player.GetDamage(DamageClass.Melee) += 0.1f;
                player.GetDamage(DamageClass.Magic) += 0.1f;
                player.GetDamage(DamageClass.Ranged) += 0.1f;
                player.GetDamage(DamageClass.Summon) += 0.1f;
                player.GetDamage(DamageClass.Melee) += 0.1f;
                player.GetModPlayer<ModP>().assassinDamage += 0.1f;
                Item.defense = 1;
                player.endurance += 0.08f;
                player.statLifeMax2 += 25;
                player.lifeRegen += 2;
            }
            if (progress == 4)
            {
                player.GetDamage(DamageClass.Melee) += 0.13f;
                player.GetDamage(DamageClass.Magic) += 0.13f;
                player.GetDamage(DamageClass.Ranged) += 0.13f;
                player.GetDamage(DamageClass.Summon) += 0.13f;
                player.GetDamage(DamageClass.Melee) += 0.13f;
                player.GetModPlayer<ModP>().assassinDamage += 0.13f;
                player.GetCritChance(DamageClass.Melee) += 10;
                player.GetCritChance(DamageClass.Magic) += 10;
                player.GetCritChance(DamageClass.Ranged) += 10;
                player.GetCritChance(DamageClass.Melee) += 10;
                player.GetModPlayer<ModP>().assassinCrit += 10;
                Item.defense = 2;
                player.endurance += 0.12f;
                player.statLifeMax2 += 50;
                player.lifeRegen += 6;
                player.GetModPlayer<BismuthPlayer>().DodgeChance += 5;
            }
            if (progress == 5)
            {
                player.GetDamage(DamageClass.Melee) += 0.18f + (0.05f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Magic) += 0.18f + (0.05f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Ranged) += 0.18f + (0.05f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Summon) += 0.18f + (0.05f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Melee) += 0.18f + (0.05f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetModPlayer<ModP>().assassinDamage += 0.18f + (0.05f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetCritChance(DamageClass.Melee) += 12;
                player.GetCritChance(DamageClass.Magic) += 12;
                player.GetCritChance(DamageClass.Ranged) += 12;
                player.GetCritChance(DamageClass.Melee) += 12;
                player.GetModPlayer<ModP>().assassinCrit += 12;
                Item.defense = 3;
                player.endurance += 0.15f;
                player.statLifeMax2 += 75;
                player.lifeRegen += 10;
                player.GetModPlayer<BismuthPlayer>().DodgeChance += 10;
                player.GetModPlayer<BismuthPlayer>().BlockChance += 10;
            }
            if (progress == 6)
            {
                player.GetDamage(DamageClass.Melee) += 0.25f + (0.1f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Magic) += 0.25f + (0.1f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Ranged) += 0.25f + (0.1f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Summon) += 0.25f + (0.1f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetDamage(DamageClass.Melee) += 0.25f + (0.1f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetModPlayer<ModP>().assassinDamage += 0.25f + (0.1f * player.GetModPlayer<BismuthPlayer>().RingsCount);
                player.GetCritChance(DamageClass.Melee) += 15;
                player.GetCritChance(DamageClass.Magic) += 15;
                player.GetCritChance(DamageClass.Ranged) += 15;
                player.GetCritChance(DamageClass.Melee) += 15;
                player.GetModPlayer<ModP>().assassinCrit += 15;
                Item.defense = 4;
                player.endurance += 0.20f;
                player.statLifeMax2 += 100;
                player.lifeRegen += 16;
                player.GetModPlayer<BismuthPlayer>().DodgeChance += 15;
                player.GetModPlayer<BismuthPlayer>().BlockChance += 15;
            }
        }
    }
}