using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class MidasGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Midas' Glove");
            // Tooltip.SetDefault("6% increased damage, 30% more coins dropped from enemies");
            //DisplayName.AddTranslation(GameCulture.Russian, "Перчатка Мидаса");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает любой урон на 6%, вы получаете на 30% \nбольше денег при убийстве врагов");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.06f;
            player.GetDamage(DamageClass.Ranged) += 0.06f;
            player.GetDamage(DamageClass.Magic) += 0.06f;
            player.GetDamage(DamageClass.Summon) += 0.06f;
            player.GetDamage(DamageClass.Throwing) += 0.06f;
            player.GetModPlayer<ModP>().assassinDamage += 0.06f;
        }
    }
}