using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;
using Bismuth.Content.Items.Other;

namespace Bismuth.Content.Projectiles
{
    public class WDFix1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("");
            //DisplayName.AddTranslation(GameCulture.Russian, "");
        }

        public override void SetDefaults()
        {
            Projectile.height = 10;
            Projectile.width = 10;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
          //  projectile.alpha = 255;
            Projectile.timeLeft = 1;
            Projectile.hostile = false;
        }

        public override void OnKill(int timeLeft)
        {
            if (BismuthWorld.IsTotemActive)
            {

                BismuthWorld.IsTotemActive = false;
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }
                if (!BismuthWorld.FirstTotemDeactivation)
                {
                    Item.NewItem(Projectile.GetSource_FromThis(), Projectile.position, ModContent.ItemType<FirstPartOfAmulet>());
                    BismuthWorld.FirstTotemDeactivation = true;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                    }
                }
            }
        }
    }
}
