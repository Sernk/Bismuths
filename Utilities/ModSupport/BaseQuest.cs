using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Bismuth.Utilities.ModSupport
{
    public abstract class BaseQuest : IQuest
    {
        public static string QUESTCOMPLETED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTCOMPLETED");
        public static string QUESTFAILED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTFAILED");
        public static string QUESTACCEPTED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTACCEPTED");
        public abstract string UniqueKey { get; }
        public virtual string NpcKey => "";
        public virtual int Priority => 1;
        public virtual string DisplayName => "";
        public virtual string DisplayDescription => "";
        public virtual string GetChat(NPC npc, Player player) => "";
        public virtual string GetButtonText(Player player) => "";
        public virtual void OnChatButtonClicked(Player player) { }
        public virtual bool IsAvailable(Player player) => false;
        public virtual bool IsActive(Player player) => false;
        public void Notification(Player player, bool ISCompletedSuccessfully, bool ISQUESTACCEPTED)
        {
            if (ISCompletedSuccessfully)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 35, 10, 10), Color.LemonChiffon, QUESTCOMPLETED);
            }
            else
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 35, 10, 10), Color.LightGray, QUESTFAILED);
            }
            if (ISQUESTACCEPTED)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 35, 10, 10), Color.LightGreen, QUESTACCEPTED);
            }
        }
    }
}