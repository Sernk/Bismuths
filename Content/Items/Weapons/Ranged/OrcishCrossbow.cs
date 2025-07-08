using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class OrcishCrossbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 75, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 21f;
            Item.useStyle = 5;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Orcish Crossbow");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орочий арбалет");
        }
    }
}
