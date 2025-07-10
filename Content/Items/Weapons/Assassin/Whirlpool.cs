using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Whirlpool : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 8;
            Item.useAnimation = 24;
            Item.knockBack = 4;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<WhirlpoolP>();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<WhirlpoolP>()] < 1;
        }
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Whirlpool");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Водоворот");
        //    Tooltip.SetDefault("Creates spinning vortex around the player");
        //    Tooltip.AddTranslation(GameCulture.Russian, "Создаёт вращающийся вихрь вокруг игрока");

        //}
    }
}
