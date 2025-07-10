using Bismuth.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class SolarWind : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 74;
            Item.height = 74;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = 1;
            Item.damage = 62;
            Item.knockBack = 6f;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.rare = 5;
            Item.value = Item.sellPrice(0, 5, 0, 0);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = 1;
                Item.useTime = 16;
                Item.useAnimation = 16;
                Item.shoot = ModContent.ProjectileType<Marker>();
                Item.shootSpeed = 4f;
            }
            else
            {
                Item.useStyle = 1;
                Item.useTime = 16;
                Item.useAnimation = 16;
                Item.damage = 53;
                Item.shoot = ModContent.ProjectileType<SolarWave>();
                Item.shootSpeed = 27f;
            }
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Marker>()] < 1)
                return true;
            else
                return false;
        }
    }
}