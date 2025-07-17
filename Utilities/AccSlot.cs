using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class AccSlot : ModAccessorySlot
    {
        public override string Name => "SkillSlot";

        public override bool IsEnabled()
        {
            if (Player.GetModPlayer<BismuthPlayer>().extraSlotUnlocked == true)
            {
                return true;
            }
            return false;
        }
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return checkItem.accessory;
        }

        public override bool DrawDyeSlot => true;

        public override bool DrawFunctionalSlot => true;

        public override bool IsVisibleWhenNotEnabled() => false;
    }
}