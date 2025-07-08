using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class VisibleAccessory : GlobalItem
    {
        public override void UpdateVisibleAccessory(Item item, Player player, bool hideVisual) // работает не корректно
        {
            //if (player.GetModPlayer<BismuthPlayer>().vampbat)
            //{
            //    player.hideVisibleAccessory[item.type] = true;
            //}
        }
    }
}
