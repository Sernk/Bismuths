using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class EmpathyMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Empathy Mirror");
            //DisplayName.AddTranslation(GameCulture.Russian, "Зеркало эмпатии");
            // Tooltip.SetDefault("Press left mouse button to add NPC in empathy net and right to remove\nAll received damage distributes between all net members\nIf one of the party members dies, net will be destroyed, as every member... ");
            //Tooltip.AddTranslation(GameCulture.Russian, "Нажмите левую кнопку мыши, чтобы добавить НИПа в сеть эмпатии, и правую, чтобы удалить его.\n Весь полученный урон распределяется между участниками сети\n В случае гибели одного из участников сеть разорвется...");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = 4;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;

        }
    }
}
