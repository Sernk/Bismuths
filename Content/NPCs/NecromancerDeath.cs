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
    public class NecromancerDeath : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;

        public override void SetDefaults()
        {
            NPC.width = 54;
            NPC.height = 92;
            NPC.lifeMax = 10;
            NPC.dontTakeDamage = true;
            NPC.dontCountMe = true;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
        }
    
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 41;
        }
        Player player = Main.player[Main.myPlayer];
        public override void AI()
        {
            NPC.direction = (int)NPC.ai[0];
            NPC.spriteDirection = (int)NPC.ai[0];
            tick++;
            if (currentframe <= 39 && tick > 5)
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
            if (currentframe >= 14 && currentframe <= 30)
                Lighting.AddLight(NPC.Center, new Vector3(0.42f, 0.12f, 0.58f));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)//40
        {
            if (currentframe <= 21)
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/NecromancerDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, 2f), new Rectangle?(new Rectangle(0, currentframe * 92, 54, 92)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            else if (currentframe >= 22)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/NecromancerDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, 2f), new Rectangle?(new Rectangle(54, (currentframe - 22) * 92, 54, 92)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);

            }          
            return false;
        }
        //public override void NPCLoot()
        //{
        //    Vector2 vec1 = npc.Center + new Vector2(-30f, 30f);
        //    Vector2 vec2 = npc.Center + new Vector2(-10f, 30f);
        //    for (int i = 0; i < 5; i++)
        //        Gore.NewGore(npc.direction == -1 ? vec1 : vec2, npc.velocity, Main.rand.Next(11, 14), Main.rand.NextFloat(0.5f, 1f));
        //    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("DarkPartOfArchmagesAmulet"));
        //    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("NecromancersHood"));
        //    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("TheBladeOFWoe"));
        //    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("NecromancersRobe"));
        //    Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("DarkEssence"), Main.rand.Next(10, 15));
        //    switch (Main.rand.Next(1, 5))
        //    {
        //        case 1:
        //            Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("NecromancersRing"));
        //            break;
        //        case 2:
        //            Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("LichCrown"));
        //            break;
        //        case 3:
        //            Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("MirrorOfUndead"));
        //            break;
        //        case 4:
        //            Item.NewItem(npc.direction == -1 ? (int)vec1.X : (int)vec2.X, (int)vec1.Y - 10, npc.width, npc.height, mod.ItemType("DarkEngraving"));
        //            break;
        //    }           
    }
}