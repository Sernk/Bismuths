using System.ComponentModel;
using Terraria.ModLoader.Config;
namespace Bismuth
{
    public class BismuthConfig : ModConfig
    {
        // You MUST specify a ConfigScope.
        [Header("$Mods.Bismuth.Config.BismuthConfig")] 
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [DefaultValue("1.0")]
        //[Label("XP Multiplier")]
        [LabelKey("$Mods.Bismuth.Config.AllowHealthBuffsTogether")]
        public float XPMultiplier;
        [DefaultValue("0.5")]
        //[Label("Blacksmith Forging Volume")]
        [LabelKey("$Mods.Bismuth.Config.AllowHealthBuffsTogether2")]
        public float BlacksmithForgingVolume;
    }
}