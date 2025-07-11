using Bismuth.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class HectorsSpear : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 24;
            Item.useAnimation = 18;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<HectorsSpearP>();
            Item.shootSpeed = 3.7f;
            Item.useStyle = 5;
            Item.noUseGraphic = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.damage = 18;
                Item.DamageType = DamageClass.Throwing;
                Item.noMelee = true;
                Item.width = 20;
                Item.height = 20;
                Item.useTime = 24;
                Item.useAnimation = 18;
                Item.knockBack = 4.5f;
                Item.rare = 5;
                Item.UseSound = SoundID.Item1;
                Item.autoReuse = true;
                Item.shoot = ModContent.ProjectileType<HectorsSpearP2>();
                Item.shootSpeed = 12f;
                Item.useStyle = 5;
                Item.noUseGraphic = true;
            }
            else
            {
                Item.damage = 24;
                Item.DamageType = DamageClass.Throwing;
                Item.noMelee = true;
                Item.width = 20;
                Item.height = 20;
                Item.useTime = 24;
                Item.useAnimation = 18;
                Item.knockBack = 4.5f;
                Item.rare = 5;
                Item.UseSound = SoundID.Item1;
                Item.autoReuse = false;
                Item.shoot = ModContent.ProjectileType<HectorsSpearP>();
                Item.shootSpeed = 3.7f;
                Item.useStyle = 5;
                Item.noUseGraphic = true;
            }
            return base.CanUseItem(player);
        }
    }
}