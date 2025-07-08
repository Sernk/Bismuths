using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class SwampQuagmire : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Swamp Quagmire");
            // Description.SetDefault("Your movement speed is decreased");
            //DisplayName.AddTranslation(GameCulture.Russian, "Болотная трясина");
            //Description.AddTranslation(GameCulture.Russian, "Ваша скорость передвижения снижена");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        //bool flag = false;
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed /= 3;
            
        }
    }
}
