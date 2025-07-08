using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    public class AriadnesTangle : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ariadne's Tangle");
            //Tooltip.SetDefault("7% increased assassin damage \n7% increased critical strike chance.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Клубок ариадны");
            //Tooltip.AddTranslation(GameCulture.Russian, "Урон головореза увеличен на 7%\n Шанс критического урона увеличен на 7%");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.07f;
            player.GetCritChance(DamageClass.Melee) += 7;
            player.GetCritChance(DamageClass.Ranged) += 7;
            player.GetCritChance(DamageClass.Magic) += 7;
            player.GetCritChance(DamageClass.Throwing) += 7;
            player.GetModPlayer<ModP>().assassinCrit += 7;
        }
    }
}