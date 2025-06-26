using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class VampireBat : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Vampire Bat");
            // Description.SetDefault("Na-na-na-na-na-na-na-na, Batmaaan, Batmaaan");
           // DisplayName.AddTranslation(GameCulture.Russian, "Летучая мышь");
           // Description.AddTranslation(GameCulture.Russian, "На-на-на-на-на-на-на-на, Бэтмэээн, Бэтмэээн");
            Main.buffNoTimeDisplay[this.Type] = true;
            Main.buffNoSave[this.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
           // player.mount.SetMount(MountType<Mounts.VampireBatMount>(), player, false);
            player.buffTime[buffIndex] = 10;          
            player.ClearBuff(24);
            player.GetModPlayer<BismuthPlayer>().vampbat = true;           
        }
    }
}