using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class TheRingOfTheBlood : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Ring Of The Blood");
            // Tooltip.SetDefault("Turns you into a vampire");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кольцо крови");
            //Tooltip.AddTranslation(GameCulture.Russian, "Превращает вас в вампира");
            if (Main.netMode != NetmodeID.Server)
            {
                SetupDrawing();
            }
        }
        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_Head_Male", EquipType.Head, name: "TheRingOfTheBlood_Head_Male");
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_Head_Female", EquipType.Head, name: "TheRingOfTheBlood_Head_Female");
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_Body", EquipType.Body, this);
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_Legs", EquipType.Legs, this);
            }
        }
        private void SetupDrawing()
        {
            int equipSlotHeadMale = EquipLoader.GetEquipSlot(Mod, "TheRingOfTheBlood_Head_Male", EquipType.Head);
            int equipSlotHeadFemale = EquipLoader.GetEquipSlot(Mod, "TheRingOfTheBlood_Head_Female", EquipType.Head);
            int equipSlotBody = EquipLoader.GetEquipSlot(Mod, "TheRingOfTheBlood", EquipType.Body);
            int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, "TheRingOfTheBlood", EquipType.Legs);
            if (equipSlotHeadMale >= 0)
            {
                ArmorIDs.Head.Sets.DrawHead[equipSlotHeadMale] = true;
            }
            if (equipSlotHeadFemale >= 0)
            {
                ArmorIDs.Head.Sets.DrawHead[equipSlotHeadFemale] = true;
            }
            if (equipSlotBody >= 0)
            {
                ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
                ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
            }
            if (equipSlotLegs >= 0)
            {
                ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
            }
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
            recipe.AddIngredient(ModContent.ItemType<RingRim>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Sanguinem>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}