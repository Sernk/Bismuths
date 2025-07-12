using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class OrcishHelmet : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("OrcishHelmetSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;
            Item.rare = 3;
            Item.defense = 5;       
            Item.value = Item.sellPrice(0, 0, 40, 0);
        }
        public override void UpdateEquip(Player player)
        {
            player.ThrownVelocity += 0.25f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<OrcishBreastplate>() && legs.type == ModContent.ItemType<OrcishLeggings>();
        }  
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownCost33 = true;
            player.GetCritChance(DamageClass.Throwing) += 8;
            player.setBonus = this.GetLocalization("OrcishHelmetSetBonus").Value;           
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(MIID.ID(2), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}