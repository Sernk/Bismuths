using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class EnergyShield : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Energy Shield");
            // Description.SetDefault("You get shield around player, which will reflect projectiles");
            //DisplayName.AddTranslation(GameCulture.Russian, "Энергетический щит");
            //Description.AddTranslation(GameCulture.Russian, "Вокруг вас генерируется щит, отражающий снаряды");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.25f;
            if (player.GetModPlayer<BismuthPlayer>().skill107lvl > 0)
                player.lifeRegen += 16;          
        }
    }
}