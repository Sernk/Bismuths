using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class EthernalProjectiles : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ethereal Projectiles");
            //Description.SetDefault("All your projectiles can move through blocks");
            //DisplayName.AddTranslation(GameCulture.Russian, "Призрачные снаряды");
            //Description.AddTranslation(GameCulture.Russian, "Все ваши снаряды игнорируют блоки");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            int i; 
                    
            for (i = 0; i < Main.projectile.Length; i++)
            {
                if (Main.projectile[i].owner == Main.myPlayer)
                {
                    Main.projectile[i].tileCollide = false;
                }
            }            
        }
    }
}