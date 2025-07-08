using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Items.Tools
{
    public class MinotaursWaraxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 12;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.axe = 17;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = false;
            
        }     
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Minotaur's Waraxe");
            //DisplayName.AddTranslation(GameCulture.Russian, "Боевой топор минотавра");
        }      
    }
}
