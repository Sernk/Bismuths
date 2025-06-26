using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace Bismuth.Content.Items.Materials
{
    public class FireEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fire Essence");
           // DisplayName.AddTranslation(GameCulture.Russian, "Эссенция огня");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;

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
            Lighting.AddLight((int)(((double)this.Item.position.X + (double)(this.Item.width / 2)) / 16.0), (int)(((double)this.Item.position.Y + (double)(this.Item.height / 2)) / 16.0), 0.8f, 0.3f, 0.3f);
        }
    }
}
