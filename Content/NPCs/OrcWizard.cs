using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Content.Buffs;
using Bismuth.Content.Projectiles;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    public class OrcWizard : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // this.DisplayName.SetDefault("Orc Wizard");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орк-колдун");
            Main.npcFrameCount[NPC.type] = 1;
        }
        int currentframe = 0;
        int tick = 0;
        int currentphase = 0; // 0 - метание; 1 - телепортация;
        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 48;
            NPC.damage = 15;
            NPC.defense = 6;
            NPC.lifeMax = 50;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.friendly = false;
            NPC.noGravity = false;
            NPC.alpha = 255;
            //banner = npc.type;
            //bannerItem = mod.ItemType("OrcWizardBanner");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        Player player;
        Vector2 TpPoint;
      
        int tpcount = 0;
        int attackcount = 0;
        public override void AI()
        {
            player = Main.player[Main.myPlayer];
            if (currentphase == 0)
            {
                UpdateDirection();
                if (currentframe <= 15)
                    currentframe = 16;
                if (currentframe >= 26 && attackcount < 2)
                {
                    currentframe = 16;
                }
                tick++;
                if (tick >= 5)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe == 26)
                {
                    if (attackcount < 2)
                        currentframe = 16;
                    else
                        currentphase = 1;
                }

                if (currentframe == 22 && tick == 1)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, UtilsAI.VelocityToPoint(NPC.Center, player.Center, 16f), ModContent.ProjectileType<OrcWizardOrbP>(), 30, 4f, 0);
                    attackcount++;
                }
              //  if (currentframe >= 31 && currentframe <= 38)
              //      Lighting.AddLight(npc.Center, new Vector3(0.42f, 0.12f, 0.58f));
            }

            if (currentphase == 1)
            {
                if (currentframe > 15)
                    currentframe = 0;
                if (NPC.ai[1] == 0f) // 0 - выбор точки, 1 - раскрутка до тп, 2 - раскрутка после тп.
                {
                Search:
                    if (tpcount > 1000)
                        goto Skip;
                    TpPoint = UtilsAI.RandomPointInArea(new Rectangle((int)NPC.Center.X - 300, (int)NPC.Center.Y - 300, 600, 600));
                    if (Math.Abs(TpPoint.X - NPC.Center.X) < 160f)
                    {
                        tpcount++;
                        goto Search;
                    }
                    if (!UtilsAI.CheckEmptyPlace(TpPoint))
                    {
                        tpcount++;
                        goto Search;

                    }
                    while (!WorldGen.SolidTile(TpPoint.ToTileCoordinates().X, TpPoint.ToTileCoordinates().Y + 1))
                    {

                        TpPoint.Y++;
                        if (TpPoint.Y > NPC.Center.Y + 300)
                        {
                            tpcount++;
                            goto Search;

                        }
                    }
                    if (!UtilsAI.CheckEmptyPlace(TpPoint))
                    {
                        tpcount++;
                        goto Search;

                    }
                Skip:
                    NPC.ai[1] = 1f;
                }
                tick++;
                if (tick >= 4)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe >= 12 && NPC.ai[1] == 1f)
                {
                    NPC.position = TpPoint + new Vector2(0f, -34f);
                    NPC.ai[1] = 2f;
                }
                if (currentframe >= 16)
                    currentphase = 0;
                if (currentframe >= 6 && currentframe <= 25)
                    Lighting.AddLight(NPC.Center, new Vector3(0.42f, 0.12f, 0.58f));
            }
            if (currentphase != 1)
                NPC.ai[1] = 0f;
       
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) != -1)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Buffs/FightingSpiritIcon").Value, NPC.position - Main.screenPosition + new Vector2(4, -34), Color.White * 0.5f);
            }
        }
        public override void OnKill()
        {
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrcishFragment"), Main.rand.Next(0, 3));
            //if (Main.rand.Next(0, 50) == 0)
            //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WaveOfForce"));
        }
        public override void HitEffect(NPC.HitInfo hit)
        {

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWizardArm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWizardBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWizardLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWizardHead").Type, 1f);
            }
        }
        public void ChoosePhase()
        {
            UpdateDirection();
            if (currentphase == 0)
                currentphase = 1;
            else
                currentphase = 0;
        }
        public void UpdateDirection()
        {
            if (player.position.X >= NPC.position.X)
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
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/OrcWizardActually").Value, NPC.position - Main.screenPosition + new Vector2(-16f, 2f), new Rectangle?(new Rectangle(0, 50 * currentframe, 62, 50)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/OrcWizardGlow").Value, NPC.position - Main.screenPosition + new Vector2(-16f, 2f), new Rectangle?(new Rectangle(0, 50 * currentframe, 62, 50)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            return false;
        }
    }
}