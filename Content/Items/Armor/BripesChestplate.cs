﻿using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BripesChestplate : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 9;
            Item.vanity = true;
        }
    }
}