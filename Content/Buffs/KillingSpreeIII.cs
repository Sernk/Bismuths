using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class KillingSpreeIII : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Killing Spree III");
            // Description.SetDefault("You want to kill again and again");
            //DisplayName.AddTranslation(GameCulture.Russian, "Череда убийств III");
            //Description.AddTranslation(GameCulture.Russian, "Вы хотите убивать снова и снова");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Ranged) += 0.3f;
        }
    }
}