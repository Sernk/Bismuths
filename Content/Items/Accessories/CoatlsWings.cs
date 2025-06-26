using System.Collections.Generic;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.DataStructures;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class CoatlsWings : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Coatl's Wings");
            //Tooltip.SetDefault("Allows flight and slow fall");
            //DisplayName.AddTranslation(GameCulture.Russian, "Крылья коатля");
            //Tooltip.AddTranslation(GameCulture.Russian, "Позволяют вам летать и поглощают урон от падения");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(flyTime: 60, 7.5f, 1f);
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 30, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 60;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
               ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 7.5f;
            acceleration *= 2f;
        }
    }
}