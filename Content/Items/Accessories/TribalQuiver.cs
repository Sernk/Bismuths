using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class TribalQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Tribal Quiver");
            //Tooltip.SetDefault("+5% ranged damage, +10% ranged critical damage \n 15% chance to shoot one more arrow");
            //DisplayName.AddTranslation(GameCulture.Russian, "Племенной колчан");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон стрелка на 5%, а его шанс критического урона на 10%\n 15% шанс выпустить дополнительную стрелу");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetModPlayer<BismuthPlayer>().IsEquippedTribalQuiver = true;
        }
    }
}