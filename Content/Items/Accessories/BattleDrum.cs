using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class BattleDrum : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
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
            player.statLifeMax2 += NPCsCount * 5;
        }
    }
}
