using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MythrilHeadgear : ModItem
    {

        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Mythril Headgear");
        //    Tooltip.SetDefault("Throwing damage and velocity are increased by 14%. \nThrowing critical strike chance is increased by 12%.");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Мифриловый головной убор");
        //    Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон и скорость полёта метательного оружия на 14%. \nУвеличивает шанс критического удара метательным оружием на 12%.");
        //}
        public override void Load()
        {
            _ = this.GetLocalization("MythrilHeadgearSetBonus").Value;
        }
        public override void SetDefaults()
        {   
            Item.width = 18;
            Item.height = 18;           
            Item.value = Item.sellPrice(0, 2, 25, 0);
            Item.rare = 4;
            Item.defense = 12;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.14f;
            player.ThrownVelocity += 0.14f;
            player.GetCritChance(DamageClass.Throwing) += 12;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilHalberd && legs.type == ItemID.MythrilGreaves;  //put your Breastplate name and Leggings name
        }
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownCost33 = true;
            player.setBonus = this.GetLocalization("MythrilHeadgearSetBonus").Value;
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MythrilBar, 10);   //you need 1 Wood
            recipe.AddTile(TileID.MythrilAnvil);   //at work bench
            recipe.Register();
        }
    }
}