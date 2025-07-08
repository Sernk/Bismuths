using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class NecromancersRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Necromancer's Robe");
            //Tooltip.SetDefault("Minion damage is increased by 12%. \nIncreases your max number of minions");
            //DisplayName.AddTranslation(GameCulture.Russian, "Роба некроманта");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон прислужников на 12%. \nУвеличивает максимальное число прислужников.");
            ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 3;
            Item.defense = 3;
        }
        public override void Load()
        {
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
            player.GetDamage(DamageClass.Summon) += 0.12f;
            player.GetModPlayer<BismuthPlayer>().Charm -= 5;
        }
        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            equipSlot = EquipLoader.GetEquipSlot(Mod, "NecromancersRobe_Legs", EquipType.Legs);
        }
    }
}