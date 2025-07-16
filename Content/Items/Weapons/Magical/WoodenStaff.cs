using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Magical
{
    public class WoodenStaff : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 6;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 8;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 5;
            Item.staff[Item.type] = true;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<WoodenStaffP>();
            Item.shootSpeed = 11f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}