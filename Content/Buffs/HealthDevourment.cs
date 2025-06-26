using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class HealthDevourment : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Health Devourment");
            // Description.SetDefault("Your health decreases rapidly");          
            //DisplayName.AddTranslation(GameCulture.Russian, "Пожирание здоровья");
            //Description.AddTranslation(GameCulture.Russian, "Важе здоровье быстро уменьшается");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;

        }
        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
}