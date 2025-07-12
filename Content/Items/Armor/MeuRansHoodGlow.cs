using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    public static class MeuRansHoodGlow
    {
        const short Count = 1;
        public static short MeuRansHoodG;
        static short End;
        public static bool Loaded;

        public static void Load()
        {
            Array.Resize(ref TextureAssets.GlowMask, TextureAssets.GlowMask.Length + MeuRansHoodGlow.Count);
            short i = (short)(TextureAssets.GlowMask.Length - MeuRansHoodGlow.Count);

            TextureAssets.GlowMask[i] = ModContent.Request<Texture2D>("Bismuth/Content/Items/Armor/MeuRansHood_HeadGlow");
            MeuRansHoodGlow.MeuRansHoodG = i;
            i++;
            MeuRansHoodGlow.End = i;
            MeuRansHoodGlow.Loaded = true;
        }

        public static void Unload()
        {

            if (TextureAssets.GlowMask.Length == End)
            {
                Array.Resize(ref TextureAssets.GlowMask, TextureAssets.GlowMask.Length - Count);
            }
            else if (TextureAssets.GlowMask.Length > End && TextureAssets.GlowMask.Length > Count)
            {
                for (int i = End - Count; i < End; i++)
                {
                    TextureAssets.GlowMask[i] = ModContent.Request<Texture2D>("Terraria/Item_0");
                }
            }
            Loaded = false;
            MeuRansHoodG = 0;
            End = 0;
        }
    }
}
