using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Prominence : AssassinItem
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Prominence");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Протуберанец");
        //}
        public override void SetDefaults()
        {
            Item.CloneDefaults(3368);
            Item.damage = 52;
            Item.crit = 10;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.ProminenceP>();
            return Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}
