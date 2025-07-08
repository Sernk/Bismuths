using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bismuth.Utilities;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.NPCs
{
    public class Snake : ModNPC
    {
        public int currentframe = 0;
        public int currentphase = 0;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 12;
        }

        public override void SetDefaults()
        {
            NPC.width = 70;
            NPC.height = 50;
            NPC.damage = 0;
            NPC.defense = 15;
            NPC.lifeMax = 1;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.lavaImmune = true;
            NPC.immortal = true;
            NPC.friendly = true;
            NPC.rarity = 3;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
        }
        NPC target = null;
        int tick = 0;
        int lifetime = 0;
        public override void AI()
        {
            tick++;
            lifetime++;

            if (target == null || target.life <= 0 || (target != null && target.life > 0 && Vector2.Distance(NPC.Center, target.Center) > 600f))
            {
                currentphase = 0;
                target = UtilsAI.GetNearestNPCDirect(NPC.position, 600f, false, false);
            }
            if (target != null && target.active)
            {
                    currentphase = 1;
                    UpdateDirection();
            }
            if (currentframe == 8 && tick == 6)
            {
                if (NPC.direction == 1)
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(NPC.Center.X - 50, NPC.Center.Y), UtilsAI.VelocityToPoint(new Vector2(NPC.Center.X - 50, NPC.Center.Y), target.Center, 13f), ModContent.ProjectileType<SnakeProj>(), 30, 4f, Main.myPlayer);
                else
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(NPC.Center.X + 50, NPC.Center.Y), UtilsAI.VelocityToPoint(new Vector2(NPC.Center.X + 50, NPC.Center.Y), target.Center, 13f), ModContent.ProjectileType<SnakeProj>(), 30, 4f, Main.myPlayer);
            }

            if (lifetime > 1800)
            {
                NPC.life = -1;
                NPC.checkDead();
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frameHeight * currentframe;
            if (tick >= 8)
            {
                tick = 0;
                currentframe++;
            }
            if (currentphase == 0)
            {
                if (currentframe >= 4)
                    currentframe = 0;
            }
            if (currentphase == 1)
            {
                if (currentframe <= 4 || currentframe >= 12)
                    currentframe = 4;
                if (currentframe == 11 && tick == 16)
                    currentframe = 4;
            }
        }
        public void UpdateDirection()
        {
            if (target.position.X >= NPC.position.X)
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
        }
        public override void OnKill()
        {
            for (int i = 0; i < 40; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 61);
            }
        }
    }
}