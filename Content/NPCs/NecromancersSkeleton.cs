using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class NecromancersSkeleton : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 44;
            NPC.damage = 12;
            NPC.defense = 10;
            NPC.lifeMax = 40;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = Item.buyPrice(0, 0, 3, 7);
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = 15;
            AIType = 21;
            AnimationType = 21;
            NPC.alpha = 255;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void HitEffect(NPC.HitInfo hit)
        {

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                /*Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PapuasGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PapuasGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PapuasGore3"), 1f);*/
            }
        }
        float timer = 0f;
        public override void AI()
        {
            if(NPC.velocity.Y == 0f || timer != 0f)
                timer++;
            if (timer < 65f)
            {
                NPC.aiStyle = -1;
                NPC.alpha = 255;
                NPC.velocity.X = 0.0f;
            }
            else
            {
                NPC.aiStyle = 3;
                NPC.TargetClosest(true);
                NPC.alpha = 0;
                timer = 65f;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {

            if (timer < 65f)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/NecromancersSkeletonSummon").Value, NPC.position - Main.screenPosition + new Vector2(0f, -4f), new Rectangle?(new Rectangle(0, (int)timer / 5 * 48, 44, 48)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/NecromancersSkeletonSummon_Glow").Value, NPC.position - Main.screenPosition + new Vector2(0f, -4f), new Rectangle?(new Rectangle(0, (int)timer / 5 * 48, 44, 48)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }                           
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (timer >= 65f)
            {
                if (this.NPC.spriteDirection < 0)
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/NecromancersSkeleton_Glow").Value, this.NPC.position - Main.screenPosition + new Vector2(17f, 24f), new Rectangle?(this.NPC.frame), Color.White, this.NPC.rotation, new Vector2(25f, 32f), 1f, SpriteEffects.None, 0.0f);
                else
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/NecromancersSkeleton_Glow").Value, this.NPC.position - Main.screenPosition + new Vector2(17f, 24f), new Rectangle?(this.NPC.frame), Color.White, this.NPC.rotation, new Vector2(25f, 32f), 1f, SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
        public override void OnKill()
        {

        }
    }
}