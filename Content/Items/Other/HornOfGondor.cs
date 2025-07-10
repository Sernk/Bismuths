using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Bismuth.Content.Buffs;

namespace Bismuth.Content.Items.Other
{
    public class HornOfGondor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Battle Horn");
            // Tooltip.SetDefault("Use to raise your battle spirit");
            //DisplayName.AddTranslation(GameCulture.Russian, "Боевой рог");
            //Tooltip.AddTranslation(GameCulture.Russian, "Повышает ваш боевой дух");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = 3;
            Item.useStyle = 4;
            Item.useTime = 170;
            Item.useAnimation = 170;
            Item.UseSound = new SoundStyle("Bismuth/Sounds/Item/Horn_Sound");
        }
        public override bool CanUseItem(Player player)
        {
            return !player.HasBuff(ModContent.BuffType<FightingSpirit>());
        }
        public override bool? UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<FightingSpirit>(), 5400);
            return UseItem(player);
        }
        public override void HoldItem(Player player)
        {
            player.itemLocation.Y = player.Center.Y + (player.mount.PlayerOffsetHitbox - player.height * 0.5f + 22f) * player.gravDir;
        }
    }
}
