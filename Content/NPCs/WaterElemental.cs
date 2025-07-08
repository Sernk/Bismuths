using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    public class WaterElemental : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;
        float acceleration = 0f;
        int accelerationtick = 0;
        int AIProtocol = 0; // 0 - статик, 1 - перемещение к игроку, 2 - можно скастовать заморозку, но игрок далеко, 3 - каст заморозки.
        int attacking = 1; // 1 - не кастует, 2 - кастует
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 17;
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
            if (player.dead || player.FindBuffIndex(ModContent.BuffType<Buffs.WaterElemental>()) == -1)
            {
                NPC.life = -1;
                NPC.checkDead();
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
                NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y), 2.2f) * (acceleration + 0.01f);
           
            if (AIProtocol == 2)
                NPC.velocity = UtilsAI.VelocityToPoint(NPC.position, player.position, 4f);
            if (AIProtocol == 3)
                NPC.velocity = Vector2.Zero;
            if(AIProtocol != 3)
                UpdateDirection();
            Lighting.AddLight(NPC.Center, new Vector3(0.1f, 0.1f, 0.4f));
           
        }
        public void TeleportToPlayer()
        {
            if (Vector2.Distance(NPC.Center, player.Center) > 2000f)
            {
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59);
                }
                NPC.position = player.position;
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59);
                }
            }
        }
        public void ChooseProtocol()
        {
            if (player.statLife < (player.statLifeMax2 / 2) && player.GetModPlayer<BismuthPlayer>().CanBeFrozenByElemental)
            {
                if (Vector2.Distance(NPC.position, player.position) > 150f && attacking == 1)
                    AIProtocol = 2;
                if (Vector2.Distance(NPC.position, player.position) <= 150f && AIProtocol != 3)
                {
                    AIProtocol = 3;
                    attacking = 2;
                }
            }
            else
            {
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y)) > 15f)
                    AIProtocol = 1;
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y)) < 5f)
                    AIProtocol = 0;
            }              
        }
        public void Attack()
        {
            if (currentframe == 11 && attacking == 2)
            {
                AIProtocol = 3;
                if (NPC.direction == 1) // налево
                {
                    for (int i = 0; i < 12; i++)
                    {
                        int dust = Dust.NewDust(new Vector2(NPC.Center.X - 36, NPC.position.Y + 38), 16, 16, 51);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity = new Vector2(-14f, 0f).RotatedByRandom(MathHelper.ToRadians(30));
                        int dust2 = Dust.NewDust(new Vector2(NPC.Center.X - 36, NPC.position.Y + 38), 16, 16, 67);
                        Main.dust[dust2].noGravity = true;
                        Main.dust[dust2].velocity = new Vector2(-14f, 0f).RotatedByRandom(MathHelper.ToRadians(30));
                    }
                }
                else
                {
                    for (int i = 0; i < 12; i++)
                    {
                        int dust = Dust.NewDust(new Vector2(NPC.Center.X + 16, NPC.position.Y + 38), 16, 16, 51);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity = new Vector2(14f, 0f).RotatedByRandom(MathHelper.ToRadians(30));
                        int dust2 = Dust.NewDust(new Vector2(NPC.Center.X + 16, NPC.position.Y + 38), 16, 16, 67);
                        Main.dust[dust2].noGravity = true;
                        Main.dust[dust2].velocity = new Vector2(14f, 0f).RotatedByRandom(MathHelper.ToRadians(30));
                    }
                }
                if (NPC.ai[0] == 15f)
                {
                    SoundEngine.PlaySound(SoundID.Item20, NPC.position);
                    SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/Glaciation"), NPC.position);
                    player.AddBuff(ModContent.BuffType<Buffs.Glaciation>(), 420);
                    player.GetModPlayer<BismuthPlayer>().CanBeFrozenByElemental = false;
                }
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
            NPC.frame.Y = currentframe * frameHeight;
            tick++;
            if (tick >= 5)
            {
                tick = 0;
                currentframe++;
            }
            if (attacking == 1)
            {
                if (currentframe > 7)
                    currentframe = 0;
                NPC.ai[0] = 0f;
            }
            else
            {
                NPC.ai[0]++;
                if (currentframe == 16)
                    attacking = 1;
                if (currentframe < 8 || currentframe > 16)
                    currentframe = 8;
            }
            if (currentframe == 11)
            {
                Attack();
                if (NPC.ai[0] < 30)
                    tick = 0;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/WaterElemental").Value, NPC.position - Main.screenPosition + new Vector2(17f, 18f), new Rectangle?(new Rectangle(0, NPC.frame.Y, 76, 94)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }
        public override void OnKill()
        {
            for (int i = 0; i < 50; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 59);
            }
        }
    }
}