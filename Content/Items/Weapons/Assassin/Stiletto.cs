using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Stiletto : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.crit = 15;
            Item.noMelee = true;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useTurn = false;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<StilettoP>();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<StilettoP>()] < 1;
        }
    }
}