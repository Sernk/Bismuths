using Terraria;
using Bismuth.Utilities;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Stealth : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cruelty");
            // Description.SetDefault("Your assassin damage and crit. chance are increased, but you get more damage");
            //DisplayName.AddTranslation(GameCulture.Russian, "Подлость");
            //Description.AddTranslation(GameCulture.Russian, "Ваш урон и крит. шанс головореза увеличены, но вы получаете больше урона");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill86lvl > 0)
            {
                player.GetModPlayer<ModP>().assassinDamage += 0.66f;
                player.GetModPlayer<ModP>().assassinCrit += 30;
                player.endurance -= 0.5f;
                player.statDefense -= 25;
                if (player.GetModPlayer<BismuthPlayer>().skill87lvl > 0)
                {
                    player.GetModPlayer<BismuthPlayer>().DodgeChance += 40;
                }
            }           
        }
    }
}