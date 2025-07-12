using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Placeable;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class MIID : ModSystem // Mod Item ID
    {
        public static int ID(int id)
        {
            switch (id)
            {
                case 1: return ModContent.ItemType<BismuthumBar>();
                case 2: return ModContent.ItemType<OrcishBar>();
                case 3: return ModContent.ItemType<AluminiumBar>();
                case 4: return ModContent.ItemType<AnimalSkin>();
                default: return ItemID.DirtBlock;
            }
        }
    }
}