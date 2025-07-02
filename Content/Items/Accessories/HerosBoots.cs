using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class HerosBoots : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = 3000000;
            Item.defense = 1;
            Item.rare = 10;
            Item.accessory = true;
        }
        public override void Load()
        {
            _ = this.GetLocalization("Quests.DivineEquipment").Value;
            _ = this.GetLocalization("Quests.HerosBoots").Value;
            _ = this.GetLocalization("Quests.HerosBoots1").Value;
            _ = this.GetLocalization("Quests.HerosBoots2").Value;
            _ = this.GetLocalization("Quests.HerosBoots3").Value;
            _ = this.GetLocalization("Quests.HerosBoots4").Value;
            _ = this.GetLocalization("Quests.HerosBoots5").Value;
            _ = this.GetLocalization("Quests.HerosBoots6").Value;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string DivineEquipment = this.GetLocalization("Quests.DivineEquipment").Value;
            string HerosBoots = this.GetLocalization("Quests.HerosBoots").Value;
            string HerosBoots1 = this.GetLocalization("Quests.HerosBoots1").Value;
            string HerosBoots2 = this.GetLocalization("Quests.HerosBoots2").Value;
            string HerosBoots3 = this.GetLocalization("Quests.HerosBoots3").Value;
            string HerosBoots4 = this.GetLocalization("Quests.HerosBoots4").Value;
            string HerosBoots5 = this.GetLocalization("Quests.HerosBoots5").Value;
            string HerosBoots6 = this.GetLocalization("Quests.HerosBoots6").Value;

            int progress = 0;

            if (NPC.downedBoss1) { progress++; }
            if (NPC.downedBoss2) { progress++; }
            if (NPC.downedBoss3) { progress++; }
            if (Main.hardMode) { progress++; }
            if (NPC.downedMechBossAny) { progress++; }
            if (NPC.downedPlantBoss) { progress++; }
            if (NPC.downedGolemBoss) { progress++; }
            tooltips.Add(new TooltipLine(this.Mod, "ItemName", DivineEquipment) { OverrideColor = new Color?(new Color(0, 239, 239)) });
            if (progress == 1) { tooltips[3].Text = HerosBoots;  }
            if (progress == 2) { tooltips[3].Text = HerosBoots1; }
            if (progress == 3) { tooltips[3].Text = HerosBoots2; }
            if (progress == 4) { tooltips[3].Text = HerosBoots3; }
            if (progress == 5) { tooltips[3].Text = HerosBoots4; }
            if (progress == 6) { tooltips[3].Text = HerosBoots5; }
            if (progress == 7) { tooltips[3].Text = HerosBoots6; }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Player.jumpSpeed += 0.15f;

            int progress = 0;

            if (NPC.downedBoss1) { progress++; }
            if (NPC.downedBoss2) { progress++; }
            if (NPC.downedBoss3) { progress++; }
            if (Main.hardMode) { progress++; }
            if (NPC.downedMechBossAny) { progress++; }
            if (NPC.downedPlantBoss) { progress++; }
            if (NPC.downedGolemBoss) { progress++; }

            if (progress == 1)
            {
                player.accRunSpeed = 6f;
            }
            if (progress == 2)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.1f;
                player.waterWalk = true;
                Player.jumpSpeed += 0.06f;
            }
            if (progress == 3)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.15f;
                player.waterWalk = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.08f;
            }
            if (progress == 4)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.20f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.1f;
                player.GetJumpState<HeroBootsJump>().Enable();
            }
            if (progress >= 4)
            {
                if (player.velocity != Vector2.Zero)
                {
                    player.lifeRegen += 10;
                }
            }
            if (progress == 5)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.3f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.14f;
                player.GetJumpState<HeroBootsJump>().Enable();
            }
            if (progress == 6)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.45f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.2f;
                player.GetJumpState<HeroBootsJump>().Enable();
                player.GetJumpState<HeroBootsJump2>().Enable();
            }
            if (progress == 7)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.6f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.25f;
                player.GetJumpState<HeroBootsJump>().Enable();
                player.GetJumpState<HeroBootsJump2>().Enable();
                player.noFallDmg = true;
            }
        }
    }
}