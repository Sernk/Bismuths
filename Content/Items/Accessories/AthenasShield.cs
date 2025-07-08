using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class AthenasShield : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.defense = 1;
            Item.rare = 10;
            Item.accessory = true;
        }
        public override void Load()
        {
            _ = this.GetLocalization("Quests.DivineEquipment").Value; // Ru: Божественная экипировка En: Divine Equipment
            _ = this.GetLocalization("Quests.AthenasShield_1").Value; // Ru: Не даёт никаких бонусов En: Doesn't give any bonuses
            _ = this.GetLocalization("Quests.AthenasShield").Value; // Ru: Увеличивает сопротивлению урону на 5% En: Damage resistance is increased by 5%
            _ = this.GetLocalization("Quests.AthenasShield1").Value; // Ru: Увеличивает сопротивлению урону на 7%, увеличивает \nмаксимальный запас здоровья на 15, восстанавливает 25% \nот полученного урона, если здоровье ниже 20% En: Damage resistance is increased by 7%, +15 HP, \nrestores 25% of received damage if your HP \nis under 20%.
            _ = this.GetLocalization("Quests.AthenasShield2").Value; // Ru: Увеличивает сопротивлению урону на 10%, увеличивает \nмаксимальный запас здоровья на 45, восстанавливает 35% \nот полученного урона и повышает регенерацию в течение 5 секунд, \nесли здоровье ниже 35% En: Damage resistance is increased by 10%, +45 HP, \nrestores 35% of received damage and increases \nregeneration for 5 seconds when your HP is under 35%.
            _ = this.GetLocalization("Quests.AthenasShield3").Value; // Ru: Увеличивает сопротивлению урону на 15%, увеличивает \nмаксимальный запас здоровья на 80, восстанавливает 35% \nот полученного урона и повышает регенерацию в течение 5 секунд, \nесли здоровье ниже 35%. Лечебные зелья восстанавливают на 30% больше здоровья, \nснижает длительность послезельевой болезни на 5 секунд En: Damage resistance is increased by 15%, +80 HP, \nrestores 35% of received damage and increases \nregeneration for 5 seconds when your HP is under 35%. \nHealing potions restore 30% more HP, the cooldown is \nshortened by 5 seconds.
            _ = this.GetLocalization("Quests.AthenasShield4").Value; // Ru: Увеличивает сопротивление урону на 18%, увеличивает \nмаксимальный запас здоровья на 100, восстанавливает 35% \nот полученного урона, увеличивает восстановление здоровья в течение 5 секунд, \nесли здоровье опускается ниже 35%. Лечебные зелья восстанавливают \nна 30% больше здоровья, снижает длительность послезельевой болезни \nна 5 секунд. Значительно повышает регенерацию, если здоровье ниже 200. \nВероятность отражения снарядов равна 15%. En: Damage resistance is increased by 18%, +100 HP, \nrestores 35% of received damage and increases \nregeneration for 5 seconds when your HP is under 35%. \nHealing potions restore 30% more HP, the cooldown is \nshortened by 5 seconds. Greatly increases regeneration when your \nHP is under a 200. 15% chance to parry a projectile
            _ = this.GetLocalization("Quests.AthenasShield5").Value; // Ru: Увеличивает сопротивление урону на 25%, увеличивает \nмаксимальный запас здоровья на 150, восстанавливает 35% \nот полученного урона, увеличивает восстановление здоровья в течение 7 секунд и \nдаёт абсолютную неуязвимость на 3 секунды, если здоровье опускается \nниже 50%. Лечебные зелья восстанавливают на 30% больше здоровья, \nснижает длительность послезельевой болезни на 10 секунд. Значительно \nповышает регенерацию, если здоровье ниже 150. Вероятность \nотражения снарядов равна 15%. En: Damage resistance is increased by 25%, +150 HP, \nrestores 35% of received damage, increases \nregeneration for 7 seconds and grants absolute invulnerability \nfor 3 seconds if your HP falls under 50%. Healing \npotions restore 30% more HP, the cooldown is shortened by 10 \nseconds. Greatly increases regeneration when your HP \nis under 150. 15% chance to parry a projectile
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string DivineEquipment = this.GetLocalization("Quests.DivineEquipment").Value;
            string AthenasShield_1 = this.GetLocalization("Quests.AthenasShield_1").Value;
            string AthenasShield = this.GetLocalization("Quests.AthenasShield").Value;
            string AthenasShield1 = this.GetLocalization("Quests.AthenasShield1").Value;
            string AthenasShield2 = this.GetLocalization("Quests.AthenasShield2").Value;
            string AthenasShield3 = this.GetLocalization("Quests.AthenasShield3").Value;
            string AthenasShield4 = this.GetLocalization("Quests.AthenasShield4").Value;
            string AthenasShield5 = this.GetLocalization("Quests.AthenasShield5").Value;

            tooltips.Add(new TooltipLine(this.Mod, "ItemName", DivineEquipment) { OverrideColor = new Color(0, 239, 239) });

            int progress = LocalizationSystem.GetProgress();
            string description = progress switch
            {
                0 => AthenasShield_1,
                1 => AthenasShield,
                2 => AthenasShield1,
                3 => AthenasShield2,
                4 => AthenasShield3,
                5 => AthenasShield4,
                6 => AthenasShield5,
                _ => null
            };

            if (description != null)
            {
                tooltips.Add(new TooltipLine(this.Mod, "ProgressDescription", description));
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedAthenasShield = true;

            int progress = LocalizationSystem.GetProgress();

            if (progress >= 1)
            {
                Item.defense = 2;
            }
            if (progress >= 2)
            {
                Item.defense = 3;
                player.endurance += 0.07f;
                player.statLifeMax2 += 15;
            }
            if (progress >= 3)
            {
                Item.defense = 5;
                player.endurance += 0.1f;
                player.statLifeMax2 += 45;
            }
            if (progress >= 4)
            {
                Item.defense = 7;
                player.endurance += 0.15f;
                player.statLifeMax2 += 80;
                player.potionDelay -= 300;
                player.potionDelayTime -= 300;
            }
            if (progress >= 5)
            {
                Item.defense = 10;
                player.endurance += 0.18f;
                player.statLifeMax2 += 100;
                player.potionDelay -= 300;
                player.potionDelayTime -= 300;
                player.GetModPlayer<BismuthPlayer>().ReflectChance += 15;
                if (player.statLife <= 200)
                    player.lifeRegen += 30;
            }
            if (progress >= 6)
            {
                Item.defense = 15;
                player.endurance += 0.25f;
                player.statLifeMax2 += 150;
                player.potionDelay -= 600;
                player.potionDelayTime -= 600;
                player.GetModPlayer<BismuthPlayer>().ParryChance += 15;
                if (player.statLife <= 150)
                    player.lifeRegen += 30;
            }
        }
    }
}