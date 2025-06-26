using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class BismuthumPoisoningPlayer : ModBuff
    { 
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bismuthum Poisoning");
            // Description.SetDefault("Your goal is slowly dying");
            //DisplayName.AddTranslation(GameCulture.Russian, "Висмутовое отравление");
            //Description.AddTranslation(GameCulture.Russian, "Цель теряет здоровье");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;       
        }           
    }
}
