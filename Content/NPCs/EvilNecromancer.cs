using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria.Audio;
using Bismuth.Utilities;
using Bismuth.Content.Buffs;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.NPCs
{
    [AutoloadBossHead]
    public class EvilNecromancer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // this.DisplayName.SetDefault("Necromancer");
            //DisplayName.AddTranslation(GameCulture.Russian, "Некромант");
            Main.npcFrameCount[NPC.type] = 1;
            NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        }
        int currentframe = 0;
        int tick = 0;
        int currentphase = 0; // 0 - статик, выбор фазы; 1 - телепортация; 2 - метание орбов; 3 - саммон; 4 - капкан;
        public override void SetDefaults()
        {
            NPC.width = 26;
            NPC.height = 44;
            NPC.damage = 30;
            NPC.lifeMax = 2500;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath37;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.friendly = false;
            NPC.noGravity = false;
            NPC.alpha = 255;
            Music = MusicID.Boss4;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        Player player;
        Vector2 TpPoint;
        Vector2 FirstSummon;
        Vector2 SecondSummon;
        Vector2 ThirdSummon;
        Vector2 FourthSummon;
        Vector2 FifthSummon;
        Point TpTile;
        int loopcount;
        int summontimer = 0;
        int summoncount = 0;
        int tpcount = 0;
        int attackcount = 0;
        int trapcount = 0;
        int trapframe = 0;
        Vector2 npctile;
        bool dead = false;
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                dead = true;
                NPC.immortal = true;
                NPC.life = 1;
                attackcount = 5;
                loopcount = 12;
                Player player = Main.LocalPlayer;
                if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                {
                    player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense));
                    if (player.GetModPlayer<BismuthPlayer>().skill67lvl > 0 && !Main.dayTime)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.2f);
                    }
                    if (player.GetModPlayer<BismuthPlayer>().skill133lvl > 0)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.15f);
                    }
                    if (player.GetModPlayer<BismuthPlayer>().IsBoSRead)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.1f);
                    }
                }
            }
        }
        public override void AI()
        {
            if (dead && (currentframe == 0 || currentframe == 30 || currentframe == 43 || currentframe == 63))
            {
                Vector2 vec = NPC.position + new Vector2((NPC.spriteDirection == 1 ? 33f : -1f), 40f);
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)vec.X, (int)vec.Y, ModContent.NPCType<NecromancerDeath>(), 0, NPC.spriteDirection);
                NPC.direction = NPC.direction;
                NPC.spriteDirection = NPC.spriteDirection;
                BismuthWorld.DownedNecromancer = true;
                NPC.active = false;               
                return;
            }
            if (!NPC.HasGivenName)
                NPC.GivenName = Main.LocalPlayer.GetModPlayer<BismuthPlayer>().necrosname;
            player = Main.player[Main.myPlayer];
            if (currentphase == 0)
            {
                currentframe = 0;
                ChoosePhase();
                UpdateDirection();
            }
            if (currentphase == 1)
            {
                if (NPC.ai[1] == 0f) // 0 - выбор точки, 1 - раскрутка до тп, 2 - раскрутка после тп.
                {
                Search:
                    if (tpcount > 1000)
                        goto Skip;
                    TpPoint = UtilsAI.RandomPointInArea(new Rectangle((int)NPC.Center.X - 300, (int)NPC.Center.Y - 300, 600, 600));
                    if (Math.Abs(TpPoint.X - NPC.Center.X) < 160f)
                    {
                        tpcount++;
                        goto Search;
                    }
                    if (!UtilsAI.CheckEmptyPlace(TpPoint))
                    {
                        tpcount++;
                        goto Search;
                       
                    }
                    while (!WorldGen.SolidTile(TpPoint.ToTileCoordinates().X, TpPoint.ToTileCoordinates().Y + 1))
                    {

                        TpPoint.Y++;
                        if (TpPoint.Y > NPC.Center.Y + 300)
                        {
                            tpcount++;
                            goto Search;
                          
                        }
                    }
                    if (!UtilsAI.CheckEmptyPlace(TpPoint))
                    {
                        tpcount++;
                        goto Search;

                    }
                Skip:
                    {
                        NPC.ai[1] = 1f;
                        
                    }
                }
                tick++;
                if (tick >= 4)
                {
                    tick = 0;
                    currentframe++;
                }
                if((currentframe == 8 && tick == 0) || (currentframe == 20 && tick == 0))
                    SoundEngine.PlaySound(SoundID.Item20, NPC.position);
                if (currentframe >= 17 && NPC.ai[1] == 1f)
                {
                    NPC.position = TpPoint + new Vector2(0f, -34f);
                    NPC.ai[1] = 2f;
                }
                if (currentframe >= 31)
                    ChoosePhase();
                if (currentframe >= 6 && currentframe <= 25)
                    Lighting.AddLight(NPC.Center, new Vector3(0.42f, 0.12f, 0.58f));
            }
            if (currentphase != 1)
                NPC.ai[1] = 0f;
            if (currentphase == 3)
            {
                if (NPC.ai[3] == 0f)
                {
                Search1:
                    if (summoncount > 1000)
                        goto SkipAll;
                    FirstSummon = UtilsAI.RandomPointInArea(new Rectangle((int)NPC.Center.X - 300, (int)NPC.Center.Y - 300, 600, 600));
                    if (!UtilsAI.CheckEmptyPlace(FirstSummon))
                    {
                        summoncount++;
                        goto Search1;

                    }
                    while (!WorldGen.SolidTile(FirstSummon.ToTileCoordinates().X, FirstSummon.ToTileCoordinates().Y + 1))
                    {

                        FirstSummon.Y++;
                        if (FirstSummon.Y > NPC.Center.Y + 300)
                        {
                            summoncount++;
                            goto Search1;

                        }
                    }
                    if (!UtilsAI.CheckEmptyPlace(FirstSummon))
                    {
                        summoncount++;
                        goto Search1;

                    }
                Search2:
                    if (summoncount > 1000)
                        goto SkipAll;
                    SecondSummon = UtilsAI.RandomPointInArea(new Rectangle((int)NPC.Center.X - 300, (int)NPC.Center.Y - 300, 600, 600));
                    if (!UtilsAI.CheckEmptyPlace(SecondSummon))
                    {
                        summoncount++;
                        goto Search2;

                    }
                    while (!WorldGen.SolidTile(SecondSummon.ToTileCoordinates().X, SecondSummon.ToTileCoordinates().Y + 1))
                    {

                        SecondSummon.Y++;
                        if (SecondSummon.Y > NPC.Center.Y + 300)
                        {
                            summoncount++;
                            goto Search2;

                        }
                    }
                    if (!UtilsAI.CheckEmptyPlace(SecondSummon))
                    {
                        summoncount++;
                        goto Search2;

                    }
                Search3:
                    if (summoncount > 1000)
                        goto SkipAll;
                    ThirdSummon = UtilsAI.RandomPointInArea(new Rectangle((int)NPC.Center.X - 300, (int)NPC.Center.Y - 300, 600, 600));
                    if (!UtilsAI.CheckEmptyPlace(ThirdSummon))
                    {
                        summoncount++;
                        goto Search3;

                    }
                    while (!WorldGen.SolidTile(ThirdSummon.ToTileCoordinates().X, ThirdSummon.ToTileCoordinates().Y + 1))
                    {

                        ThirdSummon.Y++;
                        if (ThirdSummon.Y > NPC.Center.Y + 300)
                        {
                            summoncount++;
                            goto Search3;

                        }
                    }
                    if (!UtilsAI.CheckEmptyPlace(ThirdSummon))
                    {
                        summoncount++;
                        goto Search3;

                    }
                Search4:
                    if (summoncount > 1000)
                        goto SkipAll;
                    FourthSummon = UtilsAI.RandomPointInArea(new Rectangle((int)NPC.Center.X - 300, (int)NPC.Center.Y - 300, 600, 600));
                    if (!UtilsAI.CheckEmptyPlace(FourthSummon))
                    {
                        summoncount++;
                        goto Search4;

                    }
                    while (!WorldGen.SolidTile(FourthSummon.ToTileCoordinates().X, FourthSummon.ToTileCoordinates().Y + 1))
                    {

                        FourthSummon.Y++;
                        if (FourthSummon.Y > NPC.Center.Y + 300)
                        {
                            summoncount++;
                            goto Search4;

                        }
                    }
                    if (!UtilsAI.CheckEmptyPlace(FourthSummon))
                    {
                        summoncount++;
                        goto Search4;

                    }
                Search5:
                    if (summoncount > 1000)
                        goto SkipAll;
                    FifthSummon = UtilsAI.RandomPointInArea(new Rectangle((int)NPC.Center.X - 300, (int)NPC.Center.Y - 300, 600, 600));
                    if (!UtilsAI.CheckEmptyPlace(FifthSummon))
                    {
                        summoncount++;
                        goto Search5;

                    }
                    while (!WorldGen.SolidTile(FifthSummon.ToTileCoordinates().X, FifthSummon.ToTileCoordinates().Y + 1))
                    {

                        FifthSummon.Y++;
                        if (FifthSummon.Y > NPC.Center.Y + 300)
                        {
                            summoncount++;
                            goto Search5;

                        }
                    }
                    if (!UtilsAI.CheckEmptyPlace(FifthSummon))
                    {
                        summoncount++;
                        goto Search5;

                    }
                    goto SkipAll;
                SkipAll:
                    if (summoncount > 1000)
                        ChoosePhase();
                    else
                        NPC.ai[3] = 1f;             
                }
                if (currentframe < 43)
                    currentframe = 43;               
                tick++;
                if (tick >= 5)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe == 48)
                    NPC.ai[3] = 2f;
                if (currentframe >= 54 && NPC.ai[3] == 2f && loopcount < 12)
                {
                    currentframe = 49;
                    loopcount++;              
                  //  NPC.NewNPC(FirstSummon.X, F)
                }
                if (currentframe > 55 && NPC.ai[3] == 2f)
                {
                    currentframe = 0;
                    ChoosePhase();
                }
                if (currentframe >= 48 && currentframe <= 53)
                {
                    if(summontimer == 15)
                        SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/NecromancerChant"), NPC.position);
                    summontimer++;
                    if (summontimer == 60)
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(4f, -26f), new Vector2(0f, -3f), ModContent.ProjectileType<UndeadRevivingP>(), 0, 0f, 0, FirstSummon.X, FirstSummon.Y);
                    }
                    if (summontimer == 120)
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0f, -32f), new Vector2(0f, -3f), ModContent.ProjectileType<UndeadRevivingP>(), 0, 0f, 0, SecondSummon.X, SecondSummon.Y);
                    }
                    if (summontimer == 180)
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0f, -32f), new Vector2(0f, -3f), ModContent.ProjectileType<UndeadRevivingP>(), 0, 0f, 0, ThirdSummon.X, ThirdSummon.Y);
                    }
                    if (summontimer == 240)
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0f, -32f), new Vector2(0f, -3f), ModContent.ProjectileType<UndeadRevivingP>(), 0, 0f, 0, FourthSummon.X, FourthSummon.Y);
                    }
                    if (summontimer == 300)
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0f, -32f), new Vector2(0f, -3f), ModContent.ProjectileType<UndeadRevivingP>(), 0, 0f, 0, FifthSummon.X, FifthSummon.Y);
                    }
                    if (currentframe >= 46 && currentframe <= 55)
                        Lighting.AddLight(NPC.Center, new Vector3(0.42f, 0.12f, 0.58f));
                }
            }
            if (currentphase != 3)
            {
                loopcount = 0;
                NPC.ai[3] = 0f;
                summontimer = 0;
            }
            if (currentphase == 2)
            {
                UpdateDirection();
                if (currentframe <= 29)
                    currentframe = 30;
                if (currentframe >= 43 && attackcount < 5)
                {
                    currentframe = 30;                    
                }
                tick++;
                if (tick >= 5)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe == 43)
                {
                    if (attackcount < 5)
                        currentframe = 30;
                    else
                        ChoosePhase();
                }
                   
                if (currentframe == 39 && tick == 1)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, UtilsAI.VelocityToPoint(NPC.Center, player.Center, 16f), ModContent.ProjectileType<DarkSkullP>(), 12, 4f, 0);
                    SoundEngine.PlaySound(SoundID.Item8, NPC.position);
                    attackcount++;
                }
                if (currentframe >= 31 && currentframe <= 38)
                    Lighting.AddLight(NPC.Center, new Vector3(0.42f, 0.12f, 0.58f));
            }
            if (currentphase != 2)
            {
                attackcount = 0;
            }
            if (currentphase == 4)
            {
                if (player.FindBuffIndex(ModContent.BuffType<BoneTrap>()) == -1)
                {
                    SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/FingerSnap"), NPC.position);
                    SoundEngine.PlaySound(SoundID.Item69, player.position);
                    player.AddBuff(ModContent.BuffType<BoneTrap>(), 180);
                }
                if (currentframe <= 63)
                    currentframe = 63;              
                tick++;
                if (tick >= 5)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe >= 65 && currentframe <= 67)
                    Lighting.AddLight(NPC.Center, new Vector3(0.42f, 0.12f, 0.58f));
                if (currentframe >= 71)                
                    ChoosePhase();                
            }
        }
        
        public void ChoosePhase()
        {
            UpdateDirection();
           
            if (currentphase == 1)
            {
                if (player.velocity.Y == 0f && WorldGen.SolidTile(player.position.ToTileCoordinates().X, player.position.ToTileCoordinates().Y + 3) && WorldGen.SolidTile(player.position.ToTileCoordinates().X + 1, player.position.ToTileCoordinates().Y + 3) && player.FindBuffIndex(ModContent.BuffType<BoneTrap>()) == -1)
                {
                    currentphase = 4;
                }
                else
                    currentphase = Main.rand.Next(2, 4);
            }
            else if (currentphase == 2 || currentphase == 3)
            {
                currentphase = 1;
            }
            else if (currentphase == 4)
            {
                currentphase = Main.rand.Next(2, 4);
            }
            else
                currentphase = 1;
            currentframe = 0;
            //currentphase = 4;
        }
        public void UpdateDirection()
        {
            if (player.position.X >= NPC.position.X)
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Height = NPC.height;
            NPC.frame.Width = NPC.width;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // if (currentphase == 0)
            if (currentframe == 0)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancerActually").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(0, 0, 52, 66)), drawColor * 0.5f, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            else
            {
                if (currentphase == 1)
                {
                    if (NPC.ai[1] == 1f)
                    {
                        spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancerActually").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(0, currentframe * 66, 52, 66)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                        spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancer_Glow").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(0, currentframe * 66, 52, 66)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                    }
                    else if (NPC.ai[1] == 2f)
                    {
                        spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancerActually").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(52, (currentframe - 16) * 66, 52, 66)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                        spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancer_Glow").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(52, (currentframe - 16) * 66, 52, 66)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                    }
                }
                else if (currentphase == 2)
                {
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancerActually").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(104, (currentframe - 30) * 66, 52, 66)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancer_Glow").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(104, (currentframe - 30) * 66, 52, 66)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                }
                else if (currentphase == 3)
                {
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancerActually").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(156, (currentframe - 43) * 66, 52, 66)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancer_Glow").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(156, (currentframe - 43) * 66, 52, 66)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                }
                else if (currentphase == 4)
                {
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancerActually").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(260, (currentframe - 63) * 66, 52, 66)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancer_Glow").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(260, (currentframe - 63) * 66, 52, 66)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);

                }

                else
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/EvilNecromancerActually").Value, NPC.position - Main.screenPosition + new Vector2(-10f, -20f), new Rectangle?(new Rectangle(0, 0, 52, 66)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            return false;
        }
    }
}