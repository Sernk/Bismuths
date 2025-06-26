using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class FightingSpirit : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fighting Spirit");
            // Description.SetDefault("Your damage is increased, but your damage reflection is decreased");
            //DisplayName.AddTranslation(GameCulture.Russian, "Боевой дух");
            //Description.AddTranslation(GameCulture.Russian, "Ваш урон увеличивается, а поглощение урона снижается");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;

        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.5f;
            player.GetDamage(DamageClass.Ranged) += 0.5f;
            player.GetDamage(DamageClass.Magic) += 0.5f;
            player.GetDamage(DamageClass.Summon) += 0.5f;
            player.GetDamage(DamageClass.Throwing) += 0.5f;
            player.GetModPlayer<ModP>().assassinDamage += 0.5f;
            player.endurance -= 0.5f;
        }
       
    }
}