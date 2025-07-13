using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Motionless : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.controlJump = false;
            player.controlDown = false;
            player.controlLeft = false;
            player.controlRight = false;
            player.controlUp = false;
            player.controlMount = false;
            player.controlHook = false;
            if (player.GetModPlayer<BismuthPlayer>().skill127lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill128lvl == 0)
            {
                player.GetDamage(DamageClass.Throwing) += 0.6f;
                player.GetCritChance(DamageClass.Throwing) += 30;
                player.endurance += 0.35f;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill128lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill129lvl == 0)
            {
                player.GetDamage(DamageClass.Throwing) += 0.6f;
                player.ThrownVelocity += 0.5f;
                player.GetCritChance(DamageClass.Throwing) += 30;
                player.endurance += 0.45f;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill129lvl > 0)
            {
                player.GetDamage(DamageClass.Throwing) += 0.6f;
                player.ThrownVelocity += 0.5f;
                player.GetCritChance(DamageClass.Throwing) += 30;
                player.endurance += 0.65f;
            }
        }
    }
}