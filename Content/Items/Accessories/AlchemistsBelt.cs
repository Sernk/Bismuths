using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class AlchemistsBelt : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Alchemist's Belt");
            // Tooltip.SetDefault("Buff duration of all potions is increased by 15%\n Healing potions' cooldown is shortened by 5 seconds");
            //DisplayName.AddTranslation(GameCulture.Russian, "Пояс алхимика");
            //Tooltip.AddTranslation(GameCulture.Russian, "Время действия всех зелий увеличено на 15%\n Кулдаун использования лечебных зелий снижен на 5 секунд");
        }
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedBelt = true;
            //player.GetJumpState(ExtraJump.CloudInABottle).Enable();
        }
    }
}