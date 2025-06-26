using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class SkillCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Skill Cooldown");
            //Description.SetDefault("You can't use active skills");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кулдаун умения");
            //Description.AddTranslation(GameCulture.Russian, "Вы не можете использовать активные умения");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
        }
    }
}