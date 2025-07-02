using Bismuth.Content.Buffs;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.BismuthLayerInPlayer
{
    public class BismuthPlayerLayer : PlayerDrawLayer, ILocalizedModType
    {
        public string LocalizationCategory => "BismuthPlayerLayerSystem";

        public override void Load()
        {
            _ = this.GetLocalization("Layer.OrcishInvasionName").Value; // Ru: Орочье вторжение En: Orcish Invasion
            _ = this.GetLocalization("Layer.DefeatedPortals").Value; // Ru: Уничтожено порталов: En: Defeated Portals:
            _ = this.GetLocalization("Layer.Wetness").Value; // Ru: Влажность: En: Wetness:
            _ = this.GetLocalization("Layer.Hunger").Value; // Ru: Сытость: En: Satiety:
        }

        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.Head);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return true; 
        }
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            string OrcishInvasionName = this.GetLocalization("Layer.OrcishInvasionName").Value; 
            string DefeatedPortals = this.GetLocalization("Layer.DefeatedPortals").Value; 
            string Wetness = this.GetLocalization("Layer.Wetness").Value; 
            string Hunger = this.GetLocalization("Layer.Hunger").Value; 

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModContent.GetInstance<Bismuth>();
            BismuthPlayer modPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();

            if (drawInfo.shadow != 0f || drawPlayer.dead)
                return;

            SpriteBatch sb = Main.spriteBatch;

            if ((double)drawInfo.shadow != 0.0)
                return;
            if (drawPlayer.dead)
                return;
            Texture2D NagaEmpty = ModContent.Request<Texture2D>("Bismuth/UI/NagaBarEmpty").Value;
            Texture2D NagaFull = ModContent.Request<Texture2D>("Bismuth/UI/NagaBarFull").Value;
            Texture2D VampireEmpty = ModContent.Request<Texture2D>("Bismuth/UI/VampireBarEmpty").Value;
            Texture2D VampireFull = ModContent.Request<Texture2D>("Bismuth/UI/VampireBarFull").Value;

            if (BismuthWorld.OrcishInvasionStage == 1 || modPlayer.OrcishBarTimer > 0)
            {
                Texture2D emptytex = ModContent.Request<Texture2D>("Bismuth/UI/OrcishInvasionEmptyBar").Value;
                Texture2D fulltex = ModContent.Request<Texture2D>("Bismuth/UI/OrcishInvasionFullBar").Value;

                Vector2 emptypos = new Vector2(Main.screenWidth - emptytex.Width - 15, Main.screenHeight - emptytex.Height - 10);
                Vector2 fullpos = emptypos + new Vector2(46f, 70f);
                sb.Draw(emptytex, emptypos, Color.White);
                sb.Draw(fulltex, fullpos, new Rectangle(0, 0, (int)(fulltex.Width * ((float)BismuthWorld.DefeatedPortals / 4)), fulltex.Height), Color.White);
                Utils.DrawBorderString(Main.spriteBatch, OrcishInvasionName, emptypos + new Vector2(emptytex.Width / 2 - FontAssets.MouseText.Value.MeasureString(OrcishInvasionName).X * (Language.ActiveCulture.CultureInfo.Name == "ru-RU" ? 0.8f : 1.0f) / 2, 26f), Color.White, Language.ActiveCulture.CultureInfo.Name == "ru-RU" ? 0.8f : 1.0f);
                Utils.DrawBorderString(Main.spriteBatch, DefeatedPortals + BismuthWorld.DefeatedPortals + "/4", emptypos + new Vector2(emptytex.Width / 2 - FontAssets.MouseText.Value.MeasureString(Language.GetTextValue("Mods.Bismuth.DefeatedPortals") + BismuthWorld.DefeatedPortals + "/4").X * (Language.ActiveCulture.CultureInfo.Name == "ru-RU" ? 0.8f : 1.0f) / 2, 108f), Color.White, Language.ActiveCulture.CultureInfo.Name == "ru-RU" ? 0.85f : 1.0f);
            }

            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga)
            {
                Vector2 raceBar = BismuthPlayer.RaceBar;

                sb.Draw(NagaEmpty, raceBar, Color.White);
                sb.Draw(NagaFull, raceBar + new Vector2(16, 2), new Rectangle(0, 0, (int)(NagaFull.Width * ((float)modPlayer.Wetness / 100)), NagaFull.Height), Color.White);

                if (Main.mouseX > raceBar.X && Main.mouseX < raceBar.X + NagaEmpty.Width && Main.mouseY > raceBar.Y && Main.mouseY < raceBar.Y + NagaEmpty.Height)
                {
                    Utils.DrawBorderString(Main.spriteBatch, Wetness + " " + modPlayer.Wetness + "/100", new Vector2(Main.mouseX + 24, Main.mouseY + 4), Color.White);
                }
            }
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                Vector2 raceBar = BismuthPlayer.RaceBar;
                sb.Draw(VampireEmpty, raceBar, Color.White);
                sb.Draw(VampireFull, raceBar + new Vector2(16, 0), new Rectangle(0, 0, (int)(VampireFull.Width * ((float)drawPlayer.GetModPlayer<BismuthPlayer>().Hunger / 100)), VampireFull.Height), Color.White);
                if (Main.mouseX > raceBar.X && Main.mouseX < raceBar.X + VampireEmpty.Width && Main.mouseY > raceBar.Y && Main.mouseY < raceBar.Y + VampireEmpty.Height)
                {
                    Utils.DrawBorderString(Main.spriteBatch, Hunger + " " + drawPlayer.GetModPlayer<BismuthPlayer>().Hunger + "/100", new Vector2(Main.mouseX + 24, Main.mouseY + 4), Color.White);
                }
            }
            #region BoneTrapEffect
            if (BismuthPlayer.BoneTrap)
            {
                Vector2 raceBar = BismuthPlayer.RaceBar;
                Texture2D texture2 = ModContent.Request<Texture2D>("Bismuth/Glow/BoneTrap").Value;
                int visualFrame2 = BismuthPlayer.BoneTrapFrame;
                int height = texture2.Height / 7;
                int num1 = (int)((double)drawInfo.Position.X + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
                int num2 = (int)((double)drawInfo.Position.Y + 444 - 4.0 - (double)Main.screenPosition.Y);
                DrawData drawData = new DrawData(texture2, new Vector2((float)num1, (float)num2), new Rectangle?(new Rectangle(0, height * visualFrame2, texture2.Width, height)), drawInfo.colorArmorLegs, 0f, new Vector2((float)texture2.Width / 2f, (float)texture2.Height), 1f, drawInfo.playerEffect, 0);
                drawInfo.DrawDataCache.Add(drawData);
            }
            #endregion
            #region GlaciationEffect
            if (drawPlayer.FindBuffIndex(ModContent.BuffType<Glaciation>()) != -1)
            {
                Texture2D texture2 = ModContent.Request<Texture2D>("Bismuth/Glow/Glaciation").Value;
                int visualFrame2 = BismuthPlayer.GlaciationFrame;
                int height = texture2.Height / 10;
                int num1 = (int)((double)drawInfo.Position.X + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
                int num2 = (int)((double)drawInfo.Position.Y + 584 - (double)Main.screenPosition.Y);
                DrawData drawData = new DrawData(texture2, new Vector2((float)num1, (float)num2), new Rectangle?(new Rectangle(0, height * visualFrame2, texture2.Width, height)), new Color(255, 255, 255, 135), 0f, new Vector2((float)texture2.Width / 2f, (float)texture2.Height), 1f, drawInfo.playerEffect, 0);
                drawInfo.DrawDataCache.Add(drawData);
            }
            #endregion
            #region OneRingEffect

            if (BismuthPlayer.alpharing != 0 && !Main.gameMenu)
            {
                Color color = new Color(0, 0, 0, BismuthPlayer.alpharing);
                DrawData rect1 = new DrawData(TextureAssets.MagicPixel.Value, Vector2.Zero + new Vector2(-300, -300), new Rectangle(0, 0, Main.screenWidth + 600, Main.screenHeight + 600), color);
                drawInfo.DrawDataCache.Add(rect1);
            }
            #endregion
            #region OdysseusBowEffect
            if (modPlayer.ArrowCharge > 0)
            {
                Texture2D back = ModContent.Request<Texture2D>("Bismuth/Glow/MarbleArrowEmpty").Value;
                Texture2D front = ModContent.Request<Texture2D>("Bismuth/Glow/MarbleArrowFull").Value;
                int num3 = (int)((double)drawInfo.Position.X + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
                int num4 = (int)((double)drawInfo.Position.Y - 28 - (double)Main.screenPosition.Y);
                DrawData drawData3 = new DrawData(back, new Vector2((float)num3, (float)num4), new Rectangle?(new Rectangle(0, 0, back.Width, back.Height)), Color.White, 0.0f, new Vector2((float)back.Width / 2f, (float)back.Height), 1f, SpriteEffects.None, 0);
                DrawData drawData4 = new DrawData(front, new Vector2(num3, num4 + front.Height - (int)(front.Height * (modPlayer.ArrowCharge / 100f))), new Rectangle?(new Rectangle(0, front.Height - (int)(front.Height * (modPlayer.ArrowCharge / 100f)), front.Width, (int)(front.Height * (modPlayer.ArrowCharge / 100f)))), Color.White, 0.0f, new Vector2((float)front.Width / 2f, (float)front.Height), 1f, SpriteEffects.None, 0);
                drawInfo.DrawDataCache.Add(drawData3);
                drawInfo.DrawDataCache.Add(drawData4);
            }
            #endregion
            #region TheseusSwordEffect
            if (modPlayer.TheseusCombo > 0)
            {
                Texture2D back = ModContent.Request<Texture2D>("Bismuth/Glow/TheseusSwordEmpty").Value;
                Texture2D front = ModContent.Request<Texture2D>("Bismuth/Glow/TheseusSwordFull").Value;
                int num3 = (int)((double)drawInfo.Position.X + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
                int num4 = (int)((double)drawInfo.Position.Y - 28 - (double)Main.screenPosition.Y);
                DrawData drawData5 = new DrawData(back, new Vector2((float)num3, (float)num4), new Rectangle?(new Rectangle(0, 0, back.Width, back.Height)), Color.White, 0.0f, new Vector2((float)back.Width / 2f, (float)back.Height), 1f, SpriteEffects.None, 0);
                DrawData drawData6 = new DrawData(front, new Vector2(num3 - 19, num4 - 14), new Rectangle?(new Rectangle(0, 0, (int)(front.Width * (modPlayer.TheseusCombo / 100f)), front.Height)), Color.White);
                drawInfo.DrawDataCache.Add(drawData5);
                drawInfo.DrawDataCache.Add(drawData6);
            }
            #endregion
            //------------------------------------//
            #region
            if (drawPlayer.invis || drawPlayer.dead)
                return;
            Rectangle bodyFrame2 = drawPlayer.bodyFrame;
            bodyFrame2.Y -= 336;
            if (bodyFrame2.Y < 0)
            {
                bodyFrame2.Y = 0;
            }
            Vector2 drawPosition = new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2f) + (float)(drawPlayer.width / 2f))),
            (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 2f + drawPlayer.gfxOffY - drawPlayer.mount.PlayerOffset)));
            #region DrawingAltHair
            if (BismuthPlayer.myhair != 0)
            {
                if (BismuthPlayer.myhair == 1 && drawPlayer.GetModPlayer<BismuthPlayer>().IsEquippedHeartOfDesert && BismuthPlayer.HoSvisual && !drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga && !drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
                {
                    Texture2D hairTexture = TextureAssets.PlayerHair[drawPlayer.hair].Value;
                    DrawData drawData10 = new DrawData(hairTexture, drawPosition + drawPlayer.headPosition + drawInfo.headVect, bodyFrame2, drawInfo.colorHair, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
                    drawInfo.DrawDataCache.Add(drawData10);

                }
                if (BismuthPlayer.myhair == 2 && BismuthPlayer.lichvisual && !drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga && !drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
                {
                    Texture2D hair = TextureAssets.PlayerHair[16].Value;

                    DrawData drawData9 = new DrawData(hair, drawPosition + drawPlayer.headPosition + drawInfo.headVect,bodyFrame2, drawInfo.colorHair, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);             
                    drawInfo.DrawDataCache.Add(drawData9);
                }
            }
            else if (!drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga && !drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                Texture2D hairAlt = TextureAssets.PlayerHairAlt[drawPlayer.hair].Value;

                DrawData drawData8 = new DrawData(hairAlt, drawPosition + drawPlayer.headPosition + drawInfo.headVect, bodyFrame2, drawInfo.colorHair, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
                drawInfo.DrawDataCache.Add(drawData8);
            }         
            #endregion 
            if (!drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire && !drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga) return;
            Vector2 vanityOffset = new Vector2(0, -4);
            Texture2D headTex = Bismuth.VampireArms;
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                if (drawPlayer.Male)
                    headTex = Bismuth.VampireMaleFace;
                else
                    headTex = Bismuth.VampireFemaleFace;
            }
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga)
            {
                headTex = Bismuth.NagaFace;
            }
            DrawData drawData7 = new DrawData(headTex, drawPosition + drawPlayer.headPosition + drawInfo.headVect, drawPlayer.bodyFrame, drawInfo.colorArmorHead, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);          
            drawInfo.DrawDataCache.Add(drawData7);
            #endregion
            //-------------------------------------//
            if (drawPlayer.invis || drawPlayer.dead)
                return;

            if (!drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire && !drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga) return;

            Texture2D armsTex = Bismuth.VampireFemaleBody;
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                armsTex = Bismuth.VampireArms;
            }
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga)
            {
                armsTex = Bismuth.NagaArm;
            }
            Vector2 drawPosition1 = new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2f) + (float)(drawPlayer.width / 2f))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f + drawPlayer.gfxOffY - drawPlayer.mount.PlayerOffset)));
            DrawData drawData11 = new DrawData(armsTex, drawPosition + drawPlayer.bodyPosition + drawInfo.bodyVect, drawPlayer.bodyFrame, drawInfo.colorArmorBody, drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
            drawInfo.DrawDataCache.Add(drawData11);
            //-------------------------------------//
            if (drawPlayer.invis || drawPlayer.dead)
                return;

            if (!drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire && !drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga) return;

            Texture2D bodyTex = Bismuth.VampireArms;
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                if (drawPlayer.Male)
                    bodyTex = Bismuth.VampireMaleBody;
                else
                    bodyTex = Bismuth.VampireFemaleBody;
            }
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga)
            {
                bodyTex = Bismuth.NagaBody;
            }
            Vector2 drawPosition2 = new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2f) + (float)(drawPlayer.width / 2f))),(float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f + drawPlayer.gfxOffY - drawPlayer.mount.PlayerOffset)));
            DrawData drawData12 = new DrawData(bodyTex, drawPosition + drawPlayer.bodyPosition + drawInfo.bodyVect, drawPlayer.bodyFrame, drawInfo.colorArmorBody, drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);             
            drawInfo.DrawDataCache.Add(drawData12);
            //-------------------------------------//
            if (drawPlayer.invis || drawPlayer.dead)
                return;
            Vector2 drawPosition3 = new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2f) + (float)(drawPlayer.width / 2f))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f + drawPlayer.gfxOffY - drawPlayer.mount.PlayerOffset)));            
            if (!drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire && !drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga) return;
            Texture2D legsTex = Bismuth.VampireArms;
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                if (drawPlayer.Male)
                    legsTex = Bismuth.VampireMaleLegs;
                else
                    legsTex = Bismuth.VampireFemaleLegs;
            }
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga)
            {
                legsTex = Bismuth.NagaLegs;
            }
            DrawData drawData13 = new DrawData(legsTex, drawPosition + drawPlayer.legPosition + drawInfo.legVect,drawPlayer.legFrame, drawInfo.colorArmorLegs, drawPlayer.legRotation, drawInfo.legVect, 1f, drawInfo.playerEffect, 0);
            drawInfo.DrawDataCache.Add(drawData13);
            //-------------------------------------//
            //if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsVampire && !Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsNaga) return;
            for (int i = 0; i < 5; i++)
            {
               // layers[i].visible = false;
                //layers.Add(MapHeadLayer);
            }
            //--------------------------------------//
            Mod thisMod = ModLoader.GetMod("Bismuth");
            Texture2D tMapHead = Bismuth.VampireFemaleHeadMap;


            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsNaga)
                tMapHead = Bismuth.NagaHeadMap;
            if (drawPlayer.GetModPlayer<BismuthPlayer>().IsVampire)
            {
                if (drawPlayer.Male)
                    tMapHead = Bismuth.VampireMaleHeadMap;
                else
                    tMapHead = Bismuth.VampireFemaleHeadMap;
            }

            Main.spriteBatch.Draw(tMapHead, new Vector2(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2), drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f) + drawInfo.rotationOrigin, null, Color.White, drawPlayer.headRotation, drawInfo.rotationOrigin, 1f, drawInfo.playerEffect, 0);
            //--------------------------------------//
            /*if (Bismuthvampbat)
            {
                foreach (PlayerLayer layer in layers)
                {
                    if (layer != PlayerLayer.MountBack && layer != PlayerLayer.MountFront && layer != PlayerLayer.MiscEffectsFront && layer != PlayerLayer.MiscEffectsBack && layer != BismuthPlayer.MiscEffects)
                        layer.visible = false;
                }
            }
            else
            {
                foreach (DrawLayer<PlayerDrawSet> layer in layers)
                    layer.visible = true;
            }
            for (int i = 0; i < layers.Count - 1; i++)
            {
                if (layers[i].Name == "Hair" || layers[i].Name == "HairBack" || layers[i].Name == "Head")
                {
                    if ((HoSvisual || lichvisual) && Player.armor[0].type <= 0 && Player.armor[10].type <= 0 && myhair != 0)
                    {
                        layers[i].visible = false;
                        layers.Insert(i, BismuthFaceLayer);
                        i++; //prevent infinite loop
                    }
                    else
                    {
                        layers[i].visible = true;
                        i++;
                    }
                }
            }
            if (!(!Player.active || (!IsVampire && !IsNaga) || Player.FindBuffIndex(ModContent.BuffType<VampireBat>()) != -1))
            {
                for (int i = 0; i < layers.Count - 1; i++)
                {
                    if (layers[i].Name == "Skin" || layers[i].Name == "Hair" || layers[i].Name == "Face") //Hide these layers
                        layers[i].visible = false;

                    if (layers[i].Name == "Legs") //insert legs layer, ALWAYS
                    {
                        layers[i].visible = false; // false;
                        layers.Insert(i, BismuthLegsLayer);
                        i++; //prevent infinite loop
                    }
                    if (layers[i].Name == "Body") //insert body layer
                    {
                        layers[i].visible = false; //armour will always be visible when certain clothing is equiped

                        layers.Insert(i, BismuthBodyLayer);
                        i++;

                    }
                    if (layers[i].Name == "Head") //insert head layer
                    {
                        layers[i].visible = false;
                        layers.Insert(i, BismuthFaceLayer);
                        i++;
                    }
                    if (layers[i].Name == "Arms") //insert arms layer, also when certain clothing is equiped
                    {
                        layers[i].visible = false;
                        layers.Insert(i, BismuthArmsLayer);
                        i++;
                    }
                }
            }*/
        }
    }
}