using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Content.Buffs;

namespace Bismuth.Content.NPCs
{
    public class OrcDefender : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orc Defender");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орк-защитник");
            Main.npcFrameCount[NPC.type] = 16;
        }
      
        bool getbuff = false;
        public override void SetDefaults()
        {
            NPC.friendly = false;
            NPC.lifeMax = 120;
            NPC.damage = 15;
            NPC.defense = 25;
            NPC.knockBackResist = 0.1f; //needs to be changed later
            NPC.width = 40;
            NPC.height = 48;
            NPC.npcSlots = 0.7f;
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            //banner = npc.type;
            //bannerItem = mod.ItemType("OrcCrossbowerBanner");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) != -1)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Buffs/FightingSpiritIcon").Value, NPC.position - Main.screenPosition + new Vector2(10, -34), Color.White * 0.5f);
            }
        }
        Player player;
        int currentphase = 0;
        int tick = 0;
        int currentframe = 0;
        int MoveToX = 0;
        int dir = 0;
        int flyingtime = 0;

        public override void AI()
        {
            player = Main.player[NPC.target];
            NPC.TargetClosest(true);
            NPC.spriteDirection = dir;
            if (NPC.velocity.Y != 0f)
                flyingtime++;
            else
                flyingtime = 0;
            if (dir == 0)
                UpdateDirection();
            if (currentphase == 0)
            {
                MoveToX = (int)Main.player[Main.myPlayer].Center.X + 50 * dir;
                NPC.aiStyle = 3;
                NPC.velocity.X = 1.5f * dir;
                if (dir == 1 && MoveToX <= NPC.Center.X)
                    currentphase = 1;
                if (dir == -1 && MoveToX >= NPC.Center.X)
                    currentphase = 1;
            }
            if (currentphase == 1)
            {
                if (flyingtime >= 10)
                    currentphase = 0;
                NPC.velocity.X = 0f;
                if (currentframe == 15 && tick == 9)
                {
                    UpdateTurn();
                    currentphase = 0;
                }
            }
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) != -1 && !getbuff)
            {
                getbuff = true;
                NPC.damage *= 2;
            }
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) == -1 && getbuff)
            {
                getbuff = false;
                NPC.damage /= 2;
            }
        }
        public void UpdateDirection()
        {
            if (Main.LocalPlayer.Center.X >= NPC.Center.X)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }
            NPC.spriteDirection = dir;
        }
        public void UpdateTurn()
        {
            if (dir == 1)
                dir = -1;
            else
                dir = 1;
            NPC.spriteDirection = dir;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcDefenderBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcArm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcDefenderShield").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcHead").Type, 1f);
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (flyingtime >= 10)
                currentframe = 0;
            else
            {
                if (currentphase == 0)
                {
                    tick++;
                    if (tick >= 6)
                    {
                        tick = 0;
                        currentframe++;
                    }
                    if (currentframe < 1 || currentframe > 8)
                        currentframe = 1;
                }
                if (currentphase == 1)
                {
                    tick++;
                    if (tick >= 10)
                    {
                        tick = 0;
                        currentframe++;
                    }
                    if (currentframe < 9)
                        currentframe = 9;
                }
            }
            NPC.frame.Y = currentframe * frameHeight;
        }
        public override void OnKill()
        {
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrcishFragment"), Main.rand.Next(0, 3));
            //if (Main.rand.Next(0, 50) == 0)
            //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrcishShield"));
        }
        public override bool? CanBeHitByProjectile(Projectile projectile)
        {

            if (currentphase == 0 && currentframe != 0)
            {
                if (projectile.Hitbox.Intersects(dir == 1 ? new Rectangle((int)NPC.position.X + 30, (int)NPC.position.Y + 12, 12, 42) : new Rectangle((int)NPC.position.X, (int)NPC.position.Y + 12, 12, 42)))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, 0.0f, 0.0f, 0, new Color(), 1.0f);
                        Main.dust[dust].velocity *= 0.3f;
                    }

                    projectile.direction = -projectile.direction; projectile.spriteDirection = -projectile.spriteDirection;
                    SoundEngine.PlaySound(SoundID.NPCHit4, NPC.position);

                    projectile.friendly = false;
                    projectile.hostile = true;

                    projectile.timeLeft = projectile.timeLeft / 2;
                    projectile.velocity *= -1.0f;
                    projectile.penetrate = 1;
                    projectile.netUpdate = true;
                    return false;
                }

            }
            return null;
        }
    }
}