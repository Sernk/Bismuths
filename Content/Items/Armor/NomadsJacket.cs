using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class NomadsJacket : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nomad's Jacket");
            // Tooltip.SetDefault("Assassin damage is increased by 11%, critical strike damage is increased by 30%");
            //DisplayName.AddTranslation(GameCulture.Russian, "Куртка кочевника");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон головореза на 11%, увеличивает критический урон на 30%.");
        }
        public override void SetDefaults()
        {

            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.rare = 4;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.11f;
            player.GetModPlayer<BismuthPlayer>().critDmgMult += 0.3f;
        }
    }
}
