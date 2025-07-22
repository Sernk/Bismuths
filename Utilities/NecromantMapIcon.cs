using Bismuth.Content.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class NecromantMapIcon : ModSystem
    {
        public override void PostDrawFullscreenMap(ref string mouseText)
        {
            if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsEquippedImperianBanner)
                return;

            int necromantType = ModContent.NPCType<Necromant>();

            foreach (NPC npc in Main.npc)
            {
                if (npc.active && npc.type == necromantType)
                {
                    Vector2 mapCoords = npc.Center / 16f;
                    MapIcons.Icon(Mod, ref mouseText, 0, mapCoords.X, mapCoords.Y);
                }
            }
        }
    }
    public class MapIcons
    {
        public static void Icon(Mod mod, ref string text, int type, float x, float y)
        {
            Player player = Main.player[Main.myPlayer];
            MapIcons.DrawIcon(mod, Main.spriteBatch, player, type, x, y);
        }
        public static void DrawIcon(Mod mod, SpriteBatch spriteBatch, Player player, int type, float x, float y)
        {
            string Necromant = LocalizationSystem.Necromant;
            Texture2D texture = ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Necromant_Head").Value;
            string value = Necromant;

            int lineAmount;
            string[] strArray = Utils.WordwrapString(value, FontAssets.MouseText.Value, 460, 10, out lineAmount);
            lineAmount++;
            Vector2 startpositionN = MapIcons.CheckpositionN(new Vector2((float)(x + 1), (float)(y + ((type == 2) ? -7 : 1))));
            if ((double)startpositionN.X > (double)Main.screenWidth - (double)(22 * lineAmount))
            {
                startpositionN.X = (float)(Main.screenWidth - 22 * lineAmount);
            }
            if ((double)startpositionN.X < (double)(22 * lineAmount))
            {
                startpositionN.X = (float)(22 * lineAmount);
            }
            if ((double)startpositionN.Y > (double)Main.screenHeight - (double)(30 * lineAmount))
            {
                startpositionN.Y = (float)(Main.screenHeight - 30 * lineAmount);
            }
            if ((double)startpositionN.Y < 30.0 * (double)lineAmount)
            {
                startpositionN.Y = (float)(30 * lineAmount);
            }
            spriteBatch.Draw(texture, startpositionN, null, Color.White, 0.0f, Utils.Size(texture) / 2f, 1f, SpriteEffects.None, 0f);
            if (Utils.CenteredRectangle(startpositionN, Utils.Size(texture)).Contains(new Point(Main.mouseX, Main.mouseY)) && !PlayerInput.IgnoreMouseInterface)
            {
                float x2 = 0f;
                for (int i = 0; i < lineAmount; i++)
                {
                    float j = FontAssets.MouseText.Value.MeasureString(strArray[i]).X;
                    if ((double)x2 < (double)j)
                    {
                        x2 = j;
                    }
                }
                if ((double)x2 > 460.0)
                {
                    x2 = 460f;
                }
                Vector2 vector2 = new Vector2((float)Main.mouseX, (float)Main.mouseY) + new Vector2(16f);
                if ((double)vector2.Y > (double)(Main.screenHeight - 30 * lineAmount))
                {
                    vector2.Y = (float)(Main.screenHeight - 30 * lineAmount);
                }
                if ((double)vector2.X > (double)Main.screenWidth - (double)x2)
                {
                    vector2.X = (float)Main.screenWidth - x2;
                }
                if (!string.IsNullOrEmpty(value))
                {
                    Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.MouseText.Value, value, vector2.X, vector2.Y, new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), Color.Black, default(Vector2), 1f);
                }
                Main.mouseText = true;
            }
        }
        public static Vector2 CheckpositionN(Vector2 pos)
        {
            Vector2 screen = new Vector2((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2));
            Vector2 fullScreen = pos - Main.mapFullscreenPos;
            fullScreen *= Main.mapFullscreenScale / 16f;
            fullScreen = fullScreen * 16f + screen;
            Vector2 positionN = new Vector2((float)((int)fullScreen.X), (float)((int)fullScreen.Y));
            return positionN;
        }
    }
}