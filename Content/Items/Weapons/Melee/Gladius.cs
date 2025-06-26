using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class Gladius : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 6;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useStyle = 1;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gladius");
            //DisplayName.AddTranslation(GameCulture.Russian, "Гладиус");
        }
    }
}
