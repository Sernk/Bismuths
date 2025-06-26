using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class AssasinDamageType : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {

            if (damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(
                damageInheritance: 1f,
                critChanceInheritance: 7f,
                attackSpeedInheritance: 0f,
                armorPenInheritance: 0f,
                knockbackInheritance: 0f
            );

        }
        public override bool UseStandardCritCalcs => true;
    }
}
