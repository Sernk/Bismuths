/*using System;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth
{
    public class AssassinPrefix : ModPrefix
    {
        private float damage = 1f;
        private float speed = 1f;
        private byte crit = 0;
        private float knockback = 1f;
        private float critdmg = 1f;
        private byte dodgechance = 0;
        private float movespeed = 0f;
        public override PrefixCategory Category { get { return PrefixCategory.Custom; } }
        public AssassinPrefix()
        {
        }
        public AssassinPrefix(float damage, float speed, byte crit, float knockback, float critdmg, byte dodgechance, float movespeed)
        {
            this.damage = damage;
            this.speed = speed;
            this.crit = crit;
         
            this.knockback = knockback;
        }
        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Impractically Oversized", new AssassinPrefix(2f, 2f, 4, 2f, 40f, 25, 0.5f));
               // mod.AddPrefix("Miniature", new MeleePrefix(0.8f, 1.5f, 0, 0.5f, 0.7f));
            }
            return false;
        }

        public override float RollChance(Item item)
        {
            return 1f;
        }

        public override bool CanRoll(Item item)
        {
            if (!(item.modItem is AssassinItem))
                return false;
            return (item.damage > 1 || damage >= 1f) && (item.useTime > 4 || speed < 1f);
        }
        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * damage);
            item.useTime = (int)(item.useTime * (1 / speed));
            item.useAnimation = (int)(item.useAnimation * (1 / speed));
            item.reuseDelay = (int)(item.reuseDelay * (1 / speed));
            item.crit += crit;
            item.knockBack *= knockback;
            item.GetGlobalItem<GlobalItems>().dodgechance += dodgechance;
            item.GetGlobalItem<GlobalItems>().movespeed = movespeed;
            item.GetGlobalItem<GlobalItems>().critdmg += critdmg;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult = damage * speed * (1 + crit * 0.01f) * knockback * critdmg * (1 + dodgechance * 0.01f) * (1f + movespeed);
        }
    }
}*/