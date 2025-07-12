using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class CompoziussRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            //    DisplayName.SetDefault("Compozius' Robe");
            //    Tooltip.SetDefault("Great for impersonating devs!");
            //    DisplayName.AddTranslation(GameCulture.Russian, "Роба Compozius");
            //    Tooltip.AddTranslation(GameCulture.Russian, "Поможет вам выдать себя за разработчика!");
            ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 9;
            Item.vanity = true;
        }
        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            equipSlot = EquipLoader.GetEquipSlot(Mod, "CompoziussRobe_Legs", EquipType.Legs);
        }
    }
}