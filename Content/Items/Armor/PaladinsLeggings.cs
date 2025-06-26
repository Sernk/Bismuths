using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class PaladinsLeggings : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paladin's Leggings");
            // Tooltip.SetDefault("Melee damage is increased by 8%, damage resistance is increased by 5%. \nMovement speed is decreased by 5%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Поножи паладина");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон в ближнем бою на 8%, увеличивает сопротивлению урону на 5%. \nСнижает скорость передвижения на 5%.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 25, 0);
            Item.rare = 3;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.08f;
            player.endurance += 0.05f;
        }
    }
}