using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BismuthumHelmet : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("BismuthumHelmetSetBonus").Value;
        }
        public override void SetDefaults()
        {           
            Item.width = 18;          
            Item.height = 18;
            Item.value = Item.sellPrice(0, 7, 0, 0);
            Item.rare = 8;
            Item.defense = 20;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.3f;
            player.ThrownVelocity += 0.3f;
            player.GetDamage(DamageClass.Throwing) += 0.3f;
            player.GetCritChance(DamageClass.Throwing) += 18;
            player.GetCritChance(DamageClass.Melee) += 20;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BismuthumBreastplate>() && legs.type == ModContent.ItemType<BismuthumLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.AddBuff(ModContent.BuffType<BismuthumPoisoningPlayer>(), 200);
            player.setBonus = this.GetLocalization("BismuthumHelmetSetBonus").Value;
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BismuthumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}