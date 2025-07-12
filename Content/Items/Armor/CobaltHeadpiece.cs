using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CobaltHeadpiece : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("CobaltHeadpieceSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;          
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 4;
            Item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
            player.GetDamage(DamageClass.Summon) += 0.14f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 374 && legs.type == 375;
            
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.07f;
            player.maxMinions++;
            player.setBonus = this.GetLocalization("CobaltHeadpieceSetBonus").Value;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}