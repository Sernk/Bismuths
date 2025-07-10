using Bismuth.Content.NPCs;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class SoulEater : AssassinItem
    {
        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.knockBack = 5;
            Item.rare = 0;
            Item.sellPrice(0, 5, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Soul Eater");
            //DisplayName.AddTranslation(GameCulture.Russian, "Душегуб");
            //Tooltip.SetDefault("Restless souls appear near you after dealing damage. They increase your \ndamage, but decrease your health");

            //Tooltip.AddTranslation(GameCulture.Russian, "При атаке врага рядом с игроком появляются неупокоенные \nдуши, увеличивающие урон, но медленно понижающие здоровье");
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.life <= 0)
            {
                player.GetModPlayer<BismuthPlayer>().SoulEaterCounter = 600;
                if (NPC.CountNPCS(ModContent.NPCType<RestlessSoul>()) < 3)
                {
                    NPC.NewNPC(player.GetSource_FromThis(), (int)player.position.X, (int)player.position.Y, ModContent.NPCType<RestlessSoul>(), 0, NPC.CountNPCS(ModContent.NPCType<RestlessSoul>()));
                }
            }
        }
    }
}
