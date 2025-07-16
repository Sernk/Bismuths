using Bismuth.Utilities;
using Terraria;
using Terraria.ID;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class ManGosh : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 23;
            Item.crit = 10;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
    }
}