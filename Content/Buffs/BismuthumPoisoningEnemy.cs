using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class BismuthumPoisoningEnemy : ModBuff
    { 
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }     
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 50;
            npc.color = Color.Silver;
            Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, DustID.SilverCoin);
        }
    }
}