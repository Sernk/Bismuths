using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class GreatPotionOfOblivion : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.rare = 1;
            Item.maxStack = 30;
            Item.useStyle = 2;
            Item.useTime = 15;
            Item.UseSound = SoundID.Item3;
            Item.useAnimation = 15;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<BismuthPlayer>().NoRPGGameplay || player.GetModPlayer<BismuthPlayer>().PlayerClass == 0)
                return false;
            return true;
        }
        public override bool? UseItem(Player player)
        {
            if (player.GetModPlayer<BismuthPlayer>().OpenedBook)
                player.GetModPlayer<BismuthPlayer>().OpenedBook = false;
            player.GetModPlayer<BismuthPlayer>().PlayerClass = 0;
            player.QuickSpawnItem(player.GetSource_FromThis(), ModContent.ItemType<ClassEngraving>());
            #region SPreset
            player.GetModPlayer<BismuthPlayer>().skill1lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill2lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill3lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill4lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill5lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill6lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill7lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill8lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill9lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill10lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill11lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill12lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill13lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill14lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill15lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill16lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill17lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill18lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill19lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill20lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill21lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill22lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill23lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill24lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill25lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill26lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill27lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill28lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill29lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill30lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill31lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill32lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill33lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill34lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill35lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill36lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill37lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill38lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill39lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill40lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill41lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill42lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill43lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill44lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill45lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill46lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill47lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill48lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill49lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill50lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill51lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill53lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill54lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill55lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill56lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill57lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill58lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill59lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill60lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill61lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill62lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill63lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill64lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill65lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill66lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill67lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill68lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill69lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill70lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill71lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill72lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill73lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill75lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill76lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill77lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill78lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill89lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill80lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill81lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill82lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill83lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill84lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill85lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill86lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill87lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill88lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill99lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill90lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill91lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill92lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill93lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill94lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill95lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill96lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill97lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill98lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill99lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill100lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill101lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill102lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill103lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill104lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill105lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill106lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill107lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill108lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill110lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill111lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill112lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill113lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill114lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill115lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill116lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill117lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill118lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill119lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill120lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill121lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill122lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill123lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill124lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill125lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill126lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill127lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill128lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill129lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill130lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill131lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill132lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill133lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill134lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill135lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill136lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill137lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill138lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill139lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill140lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill141lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill142lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill143lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill144lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill146lvl = 0;
            player.GetModPlayer<BismuthPlayer>().skill147lvl = 0;
            player.GetModPlayer<BismuthPlayer>().SkillPoints += player.GetModPlayer<BismuthPlayer>().SpendedPoints;
            player.GetModPlayer<BismuthPlayer>().SpendedPoints = 0;
            #endregion
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PotionOfOblivion>());
            recipe.AddIngredient(ModContent.ItemType<Panacea>(), 5);
            recipe.Register();
        }
    }
}