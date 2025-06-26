using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Content.Projectiles;
using System;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    [AutoloadBossHead]
    public class PapuanWizard : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // this.DisplayName.SetDefault("Papuan Shaman");
            //DisplayName.AddTranslation(GameCulture.Russian, "Папуас-шаман");
            Main.npcFrameCount[NPC.type] = 29;
        }

        public override void SetDefaults()
        {
            NPC.width = 36;
            NPC.height = 46;
            NPC.damage = 30;
            NPC.defense = 30;
            NPC.lifeMax = 3500;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = (float)Item.buyPrice(0, 4, 0, 0);
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            //npc.scale = 1f;
        }
        int currentframe = 0;
        int currentphase = 1;
        int tick = 0;
        Vector2 OldPlayerPos;
        float mult = 18f;
        bool dead = false;
        public void UpdateDirection()
        {
            if (Main.LocalPlayer.position.X >= NPC.position.X)
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
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                dead = true;
                NPC.immortal = true;
                NPC.life = 1;
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
            var source = NPC.GetSource_FromThis();
            if (dead)
            {
                NPC.ai[0] = 180;
                NPC.ai[1] = 210;
                NPC.ai[2] = 180;
                
                if(currentframe == 0)
                {
                    BismuthWorld.DownedPapuanWizard = true;
                    Vector2 vec = NPC.position + new Vector2((NPC.spriteDirection == 1 ? 14f : 18f), 44f);
                    NPC.NewNPC(source, (int)vec.X, (int)vec.Y, ModContent.NPCType<PapuanWizardDeath>(), 0, NPC.spriteDirection);
                    NPC.direction = NPC.direction;
                    NPC.spriteDirection = NPC.spriteDirection;
                    NPC.active = false;                    
                    return;
                }
            }          
            Player player = Main.player[Main.myPlayer];
            if (currentphase == 1)
            {
               
                NPC.ai[0]++;
                if (NPC.ai[0] == 60)
                {
                    Vector2 Spikepos = player.Center;
                    while (!WorldGen.SolidTile(Spikepos.ToTileCoordinates().X, Spikepos.ToTileCoordinates().Y))
                    {
                        Spikepos.Y++;
                    }
                    Spikepos.Y -= 30;
                    Projectile.NewProjectile(source, Spikepos, new Vector2(0, 0), ModContent.ProjectileType<SandSpike>(), 25, 0f);

                }
            }
            if (currentphase == 2)
            {
                NPC.ai[1]++;
                if (NPC.ai[1] == 30 || NPC.ai[1] == 90)
                {
                    OldPlayerPos = player.position;
                }
                if ((NPC.ai[1] > 30 && NPC.ai[1] < 90) || (NPC.ai[1] > 150 && NPC.ai[1] < 210))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int dust1 = Dust.NewDust(OldPlayerPos + new Vector2(12f * mult, 0f), 6, 6, 169);
                        Main.dust[dust1].noGravity = true;
                        int dust2 = Dust.NewDust(OldPlayerPos + new Vector2(-12f * mult, 0f), 6, 6, 169);
                        Main.dust[dust2].noGravity = true;
                        int dust3 = Dust.NewDust(OldPlayerPos + new Vector2(0f, 12f * mult), 6, 6, 169);
                        Main.dust[dust3].noGravity = true;
                        int dust4 = Dust.NewDust(OldPlayerPos + new Vector2(0f, -12f * mult), 6, 6, 169);
                        Main.dust[dust4].noGravity = true;
                    }                
                }
                if (NPC.ai[1] == 90 || NPC.ai[1] == 210)
                {
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(12f * mult, 0f), new Vector2(-12f * mult / 18, 0f), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(-12f * mult, 0f), new Vector2(12f * mult / 18, 0f), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(0f, 12f * mult), new Vector2(0f, -12f * mult / 18), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(0f, -12f * mult), new Vector2(0f, 12f * mult / 18), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                }
                if (NPC.ai[1] > 90 && NPC.ai[1] < 150)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int dust1 = Dust.NewDust(OldPlayerPos + new Vector2(8.484f * mult, 8.484f * mult), 6, 6, 169);
                        Main.dust[dust1].noGravity = true;
                        int dust2 = Dust.NewDust(OldPlayerPos + new Vector2(-8.484f * mult, 8.484f * mult), 6, 6, 169);
                        Main.dust[dust2].noGravity = true;
                        int dust3 = Dust.NewDust(OldPlayerPos + new Vector2(8.484f * mult, -8.484f * mult), 6, 6, 169);
                        Main.dust[dust3].noGravity = true;
                        int dust4 = Dust.NewDust(OldPlayerPos + new Vector2(-8.484f * mult, -8.484f * mult), 6, 6, 169);
                        Main.dust[dust4].noGravity = true;
                    }
                }
                if (NPC.ai[1] == 150)
                {
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(8.484f * mult, 8.484f * mult), new Vector2(-8.484f * mult / 18, -8.484f * mult / 18), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(-8.484f * mult, 8.484f * mult), new Vector2(8.484f * mult / 18, -8.484f * mult / 18), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(8.484f * mult, -8.484f * mult), new Vector2(-8.484f * mult / 18, 8.484f * mult / 18), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                    Projectile.NewProjectile(source, OldPlayerPos + new Vector2(-8.484f * mult, -8.484f * mult), new Vector2(8.484f * mult / 18, 8.484f * mult / 18), ModContent.ProjectileType<SandWaveEnemyP>(), 20, 4f);
                }
            }
            if (currentphase == 3)
            {
                NPC.ai[2]++;
                if (NPC.ai[2] % 180 == 150)
                    NPC.NewNPC(source, (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<RunicElemental>());
            }
        }
        public void ChoosePhase()
        {
            currentframe = 0;
            NPC.ai[0] = 0;
            NPC.ai[1] = 0;
            NPC.ai[2] = 0;
            if (currentphase == 1)
                currentphase = 2;
            else if(currentphase == 2)
                currentphase = 3;
            else if (currentphase == 3)
                currentphase = 1;
            if(!dead)
                UpdateDirection();
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = currentframe * frameHeight;

            tick++;
            if (currentphase == 1)
            {
                if (tick == 8)
                {
                    tick = 0;
                    currentframe++;
                    if (currentframe == 4 && NPC.ai[0] < 180)
                    {
                        currentframe = 2;
                    }
                    if (currentframe >= 8)
                        ChoosePhase();
                }
            }
            if (currentphase == 2)
            {
                if (tick == 8)
                {
                    tick = 0;
                    if (currentframe == 0)
                        currentframe = 9;
                    if (NPC.ai[1] <= 210)
                    {
                        if (currentframe > 8 && currentframe < 14)
                            currentframe++;
                        if (currentframe >= 14)
                            currentframe = 12;
                    }
                    if (NPC.ai[1] > 210)
                    {
                        if (currentframe != 14)
                            currentframe++;
                        else
                            ChoosePhase();
                    }
                }
            }
            if (currentphase == 3)
            {
                if (tick == 8)
                {
                    tick = 0;
                    if (currentframe == 0)
                        currentframe = 16;
                    if (NPC.ai[2] < 180)
                    {
                        if (currentframe > 15 && currentframe < 27)
                            currentframe++;
                        if (currentframe >= 27)
                            currentframe = 25;
                    }
                    if (NPC.ai[2] >= 180)
                    {
                        if (currentframe != 28)
                            currentframe++;
                        else
                            ChoosePhase();
                    }
                }
            }
        }
        /*public override void NPCLoot()
        {
            switch (Main.rand.Next(1, 3))
            {
                case 1:
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShamansStaff"));
                    break;
                case 2:
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmpathyMirror"));
                    break;
            }
            switch (Main.rand.Next(1, 4))
            {
                case 1:
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NomadsHood"));
                    break;
                case 2:
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NomadsBoots"));
                    break;
                case 3:
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NomadsJacket"));
                    break;
            }
        }*/
    }
}