using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class KillersJacket : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Killer's Jacket");
            // Tooltip.SetDefault("Assassin damage is increased by 10%\nCritical strike chance is increased by 4%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Куртка убийцы");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон головореза на 10%. \nУвеличивает шанс критического удара на 4%.");
        }
        public override void SetDefaults()
        {

            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 3;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.10f;
            player.GetCritChance(DamageClass.Melee) += 4;
            player.GetCritChance(DamageClass.Ranged) += 4;
            player.GetCritChance(DamageClass.Magic) += 4;
            player.GetCritChance(DamageClass.Throwing) += 4;
            player.GetModPlayer<ModP>().assassinCrit += 4;
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkEssence>(), 10);   
            recipe.AddIngredient(ItemID.Silk, 50);   
            recipe.AddTile(TileID.Loom);   
            recipe.Register();
        }
    }
}
