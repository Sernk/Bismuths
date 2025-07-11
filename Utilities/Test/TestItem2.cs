using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Test
{
    public class TestItem2 : ModItem
    {
        public override void SetDefaults()
        {           
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 1;
            Item.maxStack = 999;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
          
        }
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().CanBeFrozenByElemental = true;
            Main.NewText("Skill point add");
            player.GetModPlayer<BismuthPlayer>().SkillPoints++;
            return true;
        }
    }
}