using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHeadpiece : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("ChlorophyteHeadpieceSetBonus").Value;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 4, 70, 0);
            Item.rare = 7;
            Item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 3;
            player.GetDamage(DamageClass.Summon) += 0.27f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.maxMinions++;
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.setBonus = this.GetLocalization("ChlorophyteHeadpieceSetBonus").Value;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(1006, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}