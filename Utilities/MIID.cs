namespace Bismuth.Utilities
{
    public class MIID : Terraria.ModLoader.ModSystem // Mod Item ID
    {
        static int BismuthumBar;

        public static int ID(int id)
        {
            BismuthumBar = Terraria.ModLoader.ModContent.ItemType<Content.Items.Placeable.BismuthumBar>();
            if (id == 1) return BismuthumBar;
            return 1;
        }
    }
}