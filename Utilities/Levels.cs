using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;
using System;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace Bismuth.Utilities
{
	public class Levels : ModPlayer
	{
		#region FIELDS
        public static bool xpbaropened = false;
		public Texture2D xp = ModContent.Request<Texture2D>("Bismuth/UI/xp").Value;
        public Texture2D xp_back = ModContent.Request<Texture2D>("Bismuth/UI/xp_back").Value;
        public Vector2 position
		{
			get
			{
				return new Vector2((Main.screenWidth / 2) - (xp_back.Width / 2), 10);
			}
		}
        public Vector2 position2
        {
            get
            {
                return new Vector2((Main.screenWidth / 2) - (xp.Width / 2), 112);
            }
        }
        public static void HotKeyPressed2()
        {
            if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                xpbaropened = !xpbaropened;
        }
        public int LEVEL = 1;
		public int XP;
		public int MAXXP = 200;
        const int MAXXLVL = 70;
        #endregion
        public override void Initialize()
        {
            LEVEL = 1;
            XP = 0;
            MAXXP = 200;
        }
        public override void SaveData(TagCompound tag)
        {
            tag["Level"] = LEVEL;
            tag["Xp"] = XP;
            tag["MaxXp"] = MAXXP;
        }
        //public override void SaveData(TagCompound tag)
        //{
        //    TagCompound save_data = new TagCompound();
        //    save_data.Add("Level", LEVEL);
        //    save_data.Add("Xp", XP);
        //    save_data.Add("MaxXp", MAXXP);
        //    return;
        //}
        public override void LoadData(TagCompound tag)
        {
            XP = tag.GetInt("Xp");
            LEVEL = tag.GetInt("Level");
            MAXXP = tag.GetInt("MaxXp");
        }
        public void LEVELUP()
		{               
            CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 50, 10, 10), Color.LemonChiffon,  "LEVEL UP!");
			LEVEL++;
			XP -= MAXXP;
            MAXXP = (int)(MAXXP * 1.12f);
            Player.GetModPlayer<BismuthPlayer>().SkillPoints++;
            CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "+1 SKILL POINT!");
        }

		public override void PreUpdate()
		{
			if (XP >= MAXXP)
			{
                if (LEVEL < MAXXLVL)
                    LEVELUP();
                else
                    XP = MAXXP - 1;
			}
		}
       
		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
		{
            if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
            {
                if (target.life < 0 && !target.SpawnedFromStatue)
                {
                    XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense));
                    if (Player.GetModPlayer<BismuthPlayer>().skill67lvl > 0 && !Main.dayTime)
                    {
                        XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense) * 0.2f);
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().skill133lvl > 0)
                    {
                        XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense) * 0.15f);
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().IsBoSRead)
                    {
                        XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense) * 0.1f);
                    }
                }

            }        }

		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
            {
                if (target.life < 0 && !target.SpawnedFromStatue)
                {
                    XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense));
                    if (Player.GetModPlayer<BismuthPlayer>().skill67lvl > 0 && !Main.dayTime)
                    {
                        XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense) * 0.2f);
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().skill133lvl > 0)
                    {
                        XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense) * 0.15f);
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().IsBoSRead)
                    {
                        XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (target.lifeMax / 5 + target.defense) * 0.1f);
                    }
                }
            }
        }

        public void DRAW(SpriteBatch spriteBatch)
        {
            if (xpbaropened && !Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)

            {
                spriteBatch.Draw(xp_back, position, Color.White);
                spriteBatch.Draw(xp, position2, new Rectangle(0, 0, (int)(xp.Width * (XP / (float)MAXXP)), xp.Height), Color.White);
                var font = Bismuth.Adonais;
                string level_ = Language.GetTextValue("Mods.Bismuth.Level") + " " + LEVEL;
                string xp_ = Language.GetTextValue("Mods.Bismuth.CurXP") + " " + XP + "/" + MAXXP;
                string SP = Language.GetTextValue("Mods.Bismuth.SPs") + " " + Player.GetModPlayer<BismuthPlayer>().SkillPoints;

                Vector2 level_s = font.MeasureString(level_);
                Vector2 xp_s = font.MeasureString(xp_);
                Vector2 SP_s = font.MeasureString(SP);
                Utils.DrawBorderStringFourWay(spriteBatch, font, level_, (xp_back.Width / 2) - (level_s.X / 2) + position.X, position.Y + 30, Color.White, Color.Black, Vector2.Zero);
                Utils.DrawBorderStringFourWay(spriteBatch, font, xp_, (xp_back.Width / 2) - (xp_s.X / 2) + position.X, position.Y + 50, Color.White, Color.Black, Vector2.Zero);
                Utils.DrawBorderStringFourWay(spriteBatch, font, SP, (xp_back.Width / 2) - (SP_s.X / 2) + position.X, position.Y + 70, Color.White, Color.Black, Vector2.Zero);
            }
        }
    }
}
