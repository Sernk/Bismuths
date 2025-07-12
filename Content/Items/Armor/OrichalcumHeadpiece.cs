using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumHeadpiece : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("OrihalcumHeadpieceSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;           
            Item.value = Item.sellPrice(0, 2, 25, 0);
            Item.rare = 4;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
            player.GetDamage(DamageClass.Summon) += 0.17f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves; 
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.09f;
            player.maxMinions++;
            player.setBonus = this.GetLocalization("OrihalcumHeadpieceSetBonus").Value;
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);  
            recipe.AddTile(TileID.MythrilAnvil);  
            recipe.Register();
        }
    }
}