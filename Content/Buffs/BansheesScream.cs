using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class BansheesScream : ModBuff
    {
        public override void SetStaticDefaults()
        {
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