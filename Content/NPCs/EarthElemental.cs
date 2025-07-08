using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class EarthElemental : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;
        float acceleration = 0f;
        int accelerationtick = 0;
        int AIProtocol = 0; // 0 - статик, 1 - перемещение к игроку, 2 - каст.
        NPC target;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 17;
            NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        }
        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 108;
            NPC.damage = 30;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath37;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noTileCollide = true;
            NPC.friendly = true;
            NPC.noGravity = true;
            // npc.alpha = 255;
        }
        Player player = Main.player[Main.myPlayer];
        public override void AI()
        {
            NPC.dontTakeDamage = true;
            if (player.dead || player.FindBuffIndex(ModContent.BuffType<Buffs.EarthElemental>()) == -1)
            {
                NPC.life = -1;
                NPC.checkDead();
            }
            TeleportToPlayer();
            ChooseProtocol();
            if (target == null || target.life <= 0 || (target != null && target.life > 0 && Vector2.Distance(NPC.Center, target.Center) > 1000f))
                target = UtilsAI.GetNearestNPCDirect(NPC.Center, 1000f, false, false);
            if (NPC.velocity != Vector2.Zero)
            {
                accelerationtick++;
                acceleration += 0.015f * accelerationtick;
                if (acceleration > 1f)
                    acceleration = 1f;
            }
            else
            {
                acceleration = 0f;
                accelerationtick = 0;
            }
            if (AIProtocol == 0 || AIProtocol == 2)
                NPC.velocity = Vector2.Zero;
            if (AIProtocol == 1)
                NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y), 2.2f) * (acceleration + 0.01f);
            NPC.ai[0]++;
            if (target != null && NPC.ai[0] % 720 == 0)
            {
                AIProtocol = 2;
            }
            UpdateDirection();                 
        }
        public void TeleportToPlayer()
        {
            if (Vector2.Distance(NPC.Center, player.Center) > 2000f)
            {
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 0, 0f, 0f, 0, default(Color), 0.5f);
                }
                NPC.position = player.position;
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 0, 0f, 0f, 0, default(Color), 0.5f);
                }
            }
        }
        public void ChooseProtocol()
        {
            if (AIProtocol != 2)
            {
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y)) > 15f)
                    AIProtocol = 1;
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y)) < 5f)
                    AIProtocol = 0;
            }
        }
        public void Attack()
        {
            int numberProjectiles = 5 + Main.rand.Next(2);  
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)NPC.position.X + (double)NPC.width * 0.5 + (double)(Main.rand.Next(201) * -NPC.direction) + ((double)target.position.X - (double)NPC.position.X)), (float)((double)NPC.position.Y + (double)NPC.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)NPC.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)target.position.X - vector2_1.X;
                float num13 = (float)target.position.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = 20 / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.04f;  
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.04f;  
                Projectile.NewProjectile(NPC.GetSource_FromThis(), vector2_1.X, vector2_1.Y, SpeedX, SpeedY, ModContent.ProjectileType<DirtBallP>(), 50, 4f, Main.LocalPlayer.whoAmI, 0.0f, (float)Main.rand.Next(5));
            }
            SoundEngine.PlaySound(SoundID.Item20, NPC.position);
        }
        public void UpdateDirection()
        {
            if (NPC.velocity.X < 0.0f)
                NPC.spriteDirection = NPC.direction = 1;
            else if (NPC.velocity.X > 0.0f)
                NPC.spriteDirection = NPC.direction = -1;
            if (AIProtocol == 0)
            {
                NPC.direction = NPC.spriteDirection = -player.direction;
            }
            if (AIProtocol == 2 && target != null)
            {
                if (NPC.Center.X > target.Center.X)
                    NPC.direction = NPC.spriteDirection = 1;
                else
                    NPC.direction = NPC.spriteDirection = -1;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frameHeight * currentframe;
            tick++;
            if (tick >= 5)
            {
                tick = 0;
                currentframe++;
            }
            if (AIProtocol != 2)
            {
                if (currentframe > 7)
                    currentframe = 0;
            }
            else
            {
                if (currentframe < 8)
                    currentframe = 8;
                if (currentframe == 11 && tick == 4)
                    Attack();
                if (currentframe >= 16 && tick == 4)
                    AIProtocol = 1;
            }
        }
        public override void OnKill()
        {
            for (int i = 0; i < 50; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 0, 0f, 0f, 0, default(Color), 0.5f);
            }
        }
    }
}