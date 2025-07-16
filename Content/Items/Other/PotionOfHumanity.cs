using Bismuth.Content.Items.Accessories;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class PotionOfHumanity : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(1, 0, 0, 0);
            Item.rare = 1;
            Item.maxStack = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.UseSound = SoundID.Item3;
            Item.useAnimation = 15;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<TheRingOfTheSeas>() || player.armor[k].type == ModContent.ItemType<TheRingOfTheBlood>())
                {
                    return false;
                }
            }
            if(!(player.GetModPlayer<BismuthPlayer>().IsNaga || player.GetModPlayer<BismuthPlayer>().IsVampire))
                return false;
            return true;
        }
        public override bool? UseItem(Player player)
        {
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsNaga || Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsNaga = false;
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsVampire = false;
            }
            return true;
        }
    }
}