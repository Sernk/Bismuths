using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class PaladinsShell : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paladin's Shell");
            // Tooltip.SetDefault("Melee damage is increased by 12%, damage resistance is increased by 8%. \nMovement speed is decreased by 10%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Панцирь паладина");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон в ближнем бою на 12%, увеличивает сопротивляемость урона на 8%. \nСнижает суорость передвижения на 10%.");
        }    
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 3;
            Item.defense = 7;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.1f;
            player.GetDamage(DamageClass.Melee) += 0.12f;
            player.endurance += 0.08f;
        }
    }
}
