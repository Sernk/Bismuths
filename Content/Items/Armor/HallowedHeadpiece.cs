using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedHeadpiece : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("HallowedHeadpieceSetBonus").Value;
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
            player.maxMinions += 2;
            player.GetDamage(DamageClass.Summon) += 0.21f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
           
            player.maxMinions++;
            player.GetDamage(DamageClass.Summon) += 0.16f;
            player.setBonus = this.GetLocalization("HallowedHeadpieceSetBonus").Value; ;
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