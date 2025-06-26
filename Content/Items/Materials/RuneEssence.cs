using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class RuneEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Runic Essence");
            //DisplayName.AddTranslation(GameCulture.Russian, "Руническая эссенция");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;

        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = 6;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            Lighting.AddLight((int)(((double)this.Item.position.X + (double)(this.Item.width / 2)) / 16.0), (int)(((double)this.Item.position.Y + (double)(this.Item.height / 2)) / 16.0), 0.6f, 0.78f, 0.75f);
        }
    }
}