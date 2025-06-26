using Bismuth.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
namespace Bismuth.UI
{
    public class UIs : ModSystem
    {
        public override void PostDrawInterface(SpriteBatch sb)
        {
            Levels levels = Main.player[Main.myPlayer].GetModPlayer<Levels>();
            levels.DRAW(sb);
            BismuthPlayer Bismuthplayer = (BismuthPlayer)Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>();
            Bismuthplayer.DrawRaceBar(sb);
            DiceGame Dicegame = (DiceGame)Main.player[Main.myPlayer].GetModPlayer<DiceGame>();
            Dicegame.DrawTable(sb);
            Quests questbook = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            questbook.DrawBook(sb);
        }
    }
}
