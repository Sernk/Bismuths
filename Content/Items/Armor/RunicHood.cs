using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class RunicHood : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("RunicSetBonus").Value;
        }
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;          
            Item.value = Item.sellPrice(0, 2, 75, 0);
            Item.rare = 6;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.manaCost -= 0.23f;
            player.manaRegen += 8;           
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<RunicRobe>();
        }
        public override void UpdateArmorSet(Player player)
        {
            bool magicflag = false;
            bool meleeflag = false;
            bool rangedflag = false;
            bool summonflag = false;
            bool thrownflag = false;
            bool doctorflag = false;
            bool speedflag = false;
            bool assasinflag = false;
        
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<MagicRune>())
                {
                    magicflag = true;
                    break;
                }
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<MeleeRune>())
                {
                    meleeflag = true;
                    break;
                }
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<RangerRune>())
                {
                    rangedflag = true;
                    break;
                }
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<RuneOfSummoner>())
                {
                    summonflag = true;
                    break;
                }
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<ThrownRune>())
                {
                    thrownflag = true;
                    break;
                }
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<RuneOfRegeneration>())
                {
                    doctorflag = true;
                    break;
                }
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<RuneOfSpeed>())
                {
                    speedflag = true;
                    break;
                }
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<RuneOfAssasin>())
                {
                    assasinflag = true;
                    break;
                }
            }
            if (magicflag)            
                player.GetDamage(DamageClass.Magic) += 0.24f;           
            if (meleeflag)
                player.GetDamage(DamageClass.Melee) += 0.24f;
            if (rangedflag)
                player.GetDamage(DamageClass.Ranged) += 0.24f;
            if (summonflag)
                player.GetDamage(DamageClass.Summon) += 0.24f;
            if (thrownflag)
                player.GetDamage(DamageClass.Throwing) += 0.24f;
            if (speedflag)
                player.moveSpeed += 0.3f;
            if (assasinflag)
            {
                player.GetCritChance(DamageClass.Melee) += 10;
                player.GetCritChance(DamageClass.Ranged) += 10;
                player.GetCritChance(DamageClass.Magic) += 10;
                player.GetCritChance(DamageClass.Throwing) += 10;
            }
            if (doctorflag)
                player.lifeRegen += 8;
            player.setBonus = this.GetLocalization("RunicSetBonus").Value; ;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(225, 35);
            recipe.AddIngredient(ModContent.ItemType<RuneEssence>(), 10);
            recipe.AddTile(86);
            recipe.Register();
        }
    }
}