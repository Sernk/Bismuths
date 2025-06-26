using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class MiningII : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mining II");
            // Description.SetDefault("Your mining speed significanlty increased");
            //DisplayName.AddTranslation(GameCulture.Russian, "Добыча II");
            //Description.AddTranslation(GameCulture.Russian, "Ваша скорость копания серьезно увеличена");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.pickSpeed -= 0.5f;
        }
    }
}