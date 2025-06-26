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
    public class MinotaurDeath : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;
      
       

        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 108;
            NPC.lifeMax = 10;
            NPC.dontTakeDamage = true;
            NPC.dontCountMe = true;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
        }
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
        }
        public override void AI()
        {
            NPC.direction = (int)NPC.ai[0];
            NPC.spriteDirection = (int)NPC.ai[0];
            tick++;           
            if(currentframe <= 21 && tick > 5)
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
           if(currentframe <= 10)
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, -2f), new Rectangle?(new Rectangle(0, currentframe * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
              
            else if(currentframe >= 11 && currentframe <= 21)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, -2f), new Rectangle?(new Rectangle(208, (currentframe - 11) * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
              
            }
           else
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, -2f), new Rectangle?(new Rectangle(416, (currentframe - 22) * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            return false;
        }
        //public override void NPCLoot()
        //{
         
        //    for (int i = 0; i < 8; i++)
        //        Gore.NewGore(npc.Center + (npc.direction == -1 ? new Vector2(68f, 20f) : new Vector2(0f, 20f)), npc.velocity, Main.rand.Next(11, 14), Main.rand.NextFloat(1f, 1.4f));
        //    if (Main.rand.Next(0, 4) != 0)
        //        Item.NewItem((int)npc.Center.X + (npc.direction == -1 ? 68 : 20), (int)npc.Center.Y + 20, npc.width, npc.height, mod.ItemType("MinotaursWaraxe"));
        //    else
        //        Item.NewItem((int)npc.Center.X + (npc.direction == -1 ? 68 : 20), (int)npc.Center.Y + 20, npc.width, npc.height, mod.ItemType("Narsil"));
        //    Item.NewItem((int)npc.Center.X + (npc.direction == -1 ? 68 : 20), (int)npc.Center.Y + 20, npc.width, npc.height, mod.ItemType("MinotaurHorn"));
        //}
    }
}