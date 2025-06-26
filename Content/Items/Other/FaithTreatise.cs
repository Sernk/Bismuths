using Terraria;
using Bismuth.Utilities;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class FaithTreatise : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Faith Treatise");
            // Tooltip.SetDefault("Gives you permanent a life regeneration bonus on use\nOnce per day you can restore 40% of your HP, \n if it's under 20%");
            //DisplayName.AddTranslation(GameCulture.Russian, "Трактат веры");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию здоровья после использования\nРаз в день вы можете восстановить 40% здоровья, если\nу вас его менее 20%");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 3;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (!player.GetModPlayer<BismuthPlayer>().IsFTRead)
                return true;
            else
                return false;
        }
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().IsFTRead = true;
            player.GetModPlayer<BismuthPlayer>().FTDaily = true;
            return true;
        }
    }
}
