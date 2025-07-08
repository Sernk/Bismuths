using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class TheseusSword : ModItem
    {

        public override void SetDefaults()
        {
            Item.useTurn = true;
            Item.damage = 27;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 6;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Theseus Sword");
            //DisplayName.AddTranslation(GameCulture.Russian, "Меч Тесея");
            // Tooltip.SetDefault("Creates eight projectiles flying in different directions after combo of strikes");
            //Tooltip.AddTranslation(GameCulture.Russian, "Создаёт восемь летящих снарядов после серии ударов");
        }
        //bool flag = false;
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (player.GetModPlayer<BismuthPlayer>().TheseusCombo == 100)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(0f, -12f), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(0f, 12f), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(12f, 0), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(-12f, 0f), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(8.485281f, 8.485281f), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(8.485281f, -8.485281f), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(-8.485281f, 8.485281f), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Vector2(-8.485281f, -8.485281f), ModContent.ProjectileType<TheseusWaveP>(), 40, 4f, player.whoAmI);
                player.GetModPlayer<BismuthPlayer>().TheseusCombo = -1;
             //   flag = false;
            }
            if (player.GetModPlayer<BismuthPlayer>().TheseusCombo > 90)
            {
                player.GetModPlayer<BismuthPlayer>().TheseusCombo += 100 - player.GetModPlayer<BismuthPlayer>().TheseusCombo;
               // flag = true;
            }
            else if(player.GetModPlayer<BismuthPlayer>().TheseusCombo == -1)
                player.GetModPlayer<BismuthPlayer>().TheseusCombo = 0;
            else
                player.GetModPlayer<BismuthPlayer>().TheseusCombo += 10;
        }
    }
}
