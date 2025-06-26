using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class BansheesScream : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Banshee's Scream");
            //DisplayName.AddTranslation(GameCulture.Russian, "Крик банши");
            // Description.SetDefault("Your movement speed is decreased");
            //Description.AddTranslation(GameCulture.Russian, "Ваша скорость перемещения уменьшена");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        int beattime = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            beattime++;
            if (beattime % 60 == 10)
                SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/Heartbeat"), player.position);

            player.moveSpeed -= 0.2f;
        }
    }
}