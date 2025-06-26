using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Bismuth.Content.NPCs
{
    public class AlchemistDeath : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;

        public override void SetDefaults()
        {
            NPC.width = 90;
            NPC.height = 48;
            NPC.lifeMax = 10;
            NPC.dontTakeDamage = true;
            NPC.dontCountMe = true;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
        }
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 18;
        }
        public override void AI()
        {
           
                NPC.direction = (int)NPC.ai[0];
                NPC.spriteDirection = (int)NPC.ai[0];
            
            tick++;
            if (currentframe <= 17 && tick > 5)
            {
                currentframe++;
                tick = 0;
            }
            if (tick > 120)
            {
                NPC.life = -1;
                NPC.checkDead();
                // npc.NPCLoot();
            }
            NPC.velocity.Y = 4f;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {        
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/AlchemistDeath").Value, NPC.position - Main.screenPosition + new Vector2(NPC.spriteDirection == 1 ? 46f : -20f, 4f), new Rectangle?(new Rectangle(0, currentframe * 48, 90, 48)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);           
            return false;
        }
        public override void OnKill()
        {
            for(int i = 0; i < 5; i++)
                Gore.NewGore(NPC.GetSource_Death(), NPC.Center + (NPC.direction == -1 ? new Vector2(-50f, 0f) : new Vector2(50f, 0f)), NPC.velocity, Main.rand.Next(11, 14), Main.rand.NextFloat(0.5f, 1f));
            //Item.NewItem((int)npc.Center.X + (npc.direction == -1 ? - 50 : 50), (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("PoisonFlask"), Main.rand.Next(5, 10));
        }
    }
}