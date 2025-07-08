using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    [AutoloadBossHead]
    public class RhinoOrc : ModNPC
    {
        int tick = 0;
        int currentframe = 0; 
        int currentphase = 1;
        int MoveToX = 0;
        int dir = 0;
        int firstphasecooldown = 0;
        int secondphaseflag = 0;
        bool getbuff = false;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
        }

        public override void SetDefaults()
        {
            NPC.width = 102;
            NPC.height = 48;
            NPC.damage = 30;
            NPC.defense = 15;
            NPC.lifeMax = 3500;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath37;
            NPC.value = (float)Item.buyPrice(0, 4, 0, 0);
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcArm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcArm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcHead").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RhinoDrum").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RhinoBackLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RhinoFrontLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RhinoHead").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RhinoBody").Type, 1f);
            }
        }
        public override void AI()
        {
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) != -1 && !getbuff)
            {
                getbuff = true;
                NPC.damage *= 2;
            }
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) == -1 && getbuff)
            {
                getbuff = false;
                NPC.damage /= 2;
            }
            tick++;
            if (tick >= 6)
            {
                tick = 0;
                currentframe++;
            }
            if (currentphase == 0)
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    if (Main.npc[i].active && Vector2.Distance(NPC.Center, Main.npc[i].Center) < 1000f && (Main.npc[i].type == ModContent.NPCType<Orc>() || Main.npc[i].type == ModContent.NPCType<OrcCrossbower>() || Main.npc[i].type == ModContent.NPCType<OrcDefender>() || /*Main.npc[i].type == ModContent.NPCType<OrcRider>() ||*/ Main.npc[i].type == ModContent.NPCType<RhinoOrc>()))
                        Main.npc[i].AddBuff(ModContent.BuffType<FightingSpirit>(), 10);
                }
                NPC.velocity.X = 0f;
                NPC.velocity.Y = 4f;
                if ((currentframe == 1 || currentframe == 5) && tick == 0)
                    SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/Drum"), NPC.position);

                if (currentframe > 7)
                    currentframe = 0;
                NPC.aiStyle = -1;
                firstphasecooldown++;
                if (firstphasecooldown >= 300)
                {
                    firstphasecooldown = 0;
                    currentphase = 1;
                }
            }
            if (currentphase == 1)
            {      
                MoveToX = (int)Main.player[Main.myPlayer].Center.X;
                NPC.aiStyle = 3;
                if (secondphaseflag == 0)
                {
                    UpdateDirection();
                    secondphaseflag = 1;
                }
                if (currentframe < 8 || currentframe > 13)
                    currentframe = 8;
                if((currentframe == 8 && tick == 0) || (currentframe == 12 && tick == 0))
                    Bismuth.ShakeScreen(10f, 10);
                NPC.velocity.X = 3.5f * dir;
                NPC.velocity.Y = 4f;
                if (dir == 1)
                {
                    if ((int)NPC.Center.X - MoveToX > 100)
                        currentphase = 0;
                    if (WorldGen.SolidTile(NPC.position.ToTileCoordinates().X + 7, NPC.position.ToTileCoordinates().Y) || WorldGen.SolidTile(NPC.position.ToTileCoordinates().X + 7, NPC.position.ToTileCoordinates().Y + 1))
                        currentphase = 0;
                }
                if (dir == -1)
                {
                    if (MoveToX - (int)NPC.Center.X > 100)
                        currentphase = 0;
                    if (WorldGen.SolidTile(NPC.position.ToTileCoordinates().X - 1, NPC.position.ToTileCoordinates().Y) || WorldGen.SolidTile(NPC.position.ToTileCoordinates().X -1, NPC.position.ToTileCoordinates().Y + 1))
                        currentphase = 0;
                }                
            }
            else
            {
                secondphaseflag = 0;
                MoveToX = 0;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/RhinoOrcActually").Value, new Vector2((int)NPC.position.X, (int)NPC.position.Y) - new Vector2((int)Main.screenPosition.X, (int)Main.screenPosition.Y) + new Vector2(-4, -44), new Rectangle?(new Rectangle(0, currentframe * 94, 116, 94)), drawColor, 0f, Vector2.Zero, 1f, dir == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) != -1)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Buffs/FightingSpiritIcon").Value, NPC.position - Main.screenPosition + new Vector2(46, -80), Color.White * 0.5f);
            }
        }
        public void UpdateDirection()
        {
            if (MoveToX >= NPC.Center.X)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }
        }
        public override void OnKill()
        {
            BismuthWorld.DownedRhino = true;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<BattleDrum>(), ModContent.ItemType<Doomhammer>(), ModContent.ItemType<Stiletto>()));
        }
    }
}
