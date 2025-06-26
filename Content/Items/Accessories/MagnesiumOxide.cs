using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Localization;

namespace Bismuth.Content.Items.Accessories
{
    public class MagnesiumOxide : ModItem
    {     
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Magnesium Oxide");
            // Tooltip.SetDefault("40% increased thrown velosity, 8% decreased thrown damage.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Порошок оксида магния");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость броска метательного снаряда на 40%\nСнижает метательный урон на 8%");
        }
        public override void SetDefaults()
        {            
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.accessory = true;
        }     
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.ThrownVelocity += 0.4f;
            player.GetDamage(DamageClass.Throwing) -= 0.08f;
        }
    }
}