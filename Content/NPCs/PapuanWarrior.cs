using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Weapons.Throwing;
using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class PapuanWarrior : ModNPC
    {
        private int frame = 0;
        private double frameCounter = 0.0;
        private bool attacked = false;
        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 40;
            NPC.damage = 20;
            NPC.defense = 15;
            NPC.lifeMax = 90;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 15, 0);
            NPC.knockBackResist = 0.7f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = 21;
            AIType = NPCID.GoblinWarrior;;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void AI()
        {
            Player player = Main.player[NPC.target];
            if (!player.dead)
            {
                NPC.TargetClosest(true);
                if ((double)player.Center.X > (double)NPC.Center.X + 1.0) NPC.spriteDirection = 1;
                else if ((double)player.Center.X < (double)NPC.Center.X - 1.0) NPC.spriteDirection = -1;
            }
            double distance = 38.0;
            attacked = (double)Vector2.Distance(player.Center, NPC.Center) < distance && Collision.CanHit(NPC.position, NPC.width, NPC.height, player.position, player.width, player.height) && !player.dead;
            if (attacked)
            {
                NPC.velocity.X = 0.0f; NPC.velocity.Y = 5.0f;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            if (NPC.velocity.Y != 0.0f)
            {
                this.frame = 1;
            }
            else
            {
                if (attacked)
                {
                    this.frameCounter++;
                    if (frame == 5)
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(NPC.spriteDirection == 1 ? NPC.position.X + NPC.width + 8 : NPC.position.X - 8, NPC.position.Y + 15), Vector2.Zero, ModContent.ProjectileType<PapuanWarriorPunch>(), 15, 5f);
                    }
                    if (this.frameCounter >= 40)
                    {
                        this.frameCounter = 0;
                        this.frame = 0;
                    }
                    else
                    {
                        frame = (int)frameCounter / 8 + 2;
                    }
                }
                else
                {
                    this.frameCounter++;
                    if (this.frameCounter >= 84)
                    {
                        this.frameCounter = 0;
                        this.frame = 7;
                    }
                    else
                    {
                        frame = (int)frameCounter / 6 + 7;
                    }
                }
            }           
            NPC.frame.Y = this.frame * frameHeight;          
        }
        public override void HitEffect(NPC.HitInfo hit)
        {

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanWarriorArm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanWarriorHead").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanWarriorBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanWarriorShield").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanWarriorWeapon").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanLeg").Type, 1f);
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ThrowingAxe>(), 20));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WoodenShield>(), 20));
        }
    }
}