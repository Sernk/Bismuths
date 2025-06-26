using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class ArchmagesAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Amulet of the Archmage");
            // Tooltip.SetDefault("Doesn't give any bonuses");
            //DisplayName.AddTranslation(GameCulture.Russian, "Амулет архимага");
            //Tooltip.AddTranslation(GameCulture.Russian, "Не даёт никаких бонусов");
        }
    
        public override void SetDefaults()
        {
            Item.value = 3000000;
            Item.rare = 10;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(this.Mod, "ItemName", Language.GetTextValue("Mods.Bismuth.DivineEquipment"))
            {
                OverrideColor = new Color?(new Color(0, 239, 239))
            });
          
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledBossesCount == 1)
                tooltips[2].Text = Language.GetTextValue("Mods.Bismuth.ArchmagesAmulet");
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledBossesCount == 2)
                tooltips[2].Text = Language.GetTextValue("Mods.Bismuth.ArchmagesAmulet1");
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledBossesCount == 3)
                tooltips[2].Text = Language.GetTextValue("Mods.Bismuth.ArchmagesAmulet2");
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledBossesCount == 4)
                tooltips[2].Text = Language.GetTextValue("Mods.Bismuth.ArchmagesAmulet3");
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledBossesCount == 5)
                tooltips[2].Text = Language.GetTextValue("Mods.Bismuth.ArchmagesAmulet4"); 
            if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledBossesCount == 6)
                tooltips[2].Text = Language.GetTextValue("Mods.Bismuth.ArchmagesAmulet5"); 
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedArchmagesAmulet = true;
            if (player.GetModPlayer<BismuthPlayer>().KilledBossesCount == 1)
            {
                player.statManaMax2 += 20;
                player.manaCost -= 0.03f;
            }
            if (player.GetModPlayer<BismuthPlayer>().KilledBossesCount == 2)
            {
                player.statManaMax2 += 30;
                player.manaCost -= 0.05f;
                player.GetCritChance(DamageClass.Magic) += 3;
            }
            if (player.GetModPlayer<BismuthPlayer>().KilledBossesCount == 3)
            {
                player.statManaMax2 += 50;
                player.manaCost -= 0.08f;
                player.GetCritChance(DamageClass.Magic) += 5;
                player.GetDamage(DamageClass.Magic) += 0.05f;
            }
            if (player.GetModPlayer<BismuthPlayer>().KilledBossesCount == 4)
            {
                player.statManaMax2 += 80;
                player.manaCost -= 0.14f;
                player.GetCritChance(DamageClass.Magic) += 9;
                player.GetDamage(DamageClass.Magic) += 0.12f;
              
            }
            if (player.GetModPlayer<BismuthPlayer>().KilledBossesCount == 5)
            {
                player.statManaMax2 += 120;
                player.manaCost -= 0.19f;
                player.GetCritChance(DamageClass.Magic) += 13;
                player.GetDamage(DamageClass.Magic) += 0.16f;
           
            }
            if (player.GetModPlayer<BismuthPlayer>().KilledBossesCount == 6)
            {
                player.statManaMax2 += 140;
                player.manaCost -= 0.25f;
                player.GetCritChance(DamageClass.Magic) += 15;
                player.GetDamage(DamageClass.Magic) += 0.2f;            
            }
        }
        //public override void AddRecipes()
        //{
        //    Recipe recipe = CreateRecipe();
        //    recipe.AddIngredient(Mod.Find<ModItem>("LightPartOfArchmagesAmulet").Type);
        //    recipe.AddIngredient(Mod.Find<ModItem>("DarkPartOfArchmagesAmulet").Type);
        //    recipe.Register();
        //}
    }
}