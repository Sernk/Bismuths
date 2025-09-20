using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities.ModSupport
{
    public abstract class BaseQuest : IQuest
    {
        public static string QUESTCOMPLETED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTCOMPLETED");
        public static string QUESTFAILED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTFAILED");
        public static string QUESTACCEPTED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTACCEPTED");

        public const string BabaYaga = "BabaYaga";
        public const string Alchemist = "Alchemist";
        public const string Beggar = "Beggar";
        public const string DwarfBlacksmith = "DwarfBlacksmith";
        public const string ImperianCommander = "ImperianCommander";
        public const string ImperialConsul = "ImperialConsul";
        public const string OldmanPriest = "OldmanPriest";

        public static Color ColorCompleted = Color.LemonChiffon;
        public static Color ColorFailed = Color.LightGray;
        public static Color ColorAccepted = Color.LightGreen;

        public virtual string DisplayStage => "";
        public abstract string UniqueKey { get; }
        public virtual string NpcKey => "";
        public virtual string DisplayName => "";
        public virtual string DisplayDescription => "";
        public virtual string GetButtonText(Player player) => "";
        public virtual int CornerItem => 0;
        public virtual string GetChat(NPC npc, Player player, int corneritem) { _ = CornerItem; Main.npcChatCornerItem = CornerItem; return ""; }
        public virtual bool ISManyEndings => false;
        public virtual bool IsAvailable(Player player) => false;
        public virtual bool IsActive(Player player) => false;
        public virtual void IsActiveQuestUIIcon(bool isAvailableQuest, bool isActiveQuest, SpriteBatch spriteBatch, NPC npc, Player player)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;

            if (isActiveQuest)
            {
                spriteBatch.Draw(active, npc.position - Main.screenPosition + new Vector2(8, -34), Color.White);
            }
            else if (isAvailableQuest)
            {
                spriteBatch.Draw(available, npc.position - Main.screenPosition + new Vector2(8, -34), Color.White);
            }
        }
        public virtual int Priority => 1;

        public virtual QuestPhase Phase => QuestPhase.PreSkeletron;

        public virtual void OnChatButtonClicked(Player player) { }
        public void Notification(Player player, bool ISCompletedSuccessfully, bool ISQUESTACCEPTED)
        {
            if (ISCompletedSuccessfully)
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 35, 10, 10), ColorCompleted, QUESTCOMPLETED);
            else if (!ISCompletedSuccessfully && !ISQUESTACCEPTED)
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 35, 10, 10), ColorFailed, QUESTFAILED);
            if (ISQUESTACCEPTED)
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 35, 10, 10), ColorAccepted, QUESTACCEPTED);
        }
    }
}