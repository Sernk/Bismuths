using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Lorica : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lorica");
            //DisplayName.AddTranslation(GameCulture.Russian, "Лорика");
        }
        public override void SetDefaults()
        {

            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.rare = 0;
            Item.defense = 2;
        }     
    }
}