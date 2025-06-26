using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Content.Buffs;

namespace Bismuth.Content.NPCs
{
    public class Orc : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orc");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орк");
        }
        bool getbuff = false;
        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 44;
            NPC.damage = 26;
            NPC.defense = 15;
            NPC.lifeMax = 95;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1; 
            NPC.value = Item.buyPrice(0, 0, 2, 0);
            NPC.knockBackResist = 0.4f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = 15;
            AIType = 21;
            AnimationType = 21;
            //banner = npc.type;
            //bannerItem = mod.ItemType("OrcBanner");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (NPC.FindBuffIndex(ModContent.BuffType<FightingSpirit>()) != -1)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Buffs/FightingSpiritIcon").Value, NPC.position - Main.screenPosition + new Vector2(2, -34), Color.White * 0.5f);
            }
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
            }
        }
        public override void AI()
        {
            NPC.TargetClosest(true);
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
        }

        public override void OnKill()
        {
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrcishFragment"), Main.rand.Next(0, 3));
        }
    }
}