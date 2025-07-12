using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MythrilHeadpiece : ModItem
    {

        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Mythril Headpiece");
        //    Tooltip.SetDefault("Minion damage is increased by 16%. \nIncreases your max number of minions.");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Мифриловая каска");
        //    Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон прислужников на 16%. \nУвеличивает максимальное число прислужников.");
        //}
        public override void Load()
        {
            _ = this.GetLocalization("MythrilHeadpieceSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;          
            Item.value = Item.sellPrice(0, 2, 25, 0);
            Item.rare = 4;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
            player.GetDamage(DamageClass.Summon) += 0.16f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilHalberd && legs.type == ItemID.MythrilGreaves;  //put your Breastplate name and Leggings name

        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.09f;
            player.maxMinions++;
            player.setBonus = this.GetLocalization("MythrilHeadpieceSetBonus").Value;
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MythrilBar, 10);   //you need 1 Wood
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.Register();
        }
    }
}