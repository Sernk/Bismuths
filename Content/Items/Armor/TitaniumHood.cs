using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumHood : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("TitaniumHoodSetBonus").Value;
        }
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;      
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 4;
            Item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.22f;
            player.maxMinions += 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.12f;
            player.maxMinions++;
            player.setBonus = this.GetLocalization("TitaniumHoodSetBonus").Value;
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TitaniumBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}