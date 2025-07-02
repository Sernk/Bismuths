using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities
{
	public class Levels : ModPlayer, ILocalizedModType
	{
        public string LocalizationCategory => "LevelsLocalization";

        public override void Load()
        {
            _ = this.GetLocalization("Levels.Level").Value; // Ru: УРОВЕНЬ: En: LEVEL:
            _ = this.GetLocalization("Levels.CurXP").Value; // Ru: ОПЫТ: En: XP:
            _ = this.GetLocalization("Levels.SPs").Value; // Ru: ОЧКИ УМЕНИЙ: En: SKILL POINTS:
        }
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

            }
        }

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
            string Level = this.GetLocalization("Levels.Level").Value;
            string CurXP = this.GetLocalization("Levels.CurXP").Value;
            string SPs = this.GetLocalization("Levels.SPs").Value;

            if (xpbaropened && !Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
            {
                spriteBatch.Draw(xp_back, position, Color.White);
                spriteBatch.Draw(xp, position2, new Rectangle(0, 0, (int)(xp.Width * (XP / (float)MAXXP)), xp.Height), Color.White);
                var font = Bismuth.Adonais;
                string level_ = Level + " " + LEVEL;
                string xp_ = CurXP + " " + XP + "/" + MAXXP;
                string SP = SPs + " " + Player.GetModPlayer<BismuthPlayer>().SkillPoints;

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
