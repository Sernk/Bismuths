using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class NoLimit : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("No Limit!");
            //Description.SetDefault("You can cast spells for free!");
            //DisplayName.AddTranslation(GameCulture.Russian, "Без границ!");
            //Description.AddTranslation(GameCulture.Russian, "Ваши заклинания не требуют маны");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
          
            if (player.GetModPlayer<BismuthPlayer>().skill61lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill62lvl == 0)
            {
                player.manaCost = 0;
            }

            if (player.GetModPlayer<BismuthPlayer>().skill62lvl > 0)
            {
                player.manaCost = 0;
                player.GetCritChance(DamageClass.Magic) += 25;
            }
        }
    }
}