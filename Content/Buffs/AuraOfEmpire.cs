using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class AuraOfEmpire : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aura Of Empire");
            //DisplayName.AddTranslation(GameCulture.Russian, "Аура империи");
            //Description.SetDefault("The town protects you");
            //Description.AddTranslation(GameCulture.Russian, "Город защищает вас");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }   
    }
}
