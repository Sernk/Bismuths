using Bismuth.Content.Items.Accessories;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class SwampWraith : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[this.NPC.type] = 4;
            NPCID.Sets.TrailCacheLength[NPC.type] = 7;
            NPCID.Sets.TrailingMode[NPC.type] = 0;
        }

        public override void SetDefaults()
        {
            NPC.width = 46;
            NPC.height = 42;
            NPC.aiStyle = 22;
            NPC.damage = 30;
            NPC.defense = 4;
            NPC.lifeMax = 80;
            NPC.HitSound = SoundID.NPCHit12;
            NPC.DeathSound = SoundID.NPCDeath18;
            NPC.knockBackResist = 0.7f;
            NPC.value = Item.buyPrice(0, 0, 1, 0);
            NPC.alpha = 180;
            AIType = 82;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            AnimationType = NPCID.Wraith;
            //banner = npc.type;
            //bannerItem = mod.ItemType("SwampWraithBanner");
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            var drawOrigin = new Vector2(TextureAssets.Npc[NPC.type].Value.Width * 0.5f, NPC.height * 0.5f);
            for (var k = 0; k < 3; k++)
            {
                Texture2D eyes = ModContent.Request<Texture2D>("Bismuth/Glow/SwampWraith_Glow").Value;
                var drawPos = NPC.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, NPC.gfxOffY);
                if (NPC.spriteDirection == 1)
                    drawPos += new Vector2(20, 0);
                var color = NPC.GetAlpha(drawColor) * ((float)(NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                spriteBatch.Draw(eyes, drawPos, new Rectangle(0, 4, 26, 44), new Color(218f, 2f, 5f, 160), NPC.rotation, drawOrigin, NPC.scale, NPC.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            var drawOrigin = new Vector2(TextureAssets.Npc[NPC.type].Value.Width * 0.5f, NPC.height * 0.5f);      
            for (var k = 0; k < NPC.oldPos.Length; k++)
            {               
                var drawPos = NPC.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, NPC.gfxOffY) + new Vector2(8, 0);
                var color = NPC.GetAlpha(drawColor) * ((float)(NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, drawPos, new Rectangle(0, 4, 26, 44), color, NPC.rotation, drawOrigin, NPC.scale, NPC.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
               
            }
            
            return true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return BismuthPlayer.ZoneSwamp && spawnInfo.SpawnTileY < Main.rockLayer && !Main.dayTime ? 5f : 0f;

        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life > 0)
            {
                int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 0f, 0f, 50, default(Color), 1.5f);
                Main.dust[dust].noGravity = true;
            }
            else
            {
                int num5;
                for (int num616 = 0; num616 < 20; num616 = num5 + 1)
                {
                    int num617 = Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 0f, 0f, 50, default(Color), 1.5f);
                    Dust dust = Main.dust[num617];
                    dust.velocity *= 2f;
                    Main.dust[num617].noGravity = true;
                    num5 = num616;
                }
                int num618 = Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X, NPC.position.Y - 10f), new Vector2((float)hit.HitDirection, 0f), 99, 1f);
                Gore gore = Main.gore[num618];
                gore.velocity *= 0.3f;
                num618 = Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X, NPC.position.Y + (float)(NPC.height / 2) - 15f), new Vector2((float)hit.HitDirection, 0f), 99, 1f);
                gore = Main.gore[num618];
                gore.velocity *= 0.3f;
                num618 = Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height - 20f), new Vector2((float)hit.HitDirection, 0f), 99, 1f);
                gore = Main.gore[num618];
                gore.velocity *= 0.3f;
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeartOfSwamp>(), 200));
        }
    }
}