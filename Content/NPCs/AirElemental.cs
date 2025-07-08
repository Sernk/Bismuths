using Bismuth.Content.Buffs;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class AirElemental : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;
        float acceleration = 0f;
        int accelerationtick = 0;
        int AIProtocol = 0; // 0 - статик, 1 - перемещение к игроку, 2 - можно скастовать заморозку, но игрок далеко, 3 - каст заморозки.
        int attacking = 1; // 1 - не кастует, 2 - кастует
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
            NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        }
        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 108;
            NPC.damage = 30;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath37;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noTileCollide = true;
            NPC.friendly = true;
            NPC.noGravity = true;
        }
        Player player = Main.player[Main.myPlayer];
        public override void AI()
        {
            NPC.dontTakeDamage = true;
            if (player.dead || player.FindBuffIndex(ModContent.BuffType<Buffs.AirElemental>()) == -1)
            {
                NPC.life = -1;
                NPC.checkDead();
            }
            NPC.ai[0]++;
            if (NPC.ai[0] >= 600)
            {
                attacking = 2;
                NPC.ai[0] = 0f;
            }
            TeleportToPlayer();
            ChooseProtocol();
            if (NPC.velocity != Vector2.Zero)
            {
                accelerationtick++;
                acceleration += 0.015f * accelerationtick;
                if (acceleration > 1f)
                    acceleration = 1f;
            }
            else
            {
                acceleration = 0f;
                accelerationtick = 0;
            }
            if (AIProtocol == 0)
                NPC.velocity = Vector2.Zero;
            if (AIProtocol == 1)
                NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y - 40), 2.2f) * (acceleration + 0.01f);
            if (AIProtocol == 2)
                NPC.velocity = UtilsAI.VelocityToPoint(NPC.position, player.position, 4f);
            if (AIProtocol == 3)
                NPC.velocity = Vector2.Zero;
            if (AIProtocol != 3)
                UpdateDirection();
            Lighting.AddLight(NPC.Center, new Vector3(0.1f, 0.1f, 0.4f));

        }
        public void TeleportToPlayer()
        {
            if (Vector2.Distance(NPC.Center, player.Center) > 2000f)
            {
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 135);
                }
                NPC.position = player.position;
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 135);
                }
            }
        }
        public void ChooseProtocol()
        {
            if (attacking == 2)
            {
                if (Vector2.Distance(NPC.position, player.position) > 400f && AIProtocol != 3)
                    AIProtocol = 2;
                if (Vector2.Distance(NPC.position, player.position) <= 400f)
                {
                    AIProtocol = 3;
                }
            }
            else
            {
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y - 40)) > 15f)
                    AIProtocol = 1;
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y - 40)) < 5f)
                    AIProtocol = 0;
            }
        }       
        public void UpdateDirection()
        {
            if (NPC.velocity.X < 0.0f)
                NPC.spriteDirection = NPC.direction = 1;
            else if (NPC.velocity.X > 0.0f)
                NPC.spriteDirection = NPC.direction = -1;
            if (AIProtocol == 0)
            {
                NPC.direction = NPC.spriteDirection = -player.direction;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            tick++;
            if (tick >= 5)
            {
                tick = 0;
                currentframe++;
            }
            if (AIProtocol != 3)
            {
                if (currentframe > 7)
                    currentframe = 0;
            }
            else
            {
                if (currentframe < 8)
                    currentframe = 8;
                if (currentframe == 18 && tick == 4)
                    attacking = 1;
            }
            if (currentframe == 14 && tick == 3)
            {
                player.AddBuff(ModContent.BuffType<FlowOfWind>(), 720);
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    if (Main.npc[i].active && !Main.npc[i].friendly && Main.npc[i].life > 0 && Vector2.Distance(NPC.Center, Main.npc[i].Center) < 600f && !Main.npc[i].noGravity)
                        Main.npc[i].velocity.Y = -18f;
                    SoundEngine.PlaySound(SoundID.Item20);
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (AIProtocol != 3)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/AirElementalActually").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(0, currentframe * 136, 110, 136)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/AirElementalGlow").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(0, currentframe * 136, 110, 136)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);

            }
            else
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/AirElementalActually").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(110, (currentframe - 8) * 136, 110, 136)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/AirElementalGlow").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(110, (currentframe - 8) * 136, 110, 136)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
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