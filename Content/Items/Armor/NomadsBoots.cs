using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class NomadsBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nomad's Boots");
            // Tooltip.SetDefault("Movement speed is increased by 25%. \nAssassin damage is increased by 9%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ботинки кочевника");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения на 25%. \nУвеличивает урон головореза на 9%.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 5;
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
            player.GetModPlayer<ModP>().assassinDamage += 0.09f;
        }
    }
}