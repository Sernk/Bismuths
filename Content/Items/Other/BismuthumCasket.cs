using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class BismuthumCasket : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bismuthum Casket");
            // Tooltip.SetDefault("There are dev items inside");
            //DisplayName.AddTranslation(GameCulture.Russian, "Висмутовая шкатулка");
            //Tooltip.AddTranslation(GameCulture.Russian, "Содержит предметы разработчиков");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 30;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        /*public override void RightClick(Player player)
        {
            var source = player.GetSource_OpenItem(Item.type);
            switch (Main.rand.Next(0, 9))
            {
                case 0:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<BripesBoots>());
                        player.QuickSpawnItem(source, ModContent.ItemType<BripesChestplate>());
                        player.QuickSpawnItem(source, ModContent.ItemType<BripesHeadgear>());
                        break;
                    }
                case 1:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<CompoziussHood>());
                        player.QuickSpawnItem(source, ModContent.ItemType<CompoziussRobe>());
                        break;
                    }
                case 2:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<EfromomrsLeggings>());
                        player.QuickSpawnItem(source, ModContent.ItemType<EfromomrsBreastplate>());
                        player.QuickSpawnItem(source, ModContent.ItemType<EfromomrsHood>());
                        break;
                    }
                case 3:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<KazzinaksLeggings>());
                        player.QuickSpawnItem(source, ModContent.ItemType<KazzinaksBreastplate>());
                        player.QuickSpawnItem(source, ModContent.ItemType<KazzinaksHelmet>());
                        break;
                    }
                case 4:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<MeuRansGreaves>());
                        player.QuickSpawnItem(source, ModContent.ItemType<MeuRansBreastplate>());
                        player.QuickSpawnItem(source, ModContent.ItemType<MeuRansHood>());
                        break;
                    }
                case 5:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<MrPigeonsBoots>());
                        player.QuickSpawnItem(source, ModContent.ItemType<MrPigeonsJacket>());
                        player.QuickSpawnItem(source, ModContent.ItemType<MrPigeonsMask>());
                        break;
                    }
                case 6:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<NokilosBoots>());
                        player.QuickSpawnItem(source, ModContent.ItemType<NokilosSuit>());
                        player.QuickSpawnItem(source, ModContent.ItemType<NokilosMask>());
                        break;
                    }
                case 7:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<RekstrisBoots>());
                        player.QuickSpawnItem(source, ModContent.ItemType<RekstrisBreastplate>());
                        player.QuickSpawnItem(source, ModContent.ItemType<RekstrisHelmet>());
                        break;
                    }
                default:
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<VolvoxsBoots>());
                        player.QuickSpawnItem(source, ModContent.ItemType<VolvoxsBreastplate>());
                        player.QuickSpawnItem(source, ModContent.ItemType<VolvoxsHelmet>());
                        break;
                    }            
            }
        }*/
    }
}
