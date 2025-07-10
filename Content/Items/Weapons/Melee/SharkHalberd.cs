using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class SharkHalberd : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 53;         
            Item.DamageType = DamageClass.Melee;            
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;      
            Item.useAnimation = 20; 
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 1, 50, 0);
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;       
            Item.useStyle = 1;
            Item.useTurn = true;
        }
    }
}