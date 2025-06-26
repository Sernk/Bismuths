using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class TravelingVampire : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Traveling Vampire");
            //DisplayName.AddTranslation(GameCulture.Russian, "Странствующий вампир");
        }
        public override void Load()
        {
            string TravelingVampireNQ_1 = this.GetLocalization("Chat.TravelingVampireNQ_1").Value; // Ru: Не объяснишь ли ты, почему черепаха живет дольше, нежели целые поколения людей; почему слон переживает целые династии и почему попугай умирает лишь от укуса кошки или собаки, а не от других недугов?
                                                                                                   // En: Can you tell me why the tortoise lives more long than generations of men, why the elephant goes on and on till he have sees dynasties, and why the parrot never die only of bite of cat of dog or other complaint?
            string TravelingVampireNQ_2 = this.GetLocalization("Chat.TravelingVampireNQ_2").Value; // Ru: Кто сказал тебе, что обязательно становится Стражем Болота? En: Who told you that he must become a guard of the swamp?
            string TravelingVampireNQ_3 = this.GetLocalization("Chat.TravelingVampireNQ_3").Value; // Ru: Carpe Jugulum! En: Carpe Jugulum!
            string TravelingVampireNQ_4 = this.GetLocalization("Chat.TravelingVampireNQ_4").Value; // Ru: Ненавижу сумерки. En: I hate Twillight.
            string TravelingVampireNQ_5 = this.GetLocalization("Chat.TravelingVampireNQ_5").Value; // Ru: Людской век краток, вампиры же вечны. En: The time of people’s life is much too short, vampires are eternal.
            string TravelingVampireNQ_6 = this.GetLocalization("Chat.TravelingVampireNQ_6").Value; // Ru: Маскарад поможет тебе остаться незамеченным. En: The Masquerade will help you to disguise.
        }
        public override List<string> SetNPCNameList() => new List<string>()
        {
                this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_1");
                this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_2");
                this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_3");
                this.GetLocalizedValue("Name.Seefeld"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_4");
                this.GetLocalizedValue("Name.Robert"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_5");
                this.GetLocalizedValue("Name.Vlad") // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_6");
        };
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override string GetChat()
        {
            string TravelingVampireNQ_1 = this.GetLocalization("Chat.TravelingVampireNQ_1").Value;
            string TravelingVampireNQ_2 = this.GetLocalization("Chat.TravelingVampireNQ_2").Value;
            string TravelingVampireNQ_3 = this.GetLocalization("Chat.TravelingVampireNQ_3").Value;
            string TravelingVampireNQ_4 = this.GetLocalization("Chat.TravelingVampireNQ_4").Value;
            string TravelingVampireNQ_5 = this.GetLocalization("Chat.TravelingVampireNQ_5").Value;
            string TravelingVampireNQ_6 = this.GetLocalization("Chat.TravelingVampireNQ_6").Value;

            switch (WorldGen.genRand.Next(0, 6))
            {
                case 0:
                    return TravelingVampireNQ_1;
                case 1:
                    return TravelingVampireNQ_2;
                case 2:
                    return TravelingVampireNQ_3;
                case 3:
                    return TravelingVampireNQ_4;
                case 4:
                    return TravelingVampireNQ_5;
                default:
                    return TravelingVampireNQ_6;
            }
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
            NPC.lifeMax = 700;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }

        //public override void AddShops()
        //{
        //    NPCShop shop = new(Type, "VampirShop");
        //}
        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            var Tombstone = new Condition("DownedPlantBoss", () => Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 100);

            shopName = "VampirShop";
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                items[0] = new Item(BismuthWorld.VampShop[0]);
                items[1] = new Item(BismuthWorld.VampShop[1]);
                items[2] = new Item(BismuthWorld.VampShop[2]);
            }
            else
            {
                items[3] = new Item(ModContent.ItemType<Sanguinem>());
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "VampirShop";
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
            if (Main.player[Main.myPlayer].talkNPC >= 0)
            {
                NPC npC = Main.npc[Main.player[Main.myPlayer].talkNPC];
                if (npC.type == NPC.type)
                {
                    UpdatePosition();
                }
            }
            if (Main.dayTime)
            {
                NPC.active = false;
                BismuthWorld.VampShop = new int[3] { 0, 0, 0 };
            }
        }
    }
}
