using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.NPCs;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class BossChecklistSuport : ModSystem
    {
        public override void PostSetupContent()
        {
            DoBossChecklistIntegration();
        }

        private void DoBossChecklistIntegration()
        {

            if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
            {
                return;
            }

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }
            string internalName = "MinotaurB";

            float weight = 3.5f;

            Func<bool> downed = () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().downedMinotaur;

            int bossType = ModContent.NPCType<Minotaur>();

            //int spawnItem = ModContent.ItemType<MechanicalMonitor>();

            List<int> collectibles = new List<int>()
            {
                ModContent.ItemType<MinotaurHorn>(),
                ModContent.ItemType<MinotaursWaraxe>(),
                ModContent.ItemType<Narsil>()
            };

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalName,
                weight,
                downed,
                bossType,
                new Dictionary<string, object>()
                {
                    ["collectibles"] = collectibles,
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
                "LogMiniBoss",
                Mod,
                internalName = "BansheeBoss",
                weight = 1.5f,
                downed = (Func<bool>)(() => BismuthWorld.downedBanshee),
                bossType = ModContent.NPCType<Banshee>(),
                new Dictionary<string, object>()
                {
                    //["spawnItems"] = spawnItem = ModContent.ItemType<SteamCrown>(),
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }
            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalName = "EvilBabaYagaBoss",
                weight = 4.5f,
                downed = (Func<bool>)(() => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().downedWitch),
                bossType = ModContent.NPCType<EvilBabaYaga>(),
                new Dictionary<string, object>()
                {
                    //["spawnItems"] = spawnItem = ModContent.ItemType<SteamCrown>(),
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
                "LogBoss",
                Mod,
                internalName = "EvilNecromancerBoss",
                weight = 4.25f,
                downed = (Func<bool>)(() => BismuthWorld.DownedNecromancer),
                bossType = ModContent.NPCType<EvilNecromancer>(),
                new Dictionary<string, object>()
                {
                    //["spawnItems"] = spawnItem = ModContent.ItemType<SteamCrown>(),
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
                "LogMiniBoss",
                Mod,
                internalName = "PapuanWizardBoss",
                weight = 7.5f,
                downed = (Func<bool>)(() => BismuthWorld.DownedPapuanWizard),
                bossType = ModContent.NPCType<PapuanWizard>(),
                new Dictionary<string, object>()
                {
                    //["spawnItems"] = spawnItem = ModContent.ItemType<SteamCrown>(),
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }
            bossChecklistMod.Call(
                "LogMiniBoss",
                Mod,
                internalName = "RhinoOrcBoss",
                weight = 5.5f,
                downed = (Func<bool>)(() => BismuthWorld.DownedRhino),
                bossType = ModContent.NPCType<RhinoOrc>(),
                new Dictionary<string, object>()
                {
                    //["spawnItems"] = spawnItem = ModContent.ItemType<SteamCrown>(),
                }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }
        }
    }
}