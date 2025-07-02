using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bismuth.Content.NPCs
{
    public class SwampWitchDeath : ModNPC
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
            Main.npcFrameCount[NPC.type] = 30;
        }
        Player player = Main.player[Main.myPlayer];
        public override void AI()
        {
            NPC.direction = (int)NPC.ai[0];
            NPC.spriteDirection = (int)NPC.ai[0];
            tick++;
            if (currentframe <= 28 && tick > 5)
            {
                currentframe++;
                tick = 0;
            }
            if (currentframe == 28)
                NPC.active = false;
            NPC.velocity.Y = 4f;
            if(currentframe > 0)
                Lighting.AddLight(NPC.Center, new Vector3(0.25f, 0.67f, 0.99f));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)//30
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/SwampWitchDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, 0f), new Rectangle?(new Rectangle(0, currentframe * 48, 120, 48)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/SwampWitchDeath_Glow").Value, NPC.position - Main.screenPosition + new Vector2(0f, 0f), new Rectangle?(new Rectangle(0, currentframe * 48, 120, 48)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            return false;
        }
        public override void OnKill()
        {
            for (int i = 0; i < 50; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 135);
            }
        }
    }
}