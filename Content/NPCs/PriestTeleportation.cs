using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class PriestTeleportation : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Priest");
            //DisplayName.AddTranslation(GameCulture.Russian, "Священник");
            Main.npcFrameCount[NPC.type] = 19;
        }
        public override void Load()
        {
            string Priest_10 = this.GetLocalization("Chat.Priest_10").Value; // Ru: <{0}>Ты заплатишь за это!
                                                                             // En: <{0}> You'll pay for this!
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

        public override List<string> SetNPCNameList() => new List<string>()
        {
            this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.PriestName_1");
            this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.PriestName_2");
            this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.PriestName_3");
            this.GetLocalizedValue("Name.Seefeld") // Language.GetTextValue("Mods.Bismuth.PriestName_4");
        };

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/PriestTeleportation_Glow").Value, NPC.position - Main.screenPosition + new Vector2(-14f, -22f), new Rectangle?(NPC.frame), drawColor, 0f, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
        }      
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }      
        int pretimer = 0;
        int timer = 0;
        public override void AI()
        {
            string Priest_10 = this.GetLocalization("Chat.Priest_10").Value;

            if (timer < 100)
                timer++;
           // npc.netUpdate = true;
            if (currentframe > 2 && NPC.alpha != 255)
                Lighting.AddLight(NPC.Center, new Vector3(0.42f, 0.12f, 0.58f));
            if (NPC.ai[0] >= 3f)
                NPC.ai[1] += 1f;
            
            if (NPC.ai[0] == 0f && timer >= 100)
            {
                pretimer++;
                if (pretimer == 15)
                    Main.NewText(string.Format(this.GetLocalization("Chat.Priest_10").Value, NPC.GivenName), new Color(149, 62, 255));
                if (pretimer >= 30)
                    NPC.ai[0] = 2f;
            }
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1)
            {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
            if (NPC.ai[1] >= 30f)
            {
                /*foreach (Player player in Main.player)
                {
                    if (player.active && !player.dead)
                    {
                        player.GetModPlayer<BismuthPlayer>().ScreenMoveFrom = Vector2.Zero;
                        player.GetModPlayer<BismuthPlayer>().ScreenMoveTo = Vector2.Zero;
                    }
                }      */        
                NPC.life = -1;
                NPC.active = false;
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, NPC.whoAmI, -0f, 0f, 0f, 0, 0, 0);
                return;
            }
            NPC.dontTakeDamage = true;
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            if (NPC.oldVelocity.X != 0f)
                NPC.velocity.X = 0f;           
            if (currentframe == 18 && tick == 5)
            {
                NPC.alpha = 255;
                NPC.ai[0] = 3f;
            }
        }
        int tick = 0;
        int currentframe = 0;
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frameHeight * currentframe;
            if (NPC.ai[0] == 2f)
            {
                tick++;
                if (tick > 6)
                {
                    tick = 0;
                    currentframe++;
                }
            }
        }
    }
}
