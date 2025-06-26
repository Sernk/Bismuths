using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class KillersBoots : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Killer's Boots");
            // Tooltip.SetDefault("Movement speed is increased by 20%, critical damage is increased by 25%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ботинки убийцы");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения на 20%, увеличивает критический урон на 25%.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 3;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.2f;
            player.GetModPlayer<BismuthPlayer>().critDmgMult += 0.25f;
        }
        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkEssence>(), 6);   
            recipe.AddIngredient(ItemID.Silk, 35);   
            recipe.AddTile(TileID.Loom);   
            recipe.Register();
        }
    }
}