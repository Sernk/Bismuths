using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

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
        public override void OnKill()
        {
            Vector2 vec1 = NPC.Center + new Vector2(-30f, 30f);
            Vector2 vec2 = NPC.Center + new Vector2(-10f, 30f);
            for (int i = 0; i < 5; i++)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.direction == -1 ? vec1 : vec2, NPC.velocity, Main.rand.Next(11, 14), Main.rand.NextFloat(0.5f, 1f));
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkPartOfArchmagesAmulet>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NecromancersHood>()));
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheBladeOFWoe>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NecromancersRobe>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkEssence>(), 1, 10, 15));
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<NecromancersRing>(), ModContent.ItemType<LichCrown>(), ModContent.ItemType<MirrorOfUndead>(), ModContent.ItemType<DarkEngraving>()));
        }
    }
}