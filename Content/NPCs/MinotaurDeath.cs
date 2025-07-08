using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

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
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MinotaursWaraxe>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Narsil>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MinotaurHorn>()));
        }
        public override void OnKill()
        {
            for (int i = 0; i < 8; i++)
            {
                Gore.NewGore(NPC.GetSource_Death(),NPC.Center + (NPC.direction == -1 ? new Vector2(68f, 20f) : new Vector2(0f, 20f)), NPC.velocity, Main.rand.Next(11, 14), Main.rand.NextFloat(1f, 1.4f));
            }
        }
    }
}