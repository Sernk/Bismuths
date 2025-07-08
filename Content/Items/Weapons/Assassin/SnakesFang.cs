using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Bismuth.Utilities;
using Bismuth.Content.NPCs;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class SnakesFang : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 23;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.knockBack = 4;
            Item.rare = 0;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int summoncount = 0;
            Vector2 FirstSummon;
        Search1:
            if (summoncount > 1000)
            {
                return;
            }
            FirstSummon = UtilsAI.RandomPointInArea(new Rectangle((int)player.Center.X - 300, (int)player.Center.Y - 300, 600, 600));
            if (!UtilsAI.CheckEmptyPlace(FirstSummon))
            {
                summoncount++;
                goto Search1;

            }
            while (!WorldGen.SolidTile(FirstSummon.ToTileCoordinates().X, FirstSummon.ToTileCoordinates().Y + 1))
            {

                FirstSummon.Y++;
                if (FirstSummon.Y > player.Center.Y + 300)
                {
                    summoncount++;
                    goto Search1;

                }
            }
            if (!UtilsAI.CheckEmptyPlace(FirstSummon))
            {
                summoncount++;
                goto Search1;

            }
            if(!NPC.AnyNPCs(ModContent.NPCType<Snake>()))
                NPC.NewNPC(Item.GetSource_FromThis(), (int)FirstSummon.X, (int)FirstSummon.Y, ModContent.NPCType<Snake>());
        }
    }
}
