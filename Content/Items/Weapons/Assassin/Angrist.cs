using Terraria;
using Terraria.ID;
using Bismuth.Utilities;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Angrist : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.knockBack = 2;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Angrist");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ангрист");
        }
    }
}
