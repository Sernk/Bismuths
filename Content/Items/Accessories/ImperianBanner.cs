using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Bismuth.Utilities;
using Bismuth.Content.Buffs;

namespace Bismuth.Content.Items.Accessories
{
    public class ImperianBanner : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Imperial Banner");
            // Tooltip.SetDefault("+15 charm. Increases life regeneration when you are in the city. \nMore town NPCs - more defence.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Имперский штандарт");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает обаяние на 15. Увеличивает регенерацию здоровья,\nесли вы в городе. Больше заселенных НИПов - больше защиты.");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            int NPCsCount = 0;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (Main.npc[i].active && Main.npc[i].townNPC && Main.npc[i].life > 0 && Main.npc[i].aiStyle != -1)
                    NPCsCount++;
            }
            if (NPCsCount > 20)
                NPCsCount = 20;
            player.GetModPlayer<BismuthPlayer>().Charm += 15;
            player.statDefense = player.statDefense + (NPCsCount / 2);
            if (player.FindBuffIndex(ModContent.BuffType<AuraOfEmpire>()) != -1 && player.lifeRegen >= 0)
                player.lifeRegen += 8;
        }
    }
}