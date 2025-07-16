using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class BookOfSecrets : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 3;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100) 
                return true;
            else
                return false;
        }
        public override bool? UseItem(Player player)
        {
            if (!player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
            {
                player.GetModPlayer<BismuthPlayer>().SkillPoints++;
            }
            player.GetModPlayer<BismuthPlayer>().IsBoSRead = true;
            return true;
        }
    }
}
