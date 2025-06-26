using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Ocrea : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ocrea");
            // Tooltip.SetDefault("Movement speed is increased by 8%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Окреа");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения на 8%.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 0;
            Item.value = Item.buyPrice(0, 0, 30, 0);
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
        }       
    }
}