using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

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
            NPC.dontTakeDamage = false;
            NPC.dontCountMe = false;
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
            if (tick > 5)
            {
                currentframe++;
                tick = 0;
            }

            if (currentframe >= Main.npcFrameCount[NPC.type] - 1)
            {
                NPC.life = 0;
                NPC.HitEffect();
                NPC.checkDead();
            }

            NPC.velocity.Y = 4f;

            if (currentframe > 0)
                Lighting.AddLight(NPC.Center, new Vector3(0.25f, 0.67f, 0.99f));
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)//30
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/SwampWitchDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, 0f), new Rectangle?(new Rectangle(0, currentframe * 48, 120, 48)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/SwampWitchDeath_Glow").Value, NPC.position - Main.screenPosition + new Vector2(0f, 0f), new Rectangle?(new Rectangle(0, currentframe * 48, 120, 48)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            return false;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LightPartOfArchmagesAmulet>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PoisonFlask>(), 1, 5, 10));
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<TransmutationAmulet>(), ModContent.ItemType<SnakesFang>()));
        }
        public override void OnKill()
        {
            Main.LocalPlayer.GetModPlayer<BismuthPlayer>().downedWitch = true;
            for (int i = 0; i < 50; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 135);
            }
        }
    }
}