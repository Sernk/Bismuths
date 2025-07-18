﻿using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Ocrea : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 0;
            Item.value = Item.buyPrice(0, 0, 30, 0);
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
        }       
    }
}