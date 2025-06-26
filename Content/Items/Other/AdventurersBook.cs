using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Bismuth.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using ReLogic.Graphics;

namespace Bismuth.Content.Items.Other
{
    public class AdventurersBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Adventurer's Book");
            //DisplayName.AddTranslation(GameCulture.Russian, "Книга приключенца");
            //Tooltip.SetDefault("Contains useful information about player stats");
            //Tooltip.AddTranslation(GameCulture.Russian, "Содержит полезную информацию о характеристиках игрока");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = 0;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
        }
        public override bool? UseItem(Player player)
        {
            if (!player.GetModPlayer<BismuthPlayer>().OpenedBook)
                player.GetModPlayer<BismuthPlayer>().OpenedBook = true;
            return true;
        }
    }
}
