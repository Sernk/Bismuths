using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Tools
{
    public class JaguarsPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 21;
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 26;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.pick = 150;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 4, 50, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
    }
}