using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class Sanctus : ModItem
    {   
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sanctus");
            // Tooltip.SetDefault("The more damage you take - the higher your defence and damage reflection ");
            //DisplayName.AddTranslation(GameCulture.Russian, "Санктус");
            //Tooltip.AddTranslation(GameCulture.Russian, "Чем больше урона вы получили, тем больше ваша защита и поглощение урона");
        }       
        public override void SetDefaults()
        {           
            Item.value = Item.buyPrice(0, 6, 30, 0);
            Item.defense = 2;
            Item.rare = 3;           
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedSanctus = true;
            player.endurance += (player.GetModPlayer<BismuthPlayer>().sanctusdamagecounter / 1250) * 0.01f;
            player.statDefense += player.GetModPlayer<BismuthPlayer>().sanctusdamagecounter / 2000;
        }
    }
}