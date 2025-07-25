﻿using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class DarkPartOfArchmagesAmulet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 6;
            Item.material = true;
        }
    }
}