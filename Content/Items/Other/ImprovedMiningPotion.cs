using Bismuth.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class ImprovedMiningPotion : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 34;
            Item.useTurn = true;
            Item.maxStack = 30;
            Item.rare = 3;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.buffType = ModContent.BuffType<MiningII>();
            Item.buffTime = 18000;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 1, 0, 0);
        }
    }
}