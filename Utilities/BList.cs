using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class BList : ModSystem
    {
        public static List<int> BuffsList;

        public override void OnModLoad()
        {
            BuffsList = new List<int>()
            {
                BuffID.ObsidianSkin,
                BuffID.Regeneration,
                BuffID.Swiftness,
                BuffID.Gills,
                BuffID.Ironskin,
                BuffID.ManaRegeneration,
                BuffID.MagicPower,
                BuffID.Featherfall,
                BuffID.Spelunker,
                BuffID.Invisibility,
                BuffID.Shine,
                BuffID.NightOwl,
                BuffID.Battle,
                BuffID.Thorns,
                BuffID.WaterWalking,
                BuffID.Archery,
                BuffID.Hunter,
                BuffID.Gravitation,
                BuffID.Tipsy,
                BuffID.WellFed,
                BuffID.WellFed2,
                BuffID.WellFed3,
                BuffID.Honey,
                BuffID.WeaponImbueVenom,
                BuffID.WeaponImbueCursedFlames,
                BuffID.WeaponImbueFire,
                BuffID.WeaponImbueGold,
                BuffID.WeaponImbueIchor,
                BuffID.WeaponImbueNanites,
                BuffID.WeaponImbueConfetti,
                BuffID.WeaponImbuePoison,
                BuffID.Lucky,
                BuffID.Mining,
                BuffID.Heartreach,
                BuffID.Calm,
                BuffID.Builder,
                BuffID.Titan,
                BuffID.Flipper,
                BuffID.Summoning,
                BuffID.Dangersense,
                BuffID.AmmoReservation,
                BuffID.Lifeforce,
                BuffID.Endurance,
                BuffID.Rage,
                BuffID.Inferno,
                BuffID.Wrath,
                BuffID.Lovestruck,
                BuffID.Stinky,
                BuffID.Fishing,
                BuffID.Sonar,
                BuffID.Crate,
                BuffID.Warmth,
                BuffID.SugarRush
            };
        }
        public override void Unload()
        {
            BuffsList = null;
        }
    }
}
