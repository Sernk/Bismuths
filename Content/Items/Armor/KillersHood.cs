using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class KillersHood : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("KillerSetBonus").Value ;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 7, 0, 0);
            Item.rare = 3;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 8;
            player.GetCritChance(DamageClass.Ranged) += 8;
            player.GetCritChance(DamageClass.Magic) += 8;
            player.GetCritChance(DamageClass.Throwing) += 8;
            player.GetModPlayer<ModP>().assassinCrit += 8;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<KillersJacket>() && legs.type == ModContent.ItemType<KillersBoots>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = this.GetLocalization("KillerSetBonus").Value;
            player.GetModPlayer<BismuthPlayer>().killersetbonus = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkEssence>(), 8);   
            recipe.AddIngredient(ItemID.Silk, 40);   
            recipe.AddTile(TileID.Loom);   
            recipe.Register();
        }
    }
}