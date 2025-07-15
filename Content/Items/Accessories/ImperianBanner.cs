using Bismuth.Content.Buffs;
using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class ImperianBanner : ModItem
    {
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