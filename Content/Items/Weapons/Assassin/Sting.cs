using Bismuth.Content.NPCs;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Assassin
{
    public class Sting : AssassinItem
    {
        public override void SetDefaults()
        {

            Item.damage = 28;
            Item.noMelee = true; 
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.knockBack = 3;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (target.type == ModContent.NPCType<Orc>() || target.type == ModContent.NPCType<OrcCrossbower>() || target.type == ModContent.NPCType<OrcDefender>() || target.type == ModContent.NPCType<OrcWizard>() || /*target.type == ModContent.NPCType<OrcRider>() ||*/ target.type == ModContent.NPCType<RhinoOrc>())
                modifiers.SourceDamage *= 2;
        }
    }
}