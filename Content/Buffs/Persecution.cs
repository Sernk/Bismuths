using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Persecution : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Prosecution");
            // Description.SetDefault("After dealing damage, your speed increases");
            //DisplayName.AddTranslation(GameCulture.Russian, "Преследование");
            //Description.AddTranslation(GameCulture.Russian, "После нанесения урона ваша скорость увеличена");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.4f;
        }
    }
}