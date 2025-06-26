using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class StunningWeapons : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Stunning Weapons");
            // Description.SetDefault("Your weapon can stun enemy");
            //DisplayName.AddTranslation(GameCulture.Russian, "Оглушающее оружие");
            //Description.AddTranslation(GameCulture.Russian, "Ваше оружие может парализовать врагов");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }     
    }
}