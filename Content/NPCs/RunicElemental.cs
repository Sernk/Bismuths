using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria.DataStructures;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    public class RunicElemental : ModNPC
    {
        int tick = 0;
        int currentframe = 0;
        int currentphase = 0; // 0 - летит к игроку, 1 - мана- и лайфстил.
        public override void SetStaticDefaults()
        {
            // this.DisplayName.SetDefault("Runic Elemental");
            //DisplayName.AddTranslation(GameCulture.Russian, "Рунический элементаль");
            Main.npcFrameCount[NPC.type] = 10;
            NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 48;
            NPC.height = 64;
            NPC.damage = 30;
            NPC.lifeMax = 600;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit12;
            NPC.DeathSound = SoundID.NPCDeath18;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noTileCollide = true;
            NPC.friendly = false;
            NPC.noGravity = true;
            NPC.alpha = 120;
        }
        Player player = Main.player[Main.myPlayer];
        bool dead = false;
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                dead = true;
                NPC.immortal = true;
                NPC.life = 1;            
            }
        }
        public override void AI()
        {
            if (dead && currentframe == 0)
            {
                Vector2 vec = NPC.position + new Vector2((NPC.spriteDirection == 1 ? 22f : 8f), 42f);
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)vec.X, (int)vec.Y, ModContent.NPCType<RunicElementalDeath>(), 0, -1 * NPC.spriteDirection);
                NPC.direction = NPC.direction;
                NPC.spriteDirection = NPC.spriteDirection;
                Player player = Main.LocalPlayer;
                if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                {
                    player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense));
                    if (player.GetModPlayer<BismuthPlayer>().skill67lvl > 0 && !Main.dayTime)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.2f);
                    }
                    if (player.GetModPlayer<BismuthPlayer>().skill133lvl > 0)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.15f);
                    }
                    if (player.GetModPlayer<BismuthPlayer>().IsBoSRead)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.1f);
                    }
                }
                NPC.life = -1;
                NPC.checkDead();
                return;
            }
            NPC.alpha = 120;
            Lighting.AddLight(NPC.Center, new Vector3(0.65f, 1.04f, 1.12f));
            float dist = Vector2.Distance(player.Center, NPC.Center);
            if (dist < 250f && currentphase == 0 && !player.dead)
                currentphase = 1;
            if ((dist > 280f || dead) && currentphase == 1)
            { 
                currentframe = 9;
                currentphase = 0;
            }
            if (currentphase == 0)
            {
                if (player.dead)
                    NPC.velocity = Vector2.Zero;
                else
                    NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, player.Center, 1.8f);
            }
            if (currentphase == 1)
            {

                if (player.dead)
                    currentphase = 0;
                NPC.velocity = Vector2.Zero;
                NPC.ai[1]++;
                if (NPC.ai[1] % 30 == 0 && !player.dead)
                {
                    if (player.statMana >= 20)
                    {
                        player.statMana -= 20;
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<ManaVampEnemy>(), 0, 0f, 0, NPC.whoAmI);
                    }
                    else
                    {
                        player.statLife -= 20;
                        CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), CombatText.DamagedFriendly, 20);
                        if (player.statLife < 0)
                            player.KillMe(PlayerDeathReason.ByNPC(ModContent.NPCType<RunicElemental>()), 1, 1);
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<VampirismEnemy>(), 0, 0f, 0, NPC.whoAmI);
                    }
                }

            }
            UpdateDirection();
        }
     
        public void UpdateDirection()
        {
            if (Main.player[Main.myPlayer].position.X >= NPC.position.X)
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
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = currentframe * frameHeight;
            tick++;
            if (tick >= 5)
            {
                tick = 0;
                currentframe++;
            }
            if (currentphase == 0)
            {
                if (currentframe > 3 && currentframe != 9)
                    currentframe = 0;
                if (currentframe == 9 && tick == 4)
                    currentframe = 0;
            }
            if (currentphase == 1)
            {
                if (currentframe < 4)
                    currentframe = 4;
                if (currentframe > 8)
                    currentframe = 5;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/RunicElementalGlow").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(0, NPC.frame.Y, 48, 64)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }
        public override void OnKill()
        {
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RuneEssence"));
        }
    }
}