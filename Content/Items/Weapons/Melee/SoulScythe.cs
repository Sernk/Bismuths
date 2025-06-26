using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class SoulScythe : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.knockBack = 5;
            Item.rare = 0;
            Item.UseSound = SoundID.Item77;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<ScytheSlashHitboxP>();
        }
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Soul Scythe");
            //DisplayName.AddTranslation(GameCulture.Russian, "Коса душ");
            //Tooltip.SetDefault($"Steals certain enemies' souls\nKill harpies, wyverns and angry nimbuses to get [i:{mod.ItemType("AirEssence")}]\nKill sharks, jellyfishes and pirahnas to get [i:{mod.ItemType("WaterEssence")}]\nKill worms to get [i:{mod.ItemType("EarthEssence")}]\nKill imps, lava slimes and demons to get [i:{mod.ItemType("FireEssence")}]");
            //Tooltip.AddTranslation(GameCulture.Russian, $"Крадёт души некоторых противников\nУбивайте злые тучи, гарпий и виверн, чтобы получить [i:{mod.ItemType("AirEssence")}]\nУбивайте акул, медуз и пираний, чтобы получить [i:{mod.ItemType("WaterEssence")}]\nУбивайте червей, чтобы получить [i:{mod.ItemType("EarthEssence")}]\nУбивайте импов, лавовых слизней и демонов, чтобы получить [i:{mod.ItemType("FireEssence")}]");
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
       
            Projectile.NewProjectile(source, player.position, Vector2.Zero, ModContent.ProjectileType<ScytheSlashHitboxP>(), 15, 4f, Main.myPlayer);
            return false;
        }
    }
}
