using Terraria;
using Terraria.ID;
using Bismuth.Utilities;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Other
{
    public class TabulaSmaragdina : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tabula Smaragdina");
            // Tooltip.SetDefault("Ancient artifact needed to create aether");
            //DisplayName.AddTranslation(GameCulture.Russian, "Изумрудная скрижаль");
            //Tooltip.AddTranslation(GameCulture.Russian, "Древний артефакт, необходимый для создания эфира");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 100)
                return true;
            else
                return false;
        }
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().TabulaResearch = true;
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PieceOfTabula>(), 7);
            recipe.Register();
        }
    }
}
