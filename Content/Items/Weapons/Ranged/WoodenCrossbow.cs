using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class WoodenCrossbow : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.knockBack = 0;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 10f;
            Item.useStyle = 5;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wooden Crossbow");
           // DisplayName.AddTranslation(GameCulture.Russian, "Деревянный арбалет");           
        }
    }
}
