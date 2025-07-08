using Bismuth.BismuthLayerInPlayer;
using Bismuth.Content.Mounts;
using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Bismuth.Content.Buffs
{
    public class VampireBat : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[this.Type] = true;
            Main.buffNoSave[this.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(MountType<VampireBatMount>(), player, false);
            player.buffTime[buffIndex] = 10;          
            player.ClearBuff(24);
            player.GetModPlayer<BismuthPlayer>().vampbat = true;
        }
    }
}