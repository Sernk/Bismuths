using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.NPCs;

namespace Bismuth.Content.Buffs
{
    public class AirElemental : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.AirElemental>()))
                NPC.NewNPC(player.GetSource_FromThis(), (int)player.position.X, (int)player.position.Y, ModContent.NPCType<NPCs.AirElemental>());
        }
    }
}