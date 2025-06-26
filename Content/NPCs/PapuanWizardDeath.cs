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
    public class PapuanWizardDeath : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;



        public override void SetDefaults()
        {
            NPC.width = 46;
            NPC.height = 46;
            NPC.lifeMax = 10;
            NPC.dontTakeDamage = true;
            NPC.dontCountMe = true;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
        }
        Player player = Main.player[Main.myPlayer];

        public override void AI()
        {
            NPC.direction = (int)NPC.ai[0];
            NPC.spriteDirection = (int)NPC.ai[0];
            tick++;
            if (currentframe <= 21 && tick > 5)
            {
                currentframe++;
                tick = 0;
            }
            if (tick > 120)
            {
                NPC.life = -1;
                NPC.checkDead();
            }
            NPC.velocity.Y = 4f;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)//40
        {          
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/PapuanWizardDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, 2f), new Rectangle?(new Rectangle(0, currentframe * 46, 46, 46)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);           
            return false;
        }
        /*public override void NPCLoot()
        {
            Vector2 vec1 = npc.Center + new Vector2(-30f, 10f);
            Vector2 vec2 = npc.Center + new Vector2(-10f, 10f);
            for (int i = 0; i < 5; i++)
                Gore.NewGore(npc.direction == -1 ? vec1 : vec2, npc.velocity, Main.rand.Next(11, 14), Main.rand.NextFloat(0.5f, 1f));
            switch (Main.rand.Next(1, 4))
            {
                case 1:
                    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("ShamansStaff"));
                    break;
                case 2:
                    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("SandSpike"));
                    break;
                case 3:
                    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("EmpathyMirror"));
                    break;
            }
            switch (Main.rand.Next(1, 4))
            {
                case 1:
                    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("NomadsHood"));
                    break;
                case 2:
                    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("NomadsBoots"));
                    break;
                case 3:
                    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("NomadsJacket"));
                    break;
            }                  
        }*/
    }
}