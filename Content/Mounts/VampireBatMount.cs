using Bismuth.BismuthLayerInPlayer;
using Bismuth.Content.Buffs;
using Bismuth.Utilities;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Mounts
{
    public class VampireBatMount : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<VampireBat>();
            MountData.heightBoost = -16;
            MountData.flightTimeMax = Int32.MaxValue;
            MountData.fatigueMax = Int32.MaxValue;
            MountData.fallDamage = 0f;
            MountData.usesHover = true;
            MountData.runSpeed = 8f;
            MountData.dashSpeed = 8f;
            MountData.acceleration = 0.16f;
            MountData.jumpHeight = 10;
            MountData.jumpSpeed = 4f;
            MountData.blockExtraJumps = true;
            MountData.totalFrames = 4;
            int[] array = new int[MountData.totalFrames];
            for (int num2 = 0; num2 < array.Length; num2++)
            {
                array[num2] = 0;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 1;
            MountData.bodyFrame = 0;
            MountData.yOffset = -4;
            MountData.playerHeadOffset = 10;
            MountData.standingFrameCount = 4;
            MountData.standingFrameDelay = 6;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 4;
            MountData.runningFrameDelay = 45;
            MountData.runningFrameStart = 0;
            MountData.flyingFrameCount = 4;
            MountData.flyingFrameDelay = 6;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 4;
            MountData.inAirFrameDelay = 6;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 0;
            MountData.idleFrameDelay = 6;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = true;
            MountData.swimFrameCount = 0;
            MountData.swimFrameDelay = 6;
            MountData.swimFrameStart = 0;          
            MountData.spawnDust = 27;
            if (Main.netMode != 2)
            {
                MountData.textureWidth = MountData.backTexture.Value.Width;
                MountData.textureHeight = MountData.backTexture.Value.Height;
            }
        }
    }
}
