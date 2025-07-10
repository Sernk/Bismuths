using Bismuth.Content.Buffs;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class HornOfGondor : ModItem
    {
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
            return base.UseItem(player);
        }
        public override void HoldItem(Player player)
        {
            player.itemLocation.Y = player.Center.Y + (player.mount.PlayerOffsetHitbox - player.height * 0.5f + 22f) * player.gravDir;
        }
    }
}