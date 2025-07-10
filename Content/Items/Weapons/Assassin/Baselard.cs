using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Bismuth.Utilities;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Baselard : AssassinItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Baselard");
            //DisplayName.AddTranslation(GameCulture.Russian, "Баселард");
            //Tooltip.SetDefault("<right> to use as throwing weapon");
            //Tooltip.AddTranslation(GameCulture.Russian, "<right> чтобы использовать как метательное оружие");
        }
        public override bool IsLoadingEnabled(Mod mod)
        {
            return true;
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.useStyle = 1;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.knockBack = 3f;
            Item.scale = 1f;
           /* item.width = 32;
            item.height = 32;*/
            Item.rare = 5;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.noMelee = true;          
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.useTurn = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool? UseItem(Player player)
        {
            return UseItem(player);
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = 1;
                Item.damage = 18;
                Item.shoot = ModContent.ProjectileType<BaselardP>();
                Item.shootSpeed = 12f;
                Item.noUseGraphic = true;
                Item.scale = 1f;
                Item.noMelee = true;
            }
            else
            {
                Item.noMelee = false;
                Item.useStyle = 1;
                Item.noUseGraphic = false;
                Item.scale = 1f;
            }
            return CanUseItem(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse != 2)
                return false;
            else
                return true;
        }
    }
}