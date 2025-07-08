using Terraria;
using Terraria.ID;
using Bismuth.Content.Items.Materials;
using Terraria.ModLoader;
using Bismuth.Utilities;
using Bismuth.Content.Buffs;
using Bismuth.Utilities.Recipes;

namespace Bismuth.Content.Items.Other
{
    public class Panacea : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Panacea");
            // Tooltip.SetDefault("Saves you from all negative effects");
            //DisplayName.AddTranslation(GameCulture.Russian, "Панацея");
            //Tooltip.AddTranslation(GameCulture.Russian, "Исцеляет от всех негативных эффектов");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 30;
            Item.useStyle = 2;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item3;
            Item.value = Item.buyPrice(0, 0, 75, 0);
            Item.rare = 3;
            Item.consumable = true;
        }
        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < player.buffType.Length; i++)
            {
                if (Main.debuff[player.buffType[i]] && player.buffType[i] != ModContent.BuffType<SkillCooldown>() && player.buffType[i] != BuffID.PotionSickness)
                    player.ClearBuff(player.buffType[i]);
            }
            player.GetModPlayer<BismuthPlayer>().cursepts = 0;
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ToadsEye>(), 3);
            recipe.AddIngredient(ModContent.ItemType<FernFlower>());
            recipe.AddIngredient(ModContent.ItemType<PoisonFlask>());
            recipe.AddTile(TileID.AlchemyTable);
            recipe.AddCondition(PanaceaRecipe.PanaceaRecipes);
            recipe.Register();
        }
    }
}
