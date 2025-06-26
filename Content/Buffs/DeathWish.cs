using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class DeathWish : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Death Wish");
            // Description.SetDefault("You get bonus stats, but you start dying without killing enemies");
            //DisplayName.AddTranslation(GameCulture.Russian, "Жажда смерти");
            //Description.AddTranslation(GameCulture.Russian, "Ваши характеристики увеличены, но вы начинаете умирать, если никого не убиваете");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Melee) = 100;
            player.GetCritChance(DamageClass.Ranged) = 100;
            player.GetCritChance(DamageClass.Magic) = 100;
            player.GetCritChance(DamageClass.Throwing) = 100;
            player.GetModPlayer<ModP>().assassinCrit = 100;          
            player.GetModPlayer<BismuthPlayer>().killordietaimer++;
        }
    }
}