using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class OrcishShield : ModItem
    {   
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Orcish Shield");
        //    Tooltip.SetDefault("Increased thrown damage by 11%\nThe less health you have - the higher your thrown damage and crit");
        //    DisplayName.AddTranslation(GameCulture.Russian, "Орочий щит");
        //    Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает метательный урон на 11%\nЧем меньше у вас здоровья - тем больше ваш метательный \nурон и шанс критического урона");
        //}       
        public override void SetDefaults()
        {         
            Item.value = 3000000;
            Item.defense = 3;
            Item.rare = 4;         
            Item.accessory = true;            
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Throwing) += (player.statLifeMax - player.statLife) / 7;
            player.GetDamage(DamageClass.Throwing) += 0.11f;
            if (player.statLife < 300)
                player.GetDamage(DamageClass.Throwing) += 0.07f;
            if (player.statLife < 200)
                player.GetDamage(DamageClass.Throwing) += 0.11f;
            if (player.statLife < 100)
                player.GetDamage(DamageClass.Throwing) += 0.18f;
            if (player.statLife < 50)
                player.GetDamage(DamageClass.Throwing) += 0.22f;
        }
    }
}