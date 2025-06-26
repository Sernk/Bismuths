using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class ModP : ModPlayer
    {
        public static DamageClass AssassinDamage;

        public float assassinDamage;
        public int assassinCrit;      
        public override void ResetEffects()
        {
            this.assassinDamage = 1;
            this.assassinCrit = 7;          
        }

        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (item.DamageType == AssassinDamage)
            {
                damage *= assassinDamage;
            }
        }

        public override void ModifyWeaponCrit(Item item, ref float crit)
        {
            if (item.DamageType == AssassinDamage) 
            {
                crit += assassinCrit;
            }
        }
    }        
}
