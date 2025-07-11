using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Other;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth
{
    public class Bismuth : Mod
    {
        static internal Bismuth instance;
        public static Texture2D VampireFemaleLegs;
        internal static ModKeybind FirstSkillActivate;
        internal static ModKeybind SecondSkillActivate;
        internal static ModKeybind ToggleExpPanelHotKey;
        internal static ModKeybind VampireBatTurnHotKey;
        internal static ModKeybind TeleportActivate;
        public static double pressedToggleExperiencePanelHotKeyTime;
        public static double pressedToggleBat;
        public static DynamicSpriteFont Adonais;
        public static int DwarvenCoinID;
        public static int ImperianHelmetID;
        public static int LoricaID;
        public static int OcreaID;
        public static Texture2D VampireMaleFace;
        public static Texture2D VampireFemaleFace;
        public static Texture2D VampireArms;
        public static Texture2D VampireMaleBody;
        public static Texture2D VampireFemaleBody;
        public static Texture2D VampireMaleLegs;
        public static Texture2D NagaFace;
        public static Texture2D NagaArm;
        public static Texture2D NagaBody;
        public static Texture2D NagaLegs;

        public static Texture2D NagaHeadMap;
        public static Texture2D VampireMaleHeadMap;
        public static Texture2D VampireFemaleHeadMap;

        public static bool noOffsetUpdating;
        //private static Vector2 tempVector;
       // private static Vector2 prevOffsetGoal;
        public static Vector2 oldCameraOffset;
        public static Vector2 screenPos;
        public static Vector2 screenPosNoShakes;
        public static Vector2 cameraShakeOffset;
        private static List<ScreenShake> screenShakes;
        public class ScreenShake
        {
            public float strength;
            public int time;
            public int timeMax;
            public string id;

            public ScreenShake(float strength, int time, string id = null)
            {
                this.strength = strength;
                this.time = time;
                this.timeMax = time;
                this.id = id;
            }
        }
        public Bismuth()
        {
            screenShakes = new List<ScreenShake>();
        }
        public static Vector2 screenHalf
        {
            get
            {
                return new Vector2((float)Main.screenWidth, (float)Main.screenHeight) * 0.5f;
            }
        }     
        public static Vector2 Random2(float max)
        {
            return Bismuth.Random2(-max, max, -max, max);
        }
        public static Vector2 Random2(float minX, float maxX, float minY, float maxY)
        {
            return new Vector2(Main.rand.NextFloat(minX, maxX), Main.rand.NextFloat(minY, maxY));
        }
        public static void CameraUpdate(bool setValues = true)
        {
            Player player = Main.player[Main.myPlayer];
            if (Bismuth.screenShakes.Count > 0)
            {
                for (int index = 0; index < Bismuth.screenShakes.Count; ++index)
                {
                    ScreenShake screenShake = Bismuth.screenShakes[index];
                    float f = screenShake.strength;
                    Vector2 vector2_3 = Bismuth.Random2(f * 0.5f) * ((float)screenShake.time / (float)screenShake.timeMax) * 1;
                    Bismuth.cameraShakeOffset = new Vector2((float)(int)((double)vector2_3.X / (double)Main.GameZoomTarget), (float)(int)((double)vector2_3.Y / (double)Main.GameZoomTarget));
                    Main.screenPosition += cameraShakeOffset;
                    Main.screenPosition = new Vector2((float)Math.Round((double)Main.screenPosition.X), (float)Math.Round((double)Main.screenPosition.Y));
                    if (setValues)
                    {
                        --screenShake.time;
                        if ((double)screenShake.time <= 0.0)
                        {
                            Bismuth.screenShakes.RemoveAt(index);
                            --index;
                        }
                        else
                            Bismuth.screenShakes[index] = screenShake;
                    }
                }
            }
        }
        public static void ShakeScreen(float strength, int time, string id = null)
        {
            int index = id == null ? -1 : screenShakes.FindIndex(q => q.id == id);
            if (id == null || index == -1)
            {
                screenShakes.Add(new ScreenShake(strength, time, id));
            }
            else
            {
                ScreenShake screenShake = screenShakes[index];
                screenShake.strength = strength;
                screenShake.time = time;
                screenShakes[index] = screenShake;
            }
        }      
        public override void Load()
        {
            instance = this;
            //MeuRansHoodGlow.Load();
            DwarvenCoinID = CustomCurrencyManager.RegisterCurrency(new DwarvenCoinData(ModContent.ItemType<DwarvenCoin>(), 999L));
            ImperianHelmetID = CustomCurrencyManager.RegisterCurrency(new ImperianHelmetExchangeData(ModContent.ItemType<ImperianHelmet>(), 999L));
            LoricaID = CustomCurrencyManager.RegisterCurrency(new LoricaExchangeData(ModContent.ItemType<Lorica>(), 999L));
            OcreaID = CustomCurrencyManager.RegisterCurrency(new OcreaExchangeData(ModContent.ItemType<Ocrea>(), 999L));
            VampireMaleFace = ModContent.Request<Texture2D>("Bismuth/RacesTextures/VampireMale_Head").Value;
            VampireFemaleFace = ModContent.Request<Texture2D>("Bismuth/RacesTextures/VampireFemale_Head").Value;
            VampireArms = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Vampire_Arms").Value;
            VampireMaleBody = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Vampire_Body").Value;
            VampireFemaleBody = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Vampire_FemaleBody").Value;
            VampireMaleLegs = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Vampire_Legs").Value;
            VampireFemaleLegs = ModContent.Request<Texture2D>("Bismuth/RacesTextures/VampireFemale_Legs").Value;
            NagaArm = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Naga_Arms").Value;
            NagaBody = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Naga_Body").Value;
            NagaLegs = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Naga_Tail").Value;
            NagaFace = ModContent.Request<Texture2D>("Bismuth/RacesTextures/Naga_Head").Value;
            NagaHeadMap = ModContent.Request<Texture2D>("Bismuth/RacesTextures/NagaMapHead").Value;
            VampireMaleHeadMap = ModContent.Request<Texture2D>("Bismuth/RacesTextures/VampireMaleMapHead").Value;
            VampireFemaleHeadMap = ModContent.Request<Texture2D>("Bismuth/RacesTextures/VampireFemaleMapHead").Value;
            if (!Main.dedServ)
            {
                Filters.Scene["Bismuth:SwampSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.12f, 0.22f, 0.12f).UseOpacity(0.65f), EffectPriority.VeryHigh);
                SkyManager.Instance["Bismuth:SwampSky"] = new SwampSky();
                //EquipLoader.AddEquipTexture(this, "Bismuth/Items/Armor/CompoziussRobe_Legs", EquipType.Legs, name: "CompoziussRobe_Legs");
                //EquipLoader.AddEquipTexture(this, "Bismuth/Items/Armor/NecromancersRobe_Legs", EquipType.Legs, name: "NecromancersRobe_Legs");
                Adonais = ModContent.Request<DynamicSpriteFont>("Bismuth/Fonts/Adonaisxnb", AssetRequestMode.ImmediateLoad).Value;
                TextureAssets.Item[ItemID.Excalibur] = ModContent.Request<Texture2D>("Bismuth/Resprites/Excalibur");
                TextureAssets.Item[ItemID.Drax] = ModContent.Request<Texture2D>("Bismuth/Resprites/Drax");
                TextureAssets.Item[ItemID.HallowedRepeater] = ModContent.Request<Texture2D>("Bismuth/Resprites/HallowedRepeater");
                TextureAssets.Item[ItemID.PickaxeAxe] = ModContent.Request<Texture2D>("Bismuth/Resprites/PickaxeAxe");
                TextureAssets.Item[ItemID.LightDisc] = ModContent.Request<Texture2D>("Bismuth/Resprites/LightDisc");
                TextureAssets.Projectile[ProjectileID.LightDisc] = ModContent.Request<Texture2D>("Bismuth/Resprites/LightDisc");
                TextureAssets.Projectile[ItemID.Drax] = ModContent.Request<Texture2D>("Bismuth/Resprites/Drax_proj");
            }

            FirstSkillActivate = KeybindLoader.RegisterKeybind(this, "Activate First Skill", "N");
            SecondSkillActivate = KeybindLoader.RegisterKeybind(this, "Toggle Experience Panel", "J");
            ToggleExpPanelHotKey = KeybindLoader.RegisterKeybind(this, "Activate Unique Ability", "Q");
            VampireBatTurnHotKey = KeybindLoader.RegisterKeybind(this, "Turn Into Bat", "T");
            TeleportActivate = KeybindLoader.RegisterKeybind(this, "Activate Second Skill", "U");
        }

        public override void Unload()
        {
            VampireMaleFace = null;
            VampireFemaleFace = null;
            VampireArms = null;
            VampireMaleBody = null;
            VampireFemaleBody = null;
            VampireMaleLegs = null;
            VampireFemaleLegs = null;
            NagaArm = null;
            NagaBody = null;
            NagaLegs = null;
            NagaFace = null;
            NagaHeadMap = null;
            VampireMaleHeadMap = null;
            VampireFemaleHeadMap = null;
            //MeuRansHoodGlow.Unload();
            instance = null;
            Adonais = null;
            ToggleExpPanelHotKey = null;
            VampireBatTurnHotKey = null;
            FirstSkillActivate = null;
            SecondSkillActivate = null;
            TeleportActivate = null;
            TextureAssets.Item[ItemID.Excalibur] = ModContent.Request<Texture2D>("Bismuth/Resprites/Excalibur");
            TextureAssets.Item[ItemID.Drax] = ModContent.Request<Texture2D>("Bismuth/Resprites/Drax");
            TextureAssets.Item[ItemID.HallowedRepeater] = ModContent.Request<Texture2D>("Bismuth/Resprites/HallowedRepeater");
            TextureAssets.Item[ItemID.PickaxeAxe] = ModContent.Request<Texture2D>("Bismuth/Resprites/PickaxeAxe");
            TextureAssets.Item[ItemID.LightDisc] = ModContent.Request<Texture2D>("Bismuth/Resprites/LightDisc");
            TextureAssets.Projectile[ProjectileID.LightDisc] = ModContent.Request<Texture2D>("Bismuth/Resprites/LightDisc");
            TextureAssets.Projectile[ItemID.Drax] = ModContent.Request<Texture2D>("Bismuth/Resprites/Drax_proj");
        }
        //public override void UpdateMusic(ref int music)/* tModPorter Note: Removed. Use ModSceneEffect.Music and .Priority, aswell as ModSceneEffect.IsSceneEffectActive */
        //{
        //    if (!Main.gameMenu)
        //    {
        //        if (BismuthWorld.OrcishInvasionStage == 1)
        //        {
        //            music = MusicID.OldOnesArmy;
        //            return;
        //        }
        //    }
        //}
        //public override void PostSetupContent()
        //{
        //    var bossChecklist = ModLoader.GetMod("BossChecklist");
        //    if (bossChecklist != null)
        //    {
        //        //SlimeKing = 1f;
        //        //EyeOfCthulhu = 2f;
        //        //EaterOfWorlds = 3f;
        //        //QueenBee = 4f;
        //        //1.4_1 = 5f  
        //        //Skeletron = 6f;
        //        //WallOfFlesh = 7f;
        //        //1.4_2 = 8f  
        //        //TheTwins = 9f;
        //        //TheDestroyer = 10f;
        //        //SkeletronPrime = 11f;
        //        //Plantera = 12f;
        //        //1.4_3 = 13f  
        //        //Golem = 14f;
        //        //DukeFishron = 15f;
        //        //LunaticCultist = 16f;
        //        //Moonlord = 17f;
        //        bossChecklist.Call("AddBoss", 3.5f, ModContent.NPCType<NPCs.Minotaur>(), this, "Minotaur", (Func<bool>)(() => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().downedMinotaur), new List<int> { }, new List<int> { }, new List<int> { ModContent.ItemType<Items.Other.MinotaurHorn>(), ModContent.ItemType<Items.Tools.MinotaursWaraxe>(), ModContent.ItemType<Items.Weapons.Melee.Narsil>() }, "Spawns only after opening red chest in maze");
        //        bossChecklist.Call("AddMiniBoss", 1.5f, ModContent.NPCType<NPCs.Banshee>(), this, "Banshee", (Func<bool>)(() => BismuthWorld.downedBanshee), new List<int> { }, new List<int> { }, new List<int> { ModContent.ItemType<Items.Accessories.BansheesHead>() }, "Spawns only if you enter water temple");
        //        bossChecklist.Call("AddBoss", 4.5f, ModContent.NPCType<NPCs.EvilBabaYaga>(), this, "Swamp Witch", (Func<bool>)(() => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().downedWitch), new List<int> { }, new List<int> { }, new List<int> { ModContent.ItemType<Items.Materials.LightPartOfArchmagesAmulet>(), ModContent.ItemType<Items.Other.PanaceaScroll>(), ModContent.ItemType<Items.Materials.PoisonFlask>(), ModContent.ItemType<Items.Accessories.TransmutationAmulet>(), ModContent.ItemType<Items.Weapons.Assassin.SnakesFang>() }, "" + "Spawns after completing quest \"Mystery of Swamp\". You should keep [i:" + ModContent.ItemType<Items.Other.UnchargedElessar>() + "] to fight her.");
        //        bossChecklist.Call("AddBoss", 4.25f, ModContent.NPCType<NPCs.EvilNecromancer>(), this, "Necromancer", (Func<bool>)(() => BismuthWorld.DownedNecromancer), new List<int> { }, new List<int> { }, new List<int> { ModContent.ItemType<Items.Materials.DarkPartOfArchmagesAmulet>(), ModContent.ItemType<Items.Materials.DarkEssence>(), ModContent.ItemType<Items.Armor.NecromancersHood>(), ModContent.ItemType<Items.Armor.NecromancersRobe>(), ModContent.ItemType<Items.Accessories.NecromancersRing>(), ModContent.ItemType<Items.Accessories.LichCrown>(), ModContent.ItemType<Items.Other.MirrorOfUndead>(), ModContent.ItemType<Items.Materials.DarkEngraving>(), }, "" + "Spawns in his den after completing quest \"Gravedigger\". You need to report to consul about priest to fight him.");
        //        bossChecklist.Call("AddMiniBoss", 6.5f, ModContent.NPCType<NPCs.PapuanWizard>(), this, "Papuan Wizard", (Func<bool>)(() => BismuthWorld.DownedPapuanWizard), new List<int> { }, new List<int> { }, new List<int> { ModContent.ItemType<Items.Weapons.Magical.ShamansStaff>(), ModContent.ItemType<Items.Other.EmpathyMirror>(), ModContent.ItemType<Items.Armor.NomadsJacket>(), ModContent.ItemType<Items.Armor.NomadsJacket>(), ModContent.ItemType<Items.Armor.NomadsBoots>() }, "Spawns in the desert town in hardmode");
        //        bossChecklist.Call("AddMiniBoss", 5.5f, ModContent.NPCType<NPCs.RhinoOrc>(), this, "Rhino Orc", (Func<bool>)(() => BismuthWorld.DownedRhino), new List<int> { }, new List<int> { }, new List<int> { ModContent.ItemType<Items.Accessories.BattleDrum>(), ModContent.ItemType<Items.Accessories.BerserksRing>(), ModContent.ItemType<Items.Weapons.Melee.Doomhammer>(), ModContent.ItemType<Items.Weapons.Assassin.Stiletto>() }, "Spawns during orcish invasion");
        //    }
        //}

    }
}