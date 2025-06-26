using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class BeggarsCasket : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Beggar's Casket");
            // Tooltip.SetDefault("Impossible to open without a lockpick");
            //DisplayName.AddTranslation(GameCulture.Russian, "Шкатулка бедняка");
            //Tooltip.AddTranslation(GameCulture.Russian, "Требует отмычку для взлома");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 30;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
        }
        public override bool CanRightClick()
        {
            Player player = Main.player[Main.myPlayer];
            for (int num67 = 0; num67 < 58; num67++)
            {
                if (player.inventory[num67].type == ModContent.ItemType<Picklock>() && player.inventory[num67].stack > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public override void RightClick(Player player)
        {
            int casketslot = 0;
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (player.inventory[num66].type == Item.type && player.inventory[num66].stack > 0)
                {
                    casketslot = num66;
                    break;
                }
            }
            for (int num67 = 0; num67 < 58; num67++)
            {
                if (player.inventory[num67].type == ModContent.ItemType<Picklock>() && player.inventory[num67].stack > 0)
                {
                    player.inventory[num67].stack--;
                    player.QuickSpawnItem(player.GetSource_FromThis(), ModContent.ItemType<OpenedBeggarsCasket>());
                    return;
                }
            }
        }
    }
}
