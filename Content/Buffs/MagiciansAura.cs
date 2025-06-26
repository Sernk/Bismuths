using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Buffs
{
    public class MagiciansAura : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Magician's Aura");
            // Description.SetDefault("Your damage reflection slightly increased");
           // DisplayName.AddTranslation(GameCulture.Russian, "Магическая аура");
           // Description.AddTranslation(GameCulture.Russian, "Ваше поглощение урона слегка увеличено");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public static int timealive = 0;
        public override void Update(Player player, ref int buffIndex)
        { 
            player.endurance += 0.1f;
            timealive++;
            if (timealive == 1 || timealive == 30)
                Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), Main.LocalPlayer.position, Vector2.Zero, ModContent.ProjectileType<AuraOrbital>(), 0, 0f);
        }
        
    }
}