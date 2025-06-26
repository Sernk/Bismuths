using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class FearOfMaze : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fear of Maze");
            // Description.SetDefault("You so scared, and you can't use the map, place torches and teleport");
            //DisplayName.AddTranslation(GameCulture.Russian, "Страх лабиринта");
            //Description.AddTranslation(GameCulture.Russian, "Вы так напуганы что не можете использовать карту, ставить факелы и телепортироваться");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
                        
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.headcovered = true;           
        }
    }
}