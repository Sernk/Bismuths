using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities.ModSupport
{
    public abstract class BaseQuest : IQuest
    {
        private readonly static string QUESTCOMPLETED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTCOMPLETED");
        private readonly static string QUESTFAILED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTFAILED");
        private readonly static string QUESTACCEPTED = Language.GetTextValue("Mods.Bismuth.QUEST.QUESTACCEPTED");

        public const string BabaYaga = "BabaYaga";
        public const string Alchemist = "Alchemist";
        public const string Beggar = "Beggar";
        public const string DwarfBlacksmith = "DwarfBlacksmith";
        public const string ImperianCommander = "ImperianCommander";
        public const string ImperialConsul = "ImperialConsul";
        public const string OldmanPriest = "OldmanPriest";

        public Color ColorCompleted = Color.LemonChiffon;
        public Color ColorFailed = Color.LightGray;
        public Color ColorAccepted = Color.LightGreen;

        public float IsActiveQuestUIIconPositionX = 8f;
        public float IsActiveQuestUIIconPositionY = -34f;

        public virtual string DisplayStage => "";
        public abstract string UniqueKey { get; }
        public virtual string NpcKey => "";
        public virtual string DisplayName => "";
        public virtual string DisplayDescription => "";
        public virtual string GetButtonText(Player player) => "";
        public virtual string GetChat(NPC npc, Player player, int corneritem) { _ = CornerItem; Main.npcChatCornerItem = CornerItem; return ""; }
        public virtual bool IsAvailable(Player player) => HasDefeated(PostBossRequirement);
        public virtual bool IsActive(Player player) => false;
        public virtual bool IsCompleted(Player player) => false;
        public virtual bool ISManyEndings => false;
        public int Progress { get; set; } = 0;
        public virtual int CornerItem => 0;
        public virtual int Priority => 1;
        public virtual void IsActiveQuestUIIcon(bool isAvailableQuest, bool isActiveQuest, SpriteBatch spriteBatch, NPC npc, Player player)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;

            if (isActiveQuest) spriteBatch.Draw(active, npc.position - Main.screenPosition + new Vector2(IsActiveQuestUIIconPositionX, IsActiveQuestUIIconPositionY), Color.White);
            else if (isAvailableQuest) spriteBatch.Draw(available, npc.position - Main.screenPosition + new Vector2(IsActiveQuestUIIconPositionX, IsActiveQuestUIIconPositionY), Color.White);
        }
        public virtual void OnChatButtonClicked(Player player) { }
        public virtual void CheckItem(Player player, int item_id, int need_an_item = 1, int how_many_items_to_spend = 1, string text = "", string textF = "", int itemID = 0, int stack = 0, bool IsNotification = true, bool IsQuestcompleted = true, int progres = 0)
        {
            var q = player.GetModPlayer<QuestPlayer>();

            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == item_id && player.inventory[i].stack >= need_an_item)
                {
                    player.inventory[i].stack -= how_many_items_to_spend;
                    if(IsQuestcompleted) q.CompletedQuests.Add(UniqueKey);
                    Main.npcChatText = text;
                    if(IsNotification) Notification(player, true, false);
                    Progress = progres;
                    CompletedQuickSpawnItem(player, itemID, stack);
                    return;
                }
                else
                {
                    Main.npcChatText = textF;
                }
            }
        }
        public void Notification(Player player, bool ISCompletedSuccessfully, bool ISQUESTACCEPTED)
        {
            Rectangle rect = new((int)player.position.X, (int)player.position.Y - 35, 10, 10);
            if (ISCompletedSuccessfully) CombatText.NewText(rect, ColorCompleted, QUESTCOMPLETED);
            else if (!ISCompletedSuccessfully && !ISQUESTACCEPTED)CombatText.NewText(rect, ColorFailed, QUESTFAILED);
            if (ISQUESTACCEPTED) CombatText.NewText(rect, ColorAccepted, QUESTACCEPTED);
        }
        public virtual QuestPhase Phase => QuestPhase.PreSkeletron;
        public virtual PostBossQuest PostBossRequirement => PostBossQuest.Null;
        public bool HasDefeated(PostBossQuest quest)
        {
            return quest switch
            {
                PostBossQuest.Null => true, // всегда доступен
                PostBossQuest.PostEoC => NPC.downedBoss1,
                PostBossQuest.PostBoss2 => NPC.downedBoss2,
                PostBossQuest.PostQueenBee => NPC.downedQueenBee,
                PostBossQuest.PostSkeletron => NPC.downedBoss3,
                PostBossQuest.PostDeerclops => NPC.downedDeerclops,
                PostBossQuest.PostWoF => Main.hardMode,
                PostBossQuest.PostQueenSlime => NPC.downedQueenSlime,
                PostBossQuest.PostDestroyer => NPC.downedMechBoss1,
                PostBossQuest.PostTwins => NPC.downedMechBoss2,
                PostBossQuest.PostSkeletronPrime => NPC.downedMechBoss3,
                PostBossQuest.PostPlantera => NPC.downedPlantBoss,
                PostBossQuest.PostDukeFishron => NPC.downedFishron,
                PostBossQuest.PostEmpress => NPC.downedEmpressOfLight,
                PostBossQuest.PostGolem => NPC.downedGolemBoss,
                PostBossQuest.PostCultist => NPC.downedAncientCultist,
                PostBossQuest.PostMoonLord => NPC.downedMoonlord,
                _ => false
            };
        }
        public int CompletedQuickSpawnItem(Player player, int Id, int quantity)
        {
            return player.QuickSpawnItem(player.GetSource_FromThis(), Id, quantity);
        }
    }
}
