using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class Glamdring : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 18;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 1, 70, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (target.type == NPCID.GoblinArcher || target.type == NPCID.GoblinPeon || target.type == NPCID.GoblinScout || target.type == NPCID.GoblinSorcerer || target.type == NPCID.GoblinSummoner || target.type == NPCID.GoblinThief || target.type == NPCID.GoblinWarrior)
                modifiers.SourceDamage *= 5;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Glamdring");
            //DisplayName.AddTranslation(GameCulture.Russian, "Гламдринг");
            //Tooltip.SetDefault("Deals multiplied damage to goblins");
            //Tooltip.AddTranslation(GameCulture.Russian, "Наносит многократный урон гоблинам");
        }
    }
}
