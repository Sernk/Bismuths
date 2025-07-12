using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class RivetedHood : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("RivetedSetBonus").Value;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 0;
            Item.defense = 0;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().critDmgMult += 0.1f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<RivetedJacket>() && legs.type == ModContent.ItemType<RivetedBoots>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedRivetedSet = true;
            string RivetedSetBonus = this.GetLocalization("RivetedSetBonus").Value;
            player.setBonus = RivetedSetBonus;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(MIID.ID(4), 8);
            recipe.AddIngredient(MIID.ID(3), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}