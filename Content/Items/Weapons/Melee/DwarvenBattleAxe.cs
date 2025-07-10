using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class DwarvenBattleAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 42;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = 6;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
        }
    }
}