using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Back })]
    public class MrPigeonsCloak : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 28;
            Item.rare = 9;
            Item.accessory = true;
        }
    }
}
