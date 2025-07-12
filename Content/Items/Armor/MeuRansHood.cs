using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MeuRansHood : ModItem
    {
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;
            Item.rare = 9;
            Item.vanity = true;
        }
        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMaskColor = Color.White;
        }
    }   
}