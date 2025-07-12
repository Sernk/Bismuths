using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHood : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("PalladiumHoodSetBonus").Value;
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
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.maxMinions += 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.07f;
            player.maxMinions++;
            player.setBonus = this.GetLocalization("PalladiumHoodSetBonus").Value;
        }
        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}