using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Hypersonic : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hypersonic");
            // Description.SetDefault("Throwing weapons fly faster");          
            //DisplayName.AddTranslation(GameCulture.Russian, "Сверхзвуковой");
            //Description.AddTranslation(GameCulture.Russian, "Метательные оружия летят быстрее");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.ThrownVelocity *= 2;
        }
    }
}