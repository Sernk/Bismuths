using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Weapons.Throwing;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class NagaMerchant : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Naga Merchant");
            //DisplayName.AddTranslation(GameCulture.Russian, "Нага-торговец");
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void Load()
        {
            string NagaNQ_1 = this.GetLocalization("Chat.NagaNQ_1").Value; // Ru: Запомни, главное - никогда не прикуссывай с-с-свой язык. En: Remember – never bite your t-t-tongue.
            string NagaNQ_2 = this.GetLocalization("Chat.NagaNQ_2").Value; // Ru: Я рада, что ты предпочел кровоссоссам нашу великую рас-с-су.
                                                                           // En: I’m glad you chos-s-se our great rac-c-ce over those bloods-s-suckers.
            string NagaNQ_4 = this.GetLocalization("Chat.NagaNQ_4").Value; // Ru: Когда-то давно наша рас-с-са была низвергнута гномами. {0} - один из них.
                                                                           // En: Once upon a time our rac-c-ce got defeated by gnomes. {0} – is one of them.
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 26;
            NPC.height = 48;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f; 
        }      
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "NagaShop";
            }
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override string GetChat()
        {
            string NagaNQ_1 = this.GetLocalization("Chat.NagaNQ_1").Value;
            string NagaNQ_2 = this.GetLocalization("Chat.NagaNQ_2").Value;
            string NagaNQ_4 = this.GetLocalization("Chat.NagaNQ_4").Value;

            if (NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>()) >= 0 && WorldGen.genRand.Next(0, 4) == 0)
                return string.Format(this.GetLocalization("Chat.NagaNQ_4").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName);
            else switch (WorldGen.genRand.Next(0, 2))
                {
                    case 0:
                        return NagaNQ_1;
                    default:
                        return NagaNQ_2;
                }
        }
        public override List<string> SetNPCNameList() => new List<string>()
        {
            this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.NagaName_1");
            this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.NagaName_2");
            this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.NagaName_3");
            this.GetLocalizedValue("Name.Seefeld"), // Language.GetTextValue("Mods.Bismuth.NagaName_4");
            this.GetLocalizedValue("Name.Sqt") // Language.GetTextValue("Mods.Bismuth.NagaName_5");
        };
        public override void AddShops()
        {
            var KilledAnyMechBoss = new Condition("KilledAnyMechBoss", () => NPC.downedMechBossAny);
            var HardMode = new Condition("KilledAnyMechBoss", () => Main.hardMode);

            NPCShop shop = new(Type, "NagaShop");
            shop.Add(ModContent.ItemType<ShellNecklace>());
            shop.Add(ModContent.ItemType<Typhoon>());
            shop.Add(ModContent.ItemType<Breakwater>());
            shop.Add(ModContent.ItemType<FuryOfWaters>(), KilledAnyMechBoss);
            shop.Add(ModContent.ItemType<CoatlsWings>(), HardMode);
            shop.Register();
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
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1)
            {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
            NPC.dontTakeDamage = true;
            if (NPC.oldVelocity.X != 0f)
                NPC.velocity.X = 0f;
            if (Main.LocalPlayer.talkNPC != -1)
            {
                if (Main.npc[Main.LocalPlayer.talkNPC].whoAmI == NPC.whoAmI)
                {
                    UpdatePosition();
                }            
            }
        }
    }
}
