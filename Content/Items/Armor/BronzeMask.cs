using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BronzeMask : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("BronzeSetBonus").Value;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.rare = 0;
            Item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.ThrownVelocity += 0.12f;
            player.GetCritChance(DamageClass.Throwing) += 4;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BronzeBreastplate>() && legs.type == ModContent.ItemType<BronzeLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownVelocity += 0.07f;
            player.statDefense += 1;
            player.setBonus = this.GetLocalization("BronzeSetBonus").Value;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}