using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    public class RestlessSoul : ModNPC
    {
        public int currentframe = 0;
        public int currentphase = 0;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.width = 68;
            NPC.height = 56;
            NPC.damage = 0;
            NPC.defense = 15;
            NPC.lifeMax = 1;
            NPC.rarity = 3;
            NPC.immortal = true;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath37;
            NPC.value = (float)Item.buyPrice(0, 4, 0, 0);
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.alpha = 80;
            NPC.friendly = true;
            AnimationType = NPCID.Wraith;
        }
        public override void AI()
        {
            Player player = Main.LocalPlayer;
            NPC.spriteDirection = NPC.direction;
            if (NPC.ai[0] == 0f)
            {
                if (Vector2.Distance(NPC.Center, player.Center + new Vector2(50, 0f)) > 12f)
                    NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, player.Center + new Vector2(50, 0f), 1.5f + (Vector2.Distance(player.Center + new Vector2(50, 0f), NPC.Center) / 200));
                else
                    NPC.velocity = Vector2.Zero;
            }
            else if (NPC.ai[0] == 1f)
            {
                if (Vector2.Distance(NPC.Center, player.Center + new Vector2(-50, 0f)) > 12f)
                    NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, player.Center + new Vector2(-50, 0f), 1.5f + (Vector2.Distance(player.Center + new Vector2(-50, 0f), NPC.Center) / 200));
                else
                    NPC.velocity = Vector2.Zero;
            }
            else if (NPC.ai[0] == 2f)
            {
                if (Vector2.Distance(NPC.Center, player.Center + new Vector2(0, -50f)) > 12f)
                    NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, player.Center + new Vector2(0, -50f), 1.5f + (Vector2.Distance(player.Center + new Vector2(0, -50f), NPC.Center) / 200));
                else
                    NPC.velocity = Vector2.Zero;
            }
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().SoulEaterCounter <= 0)
                NPC.active = false;
        }
        public void UpdateDirection()
        {
            if (Main.player[Main.myPlayer].direction >= 0)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }
        }
    }
}