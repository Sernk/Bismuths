using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    /// <summary>
    /// Код взят https://github.com/GinYuH/CalValEX/blob/master/Items/Equips/Transformations/BurningEye.cs
    /// </summary>
    public class TheRingOfTheSeas : ModItem
    {
        public override void SetStaticDefaults()
        {
            BismuthPlayer modPlayer = ModContent.GetInstance<BismuthPlayer>();
            if (Main.netMode != NetmodeID.Server)
            {
                SetupDrawing();
            }
        }
        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, this);
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, this);
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
            }
        }
        private void SetupDrawing()
        {
            BismuthPlayer modPlayer = ModContent.GetInstance<BismuthPlayer>();
            int equipSlotHead = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head);
            int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
            int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
            ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = true;
            ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
            ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
            ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 10;
            Item.accessory = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RingRim>());
            recipe.AddIngredient(ModContent.ItemType<Elessar>());
            recipe.AddTile(16);
            recipe.Register();
        }
        public override bool IsVanitySet(int head, int body, int legs) => true;
    }
}