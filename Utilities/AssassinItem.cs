using Bismuth.Utilities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Bismuth.Utilities
{
    public class AssassinItem : ModItem
    {
        public override void Load()
        {
            string AssassinDamage = this.GetLocalization("Item.AssassinDamage").Value;
        }
        public override void SetDefaults()
        {
            Item.DamageType = ModP.AssassinDamage ?? DamageClass.Generic;
            Item.crit = 7;
        }
        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
            crit += player.GetModPlayer<ModP>().assassinCrit;
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage *= player.GetModPlayer<ModP>().assassinDamage;
            damage += 5E-06f;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            float cc = Item.crit; 
            ModifyWeaponCrit(player, ref cc); 
        }
        public override bool AllowPrefix(int pre)
        {
            if (SkillsGlobalItems.VanillaCommonPrefixes.Contains(pre) || SkillsGlobalItems.VanillaUniversalPrefixes.Contains(pre))
                return true;
           else
                return false;
        }
        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
            if (pre == -1)
                return false;
            return base.PrefixChance(pre, rand);
        }
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            int pre = rand.Next(SkillsGlobalItems.VanillaCommonPrefixes.Concat(SkillsGlobalItems.VanillaUniversalPrefixes).ToArray());
            return pre;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string AssassinDamage = this.GetLocalization("Item.AssassinDamage").Value;
            var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                string[] split = tt.Text.Split(' ');
                tt.Text = split.First() + " " + AssassinDamage;
            }
            if (Item.crit > 0)
            {
                float crit = Item.crit;
                ModifyWeaponCrit(Main.LocalPlayer, ref crit);
                tt = tooltips.FirstOrDefault(x => x.Name == "CritChance" && x.Mod == "Terraria");
                if (tt != null)
                {
                    tt.Text = crit + "% " + string.Join(" ", tt.Text.Split(' ').Skip(1).ToArray());
                }
                else
                {
                    TooltipLine ttl = new TooltipLine(Mod, "CritChance", crit + "% critical strike chance");
                    int index = tooltips.FindIndex(x => x.Name == "Damage" && x.Mod == "Terraria");
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, ttl);
                    }
                }
            }
        }       
    }
}