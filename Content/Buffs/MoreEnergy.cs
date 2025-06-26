using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class MoreEnergy : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("More Energy");
            //Description.SetDefault("Your melee damage is increased by several times");      
            //DisplayName.AddTranslation(GameCulture.Russian, "Больше энергии");
            //Description.AddTranslation(GameCulture.Russian, "Ваш урон ближнего боя увеличен в несколько раз");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill33lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill34lvl == 0)
            {
                player.GetDamage(DamageClass.Melee) *= 3;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill34lvl > 0)
            {
                player.GetDamage(DamageClass.Melee) *= 5;
            }
        }
    }
}