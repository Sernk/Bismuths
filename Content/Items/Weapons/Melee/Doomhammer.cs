using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class Doomhammer : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 34;
            Item.DamageType = DamageClass.Melee;
            Item.width = 56;
            Item.height = 56;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.crit = 10;
            Item.knockBack = 8;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item15;
            Item.autoReuse = false;
        }
    }
}
