using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class ManGosh : AssassinItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Man-Gosh");
            //DisplayName.AddTranslation(GameCulture.Russian, "Мэн-гош");
            // Tooltip.SetDefault("+25% block chance holding this weapon in an active slot");
            //Tooltip.AddTranslation(GameCulture.Russian, "+25% к шансу блокирование, пока оружие находится в активном слоте");
        }
        public override void SetDefaults()
        {
            Item.damage = 23;
            Item.crit = 10;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
    }
}