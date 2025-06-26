using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class SacrificialDagger : AssassinItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sacrificial Dagger");
            // Tooltip.SetDefault("A critical strike deals four times the normal damage");
            //DisplayName.AddTranslation(GameCulture.Russian, "Жертвенный кинжал");
            //Tooltip.AddTranslation(GameCulture.Russian, "Критические удары наносят четырехкратный урон");
        }
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.crit = 10;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
    }
}