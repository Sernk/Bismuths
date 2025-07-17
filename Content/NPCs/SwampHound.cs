using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class SwampHound : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[this.NPC.type] = 10;
            NPCID.Sets.TrailCacheLength[NPC.type] = 1;
            NPCID.Sets.TrailingMode[NPC.type] = 0;
        }
        public override void SetDefaults()
        {      
            NPC.width = 46;
            NPC.height = 30;
            NPC.damage = 25;
            NPC.defense = 10;
            NPC.lifeMax = 70;
            NPC.aiStyle = 26;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath5;
            NPC.value = Item.buyPrice(0, 0, 0, 90);
            NPC.knockBackResist = 0.4f;
            AIType = 125;
            AnimationType = NPCID.Hellhound;
            //banner = npc.type;
            //bannerItem = mod.ItemType("SwampHoundBanner");
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SwampHoundHead").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SwampHoundBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SwampHoundFrontPaw").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SwampHoundBackPaw").Type, 1f);
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (this.NPC.spriteDirection < 0)
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Glow/SwampHound_Glow").Value, this.NPC.Center - Main.screenPosition + new Vector2(-10, 8), new Rectangle?(this.NPC.frame), Color.White * 0.8f, this.NPC.rotation, new Vector2(25f, 32f), 1f, SpriteEffects.None, 0.0f);
            else
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Glow/SwampHound_Glow").Value, this.NPC.Center - Main.screenPosition + new Vector2(-8, 8), new Rectangle?(this.NPC.frame), Color.White * 0.8f, this.NPC.rotation, new Vector2(25f, 32f), 1f, SpriteEffects.FlipHorizontally, 0.0f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return BismuthPlayer.ZoneSwamp && spawnInfo.SpawnTileY < Main.rockLayer ? 5f : 0f;
          
        }
    }
}