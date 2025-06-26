using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Buffs;

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
            Item.useStyle = 2;
            Item.buffType = ModContent.BuffType<MiningII>();
            Item.buffTime = 18000;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 1, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Improved Mining Potion");
            // Tooltip.SetDefault("Increases mining speed by 50%");
           // DisplayName.AddTranslation(GameCulture.Russian, "Усиленное зелье шахтера");
           // Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость копания на 50%");
        }
    }
}