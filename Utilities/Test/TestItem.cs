using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Test
{
    public class TestItem : ModItem
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
            player.GetModPlayer<BismuthPlayer>().WaitPhilosopherStone = 0;
            player.GetModPlayer<BismuthPlayer>().WaitTabula = 86400;
            Main.NewText(ModContent.GetInstance<BismuthConfig>().XPMultiplier);
            if (!player.GetModPlayer<BismuthPlayer>().KilledEoC)            
                player.GetModPlayer<BismuthPlayer>().KilledEoC = true;            
            else if (!player.GetModPlayer<BismuthPlayer>().KilledWormorBrain)
                player.GetModPlayer<BismuthPlayer>().KilledWormorBrain = true;
            else if(!player.GetModPlayer<BismuthPlayer>().KilledSkeletron)
                player.GetModPlayer<BismuthPlayer>().KilledSkeletron = true;
            else if(!player.GetModPlayer<BismuthPlayer>().KilledWoF)
                player.GetModPlayer<BismuthPlayer>().KilledWoF = true;
            else if(!player.GetModPlayer<BismuthPlayer>().KilledAnyMechBoss)
                player.GetModPlayer<BismuthPlayer>().KilledAnyMechBoss = true;
            else if(!player.GetModPlayer<BismuthPlayer>().KilledPlantera)
                player.GetModPlayer<BismuthPlayer>().KilledPlantera = true;
            else if(!player.GetModPlayer<BismuthPlayer>().KilledGolem)
                player.GetModPlayer<BismuthPlayer>().KilledGolem = true;
            else if(!player.GetModPlayer<BismuthPlayer>().KilledCultist)            
                player.GetModPlayer<BismuthPlayer>().KilledCultist = true; 
            if(player.GetModPlayer<BismuthPlayer>().KilledBossesCount < 6)
                player.GetModPlayer<BismuthPlayer>().KilledBossesCount++;
            Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest = 100;
            Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest = 20;
            return true;
        }
    }
}