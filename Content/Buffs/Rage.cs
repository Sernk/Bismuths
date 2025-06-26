using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class Rage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rage");
            //Description.SetDefault("Your melee speed is increased");
            //DisplayName.AddTranslation(GameCulture.Russian, "Злость");
            //Description.AddTranslation(GameCulture.Russian, "Ваша скорость ближнего боя увеличена");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill22lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill23lvl == 0)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.3f;
                player.endurance -= 0.15f;
            }
            else if (player.GetModPlayer<BismuthPlayer>().skill23lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill24lvl == 0)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.4f;
                player.endurance -= 0.1f;
            }
            else if (player.GetModPlayer<BismuthPlayer>().skill24lvl > 0)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.5f;
                player.GetCritChance(DamageClass.Melee) += 15;
            }
        }
    }
}