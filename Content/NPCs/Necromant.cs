using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
   [AutoloadHead]
    public class Necromant : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        bool dead = false;
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                dead = true;
                NPC.immortal = true;
                NPC.life = 1;
            }
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 32;
            NPC.height = 42;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            button = "No more talking";          
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                if (NPC.spriteDirection == 1)
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + 10, (int)NPC.position.Y + 42, ModContent.NPCType<EvilNecromancer>());
                else
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + 16, (int)NPC.position.Y + 42, ModContent.NPCType<EvilNecromancer>());
                NPC.active = false;   
            }
        }
        public void UpdatePosition()
        {
            if (Main.player[Main.myPlayer].position.X >= NPC.position.X)
                NPC.spriteDirection = -1;
            else
                NPC.spriteDirection = 1;
        }
        public override void AI()
        {
            
            if (!NPC.HasGivenName)
                NPC.GivenName = Main.LocalPlayer.GetModPlayer<BismuthPlayer>().necrosname;
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1)
            {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
            NPC.dontTakeDamage = true;
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            if (NPC.oldVelocity.X != 0f)
                NPC.velocity.X = 0f;
            if (Main.player[Main.myPlayer].talkNPC >= 0)
            {
                NPC npC = Main.npc[Main.player[Main.myPlayer].talkNPC];
                if (npC.whoAmI == NPC.whoAmI)
                {
                    UpdatePosition();
                }
            }
        }
    }
}