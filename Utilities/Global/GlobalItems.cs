using Bismuth.Content.Buffs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class GlobalItems : GlobalItem, ILocalizedModType
    {
        public string LocalizationCategory => "BonusArmor";

        public override void Load()
        {
            _ = this.GetLocalization("Ninja.NinjaHood").Value;
            _ = this.GetLocalization("Ninja.NinjaPants").Value;
            _ = this.GetLocalization("Ninja.NinjaShirt").Value;

            _ = this.GetLocalization("Fossil.FossilHelm").Value;
            _ = this.GetLocalization("Fossil.FossilPants").Value;
            _ = this.GetLocalization("Fossil.FossilShirt").Value;
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (player.FindBuffIndex(ModContent.BuffType<FearOfMaze>()) != -1 && item.hammer > 0)
            {
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<DicePlaying>()) != -1)
            {
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<VampireBat>()) != -1)
            {
                return false;
            }
            return base.CanUseItem(item, player);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string NinjaHood = this.GetLocalization("Ninja.NinjaHood").Value;
            string NinjaPants = this.GetLocalization("Ninja.NinjaPants").Value;
            string NinjaShirt = this.GetLocalization("Ninja.NinjaShirt").Value;

            string FossilHelm = this.GetLocalization("Fossil.FossilHelm").Value;
            string FossilPants = this.GetLocalization("Fossil.FossilPants").Value;
            string FossilShirt = this.GetLocalization("Fossil.FossilShirt").Value;
            // Fossil armor tooltips
            if (item.type == ItemID.FossilHelm) tooltips[3].Text = FossilHelm;
            if (item.type == ItemID.FossilPants) tooltips[3].Text = FossilPants;
            if (item.type == ItemID.FossilShirt) tooltips[3].Text = FossilShirt;
            // Ninja armor tooltips
            if (item.type == ItemID.NinjaHood) tooltips[3].Text = NinjaHood;
            if (item.type == ItemID.NinjaPants) tooltips[3].Text = NinjaPants;
            if (item.type == ItemID.NinjaShirt) tooltips[3].Text = NinjaShirt;
        }
        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.FossilHelm)
            {
                player.GetCritChance(DamageClass.Ranged) -= 4;
                player.ThrownVelocity += 0.12f;
            }
            if (item.type == ItemID.FossilPants)
            {
                player.GetCritChance(DamageClass.Ranged) -= 5;
                player.GetCritChance(DamageClass.Throwing) += 10;
            }
            if (item.type == ItemID.FossilShirt)
            {
                player.GetCritChance(DamageClass.Ranged) -= 4;
                player.GetDamage(DamageClass.Throwing) += 0.12f;
            }
            if (item.type == ItemID.NinjaHood)
            {
                player.GetCritChance(DamageClass.Generic) -= 3;
                player.ThrownVelocity += 0.09f;
            }
            if (item.type == ItemID.NinjaPants)
            {
                player.GetCritChance(DamageClass.Generic) -= 3;
                player.GetCritChance(DamageClass.Throwing) += 7;
            }
            if (item.type == ItemID.NinjaShirt)
            {
                player.GetCritChance(DamageClass.Generic) -= 3;
                player.GetDamage(DamageClass.Throwing) += 0.09f;
            }
        }
    }
}