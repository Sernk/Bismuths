using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class GlobalTownNPCs : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            var Quest = new Condition("Quest", () => Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 20);
            if (shop.NpcType == NPCID.Dryad)
            {
                shop.Add(ModContent.ItemType<OrnamentalPlant>());
            }
            if (shop.NpcType == NPCID.Merchant)
            {
                shop.Add(new Item(ModContent.ItemType<AdventurersBook>()) { value = 10000 });
                shop.Add(225);
                shop.Add(ModContent.ItemType<YeomansHat>());
                shop.Add(ModContent.ItemType<YeomansShirt>());
                shop.Add(ModContent.ItemType<YeomansLeggings>());
            }
            if (shop.NpcType == NPCID.GoblinTinkerer)
            {
                shop.Add(new Item(ModContent.ItemType<GlamdringBlueprint>()) { value = 50000, }, Quest);
            }
        }
    }
}