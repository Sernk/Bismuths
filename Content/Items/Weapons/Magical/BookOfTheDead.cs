using Bismuth.Content.NPCs;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Magical
{
    public class BookOfTheDead : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.value = Item.buyPrice(0, 6, 0, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item69;
            Item.autoReuse = false;
            Item.useStyle = 5;
        }
        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<BismuthPlayer>().BOTDPlaces.Count > 0 && player.statMana >= 60;
        }
        public override bool? UseItem(Player player)
        {
            player.statMana -= 60;
            foreach (Vector2 pos in player.GetModPlayer<BismuthPlayer>().BOTDPlaces)
            {
                NPC.NewNPC(player.GetSource_FromThis(),(int)pos.X, (int)pos.Y, ModContent.NPCType<BoneHand>());
            }
            player.GetModPlayer<BismuthPlayer>().BOTDPlaces.Clear();
            return false;
        }
    }
}
