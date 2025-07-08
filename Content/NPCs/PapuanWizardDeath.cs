using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Weapons.Magical;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

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
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/PapuanWizardDeath").Value, NPC.position - Main.screenPosition + new Vector2(0f, 2f), new Rectangle?(new Rectangle(0, currentframe * 46, 46, 46)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            return false;
        }
        public override void OnKill()
        {
            Vector2 vec1 = NPC.Center + new Vector2(-30f, 10f);
            Vector2 vec2 = NPC.Center + new Vector2(-10f, 10f);
            Gore.NewGore(NPC.GetSource_Death(), NPC.direction == -1 ? vec1 : vec2, NPC.velocity, Main.rand.Next(11, 14), Main.rand.NextFloat(0.5f, 1f));
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<ShamansStaff>(), ModContent.ItemType<EmpathyMirror>()));
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<NomadsHood>(), ModContent.ItemType<NomadsBoots>(), ModContent.ItemType<NomadsJacket>()));
        }
    }
}