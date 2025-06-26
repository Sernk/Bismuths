using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Other
{
    public class BookOfSecrets : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Book Of Secrets");
            // Tooltip.SetDefault("Contains secret knowledge...");
            //DisplayName.AddTranslation(GameCulture.Russian, "Книга секретов");
            //Tooltip.AddTranslation(GameCulture.Russian, "Содержит секретные знания...");
        }
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
