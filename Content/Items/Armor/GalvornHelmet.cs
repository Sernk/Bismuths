using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class GalvornHelmet : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("GalvornSetBonus").Value;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 25, 0);
            Item.rare = 2;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 7;
            player.GetCritChance(DamageClass.Ranged) += 7;
            player.GetCritChance(DamageClass.Magic) += 7;
            player.GetCritChance(DamageClass.Throwing) += 7;
            player.GetModPlayer<ModP>().assassinCrit += 7;
            player.GetModPlayer<BismuthPlayer>().critDmgMult += 0.25f;
            player.moveSpeed -= 0.03f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GalvornBreastplate>() && legs.type == ModContent.ItemType<GalvornLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.endurance += 0.1f;
            player.GetModPlayer<BismuthPlayer>().BlockChance += 10;
            player.setBonus = this.GetLocalization("GalvornSetBonus").Value; ;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalvornBar>(), 25);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}