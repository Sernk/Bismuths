using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    //ПОФИКСИТЬ ВОЛОСЫ
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class MarbleMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Marble Mask");
            // Tooltip.SetDefault("Increases assassin damage by 10% and critical strike chance by 8%\nOnce a day you get absolutely invelnerability for 12 seconds\n if you have less than 20% of your maximum health");
            //DisplayName.AddTranslation(GameCulture.Russian, "Мраморная маска");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон головореза на 10%, а также шанс критического \nурона на 8%. Раз в день вы становитесь неуязвимым на 12 секунд, \nесли ваше здоровье составляет менее 20% от максимального");
        }
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.1f;
            player.GetCritChance(DamageClass.Melee) += 8;
            player.GetCritChance(DamageClass.Ranged) += 8;
            player.GetCritChance(DamageClass.Magic) += 8;
            player.GetCritChance(DamageClass.Throwing) += 8;
            player.GetModPlayer<ModP>().assassinCrit += 8;
            player.GetModPlayer<BismuthPlayer>().IsEquippedMarbleMask = true;
        }

    }
}