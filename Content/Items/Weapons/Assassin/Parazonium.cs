using Bismuth.Utilities;
using Terraria;
using Terraria.ID;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Parazonium : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 4;
            Item.width = 40;            
            Item.height = 40;         
            Item.useTime = 12;          
            Item.useAnimation = 12;         
            Item.useStyle = 1;          
            Item.knockBack = 1;         
            Item.value = Item.buyPrice(0, 0, 50, 0);      
            Item.rare = 0;             
            Item.UseSound = SoundID.Item1;      
            Item.autoReuse = true;
            Item.useTurn = true;
        }
    }
}