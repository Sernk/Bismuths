using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class OrcishFragment : ModItem
    {
        public override void SetDefaults()
        {      
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 5;
            Item.maxStack = 9999;
        }      
    }
}