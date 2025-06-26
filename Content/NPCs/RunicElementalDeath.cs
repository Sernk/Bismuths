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
    public class RunicElementalDeath : ModNPC
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
            NPC.noGravity = true;
            NPC.noTileCollide = true;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 7;
        }
        Player player = Main.player[Main.myPlayer];
        public override void AI()
        {
            NPC.alpha = 120;
            NPC.direction = (int)NPC.ai[0];
            NPC.spriteDirection = (int)NPC.ai[0];
            tick++;
            if (currentframe <= 6 && tick > 5)
            {
                currentframe++;
                tick = 0;
            }
            if(currentframe < 4)
                Lighting.AddLight(NPC.Center, new Vector3(0.65f, 1.04f, 1.12f));
            if (currentframe > 6)
            {
                NPC.life = -1;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)//40
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/RunicElementalDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, 2f), new Rectangle?(new Rectangle(0, currentframe * 64, 66, 64)), drawColor * 0.5f, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/RunicElementalDeath_Glow").Value, NPC.position - Main.screenPosition + new Vector2(0f, 2f), new Rectangle?(new Rectangle(0, currentframe * 64, 66, 64)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }
    }
}