using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedFaceShield : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("HallowedFaceShieldSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;          
            Item.value = Item.sellPrice(0, 2, 92, 0);
            Item.rare = 4;
            Item.defense = 13;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.14f;
            player.ThrownVelocity += 0.14f;
            player.GetCritChance(DamageClass.Throwing) += 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownVelocity += 0.35f;
            player.setBonus = this.GetLocalization("HallowedFaceShieldSetBonus").Value; ;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(1225, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}