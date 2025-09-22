using Humanizer;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using static tModPorter.ProgressUpdate;

namespace Bismuth.Utilities.ModSupport
{
    public enum QuestPhase
    {
        PreSkeletron,
        PostOriginalAlchemist,
        PostOriginalBabaYaga,
        PostOriginalDwarfBlacksmith
    }
    public enum PostBossQuest
    {
        Null,               // Nothing
        PostEoC,            // Eye of Cthulhu
        PostBoss2,          // Brain of Cthulhu && Brain
        PostSkeletron,      // Skeletron
        PostQueenBee,       // Queen Bee
        PostDeerclops,      // Deerclops
        PostWoF,            // Wall of Flesh
        PostQueenSlime,     // Queen Slime
        PostMechBosses,     // All three mech bosses
        PostTwins,          // The Twins
        PostDestroyer,      // The Destroyer
        PostSkeletronPrime, // Skeletron Prime
        PostPlantera,       // Plantera
        PostGolem,          // Golem
        PostDukeFishron,    // Duke Fishron
        PostEmpress,        // Empress of Light
        PostCultist,        // Lunatic Cultist
        PostMoonLord        // Moon Lord
    }
    public interface IQuest
    {
        string UniqueKey { get; }
        string NpcKey { get; }
        string DisplayName { get; }
        string DisplayDescription { get; }
        string DisplayStage { get; }
        int Progress { get; set; }
        int Priority { get; }
        int CornerItem { get; }
        bool ISManyEndings { get; }
        QuestPhase Phase { get; }
        bool HasDefeated(PostBossQuest postBossQuest);
        string GetChat(NPC npc, Player player, int Itemcorneritem);
        string GetButtonText(Player player);
        void OnChatButtonClicked(Player player);
        void IsActiveQuestUIIcon(bool isAvailableQuest, bool isActiveQuest, SpriteBatch spriteBatch, NPC npc, Player player);
        void Notification(Player player, bool ISCompletedSuccessfully, bool ISQUESTACCEPTED);
        int CompletedQuickSpawnItem(Player player, int IteID, int quantity = 1);
        void CheckItem(Player player, int item_id, int need_an_item = 1, int how_many_items_to_spend = 1, string text = "", string textf = "",  int reward = 0, int stack = 0, bool IsNotification = true, bool IsQuestcompleted = true, int progres = 0);
        bool IsAvailable(Player player);
        bool IsActive(Player player);
        bool IsCompleted(Player player) => false;
    }
}
