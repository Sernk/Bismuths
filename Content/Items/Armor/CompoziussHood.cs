using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CompoziussHood : ModItem
    {

        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Compozius' Hood");
        //    Tooltip.SetDefault("Great for impersonating devs!");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Капюшон Compozius");
        //    Tooltip.AddTranslation(GameCulture.Russian, "Поможет вам выдать себя за разработчика!");
        //}
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 9;
            Item.vanity = true;
        }
    }
}