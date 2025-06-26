using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using Terraria.DataStructures;
using System.IO;
using Bismuth.Content.NPCs;
using Bismuth.UI;
using Terraria.Localization;
using Terraria.Audio;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Accessories;


namespace Bismuth.Utilities
{
    public class DiceGame : ModPlayer
    {
        public bool IsTableOpened = false;
        bool IsBetMade = false;
        int bet = 0;
        int needtopay = 0;
        int actgold = 0;
        bool IsFocused = false;
        bool IsThrownDices = false;
        bool IsEnemyTurn = false;
        Texture2D tabletex = ModContent.Request<Texture2D>("Bismuth/UI/DiceTable").Value;
        Texture2D buttontex;
        Texture2D firstdice = ModContent.Request<Texture2D>("Bismuth/UI/ClosedSkill").Value;
        Texture2D seconddice = ModContent.Request<Texture2D>("Bismuth/UI/ClosedSkill").Value;
        Texture2D wintex = ModContent.Request<Texture2D>("Bismuth/UI/WinSign").Value;
        Texture2D losetex = ModContent.Request<Texture2D>("Bismuth/UI/LoseSign").Value;
        Texture2D betfieldtex = ModContent.Request<Texture2D>("Bismuth/UI/BetField").Value;
        int side1 = 0;
        int side2 = 0;
        int taimer0 = 0;
        int taimer1 = 0;
        int taimer2 = 0;
        int myscore = 0;
        int enemyscore = 0;
        int firstvalue = 0;
        int secondvalue = 0;
        int firstvalueenemy = 0;
        int secondvalueenemy = 0;
        int result = 0;
        bool soundflag = false;
        public int VictoryTotal = 0;
        public int VictoryInARow = 0;
        public bool ThirdRow = false;
        public bool FourthRow = false;
        public bool FifthRow = false;
        List<Keys> betkeys = new List<Keys>();
        bool flag = false;
        bool Backflag = false;
        int changebettimer = 0;

        public void DrawTable(SpriteBatch sb)
        {
            if (IsTableOpened)
            {
                DynamicSpriteFont curfont = Language.ActiveCulture.CultureInfo.Name == "ru-RU" ? FontAssets.MouseText.Value : Bismuth.Adonais;
                //Player.talkNPC = -1;
                Player.AddBuff(Mod.Find<ModBuff>("DicePlaying").Type, 60);
                sb.Draw(tabletex, new Vector2(Main.screenWidth / 2 - 425, Main.screenHeight / 2 - 267), Color.White);
                if(buttontex != null)
                    sb.Draw(buttontex, new Vector2(Main.screenWidth / 2 - buttontex.Width / 2, Main.screenHeight / 2 + 130), Color.White);
                if (!IsBetMade)
                {
                    sb.Draw(ModContent.Request<Texture2D>("Bismuth/UI/CloseBook").Value, new Vector2(Main.screenWidth / 2 - 425 + tabletex.Width - 70, Main.screenHeight / 2 - 267 + 20), Color.White);
                    if (Main.mouseX > (Main.screenWidth / 2 - 425 + tabletex.Width - 70) && Main.mouseX < (Main.screenWidth / 2 - 425 + tabletex.Width - 52) && Main.mouseY > (Main.screenHeight / 2 - 267 + 20) && Main.mouseY < (Main.screenHeight / 2 - 267 + 40) && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        IsTableOpened = false;
                    }
                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.EnterBet"), Main.screenWidth / 2 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.EnterBet")).X / 2, Main.screenHeight / 2 - 30, Color.White, Color.Black, new Vector2(), 1f);
                    changebettimer--;
                    sb.Draw(betfieldtex, new Vector2(Main.screenWidth / 2 - betfieldtex.Width / 2, Main.screenHeight / 2), Color.White);
                    if (Main.mouseX > Main.screenWidth / 2 - betfieldtex.Width / 2 && Main.mouseX < Main.screenWidth / 2 + betfieldtex.Width / 2 && Main.mouseY > Main.screenHeight / 2 && Main.mouseY < Main.screenHeight / 2 + betfieldtex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        IsFocused = true;

                    }
                    if (!(Main.mouseX > Main.screenWidth / 2 - betfieldtex.Width / 2 && Main.mouseX < Main.screenWidth / 2 + betfieldtex.Width / 2 && Main.mouseY > Main.screenHeight / 2 && Main.mouseY < Main.screenHeight / 2 + betfieldtex.Height) && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        IsFocused = false;
                    }
                  

                    if (IsFocused)
                    {
                        KeyboardState kbState = Keyboard.GetState();
                        Keys[] kbchars = kbState.GetPressedKeys();
                        if (betkeys.Count == 1 && kbState.IsKeyUp(betkeys[0]))
                        {
                            flag = true;
                        }
                        if (kbState.IsKeyDown(Keys.Back) && !Backflag && betkeys.Count > 0)
                        {
                            if (betkeys.Count == 1)
                                flag = false;
                            betkeys.Remove(betkeys.Last());
                            Backflag = true;
                            
                        }
                        if (kbState.IsKeyUp(Keys.Back))
                            Backflag = false;
                        foreach (Keys keys in kbchars)
                        {
                            if (betkeys.Count >= 2)
                                break;
                            if ((betkeys.Count == 0 && keys >= Keys.D1 && keys <= Keys.D9))
                                betkeys.Add(keys);
                            else if (betkeys.Count == 1 && keys >= Keys.D0 && keys <= Keys.D9 && flag)
                            {

                                betkeys.Add(keys);
                            }

                        }
                        if (betkeys.Count == 1)
                            bet = betkeys[0] - Keys.D0;
                        else if (betkeys.Count == 2)
                        {
                            bet = (betkeys[0] - Keys.D0) * 10 + (betkeys[1] - Keys.D0);
                        }
                        else
                            bet = 0;
                    }
                    if (bet != 0)
                    {
                        
                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, bet.ToString(), Main.screenWidth / 2 - betfieldtex.Width / 2 + 22, Main.screenHeight / 2 + 7, Color.White, Color.Black, new Vector2(), 1.9f);
                        if (actgold == 0)
                        {
                            for (int num66 = 0; num66 < 58; num66++)
                            {
                                if (Main.LocalPlayer.inventory[num66].type == ItemID.GoldCoin && Main.LocalPlayer.inventory[num66].stack > 0)
                                {
                                    actgold += Main.LocalPlayer.inventory[num66].stack;
                                }
                            }

                        }
                        if (actgold >= bet)
                        {
                            buttontex = ModContent.Request<Texture2D>("Bismuth/UI/BetButton").Value;
                            if (Main.mouseX > Main.screenWidth / 2 - buttontex.Width / 2 && Main.mouseX < Main.screenWidth / 2 + buttontex.Width / 2 && Main.mouseY > Main.screenHeight / 2 + 143 && Main.mouseY < Main.screenHeight / 2 + 143 + buttontex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                needtopay = bet;
                                for (int num66 = 0; num66 < 58; num66++)
                                {
                                    if (Main.LocalPlayer.inventory[num66].type == ItemID.GoldCoin && Main.LocalPlayer.inventory[num66].stack > 0)
                                    {
                                        if (Main.LocalPlayer.inventory[num66].stack < needtopay)
                                        {
                                            needtopay -= Main.LocalPlayer.inventory[num66].stack;
                                            Main.LocalPlayer.inventory[num66].stack = 0;
                                        }
                                        else
                                        {
                                            Main.LocalPlayer.inventory[num66].stack -= needtopay;
                                            needtopay = 0;
                                        }
                                        if (needtopay == 0)
                                            break;
                                    }
                                }
                                IsBetMade = true;
                                buttontex = ModContent.Request<Texture2D>("Bismuth/UI/ThrowingButton").Value;
                                flag = false;
                                Backflag = false;
                            }
                        }
                        else
                            buttontex = null;
                    }
                    else
                        buttontex = null;
                }
                else
                {
                    if (Player.GetModPlayer<BismuthPlayer>().IsEquippedDiceCup && myscore != 0)
                        Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, Language.GetTextValue("Mods.Bismuth.YourScore") + (myscore - 1) + " + 1", Main.screenWidth / 2 + 160, Main.screenHeight / 2 - 160, Color.White, Color.Black, new Vector2(), 1.2f);
                    else
                        Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, Language.GetTextValue("Mods.Bismuth.YourScore") + myscore, Main.screenWidth / 2 + 160, Main.screenHeight / 2 - 160, Color.White, Color.Black, new Vector2(), 1.2f);
                    Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, Language.GetTextValue("Mods.Bismuth.EnemyScore") + enemyscore, Main.screenWidth / 2 + 160, Main.screenHeight / 2 - 130, Color.White, Color.Black, new Vector2(), 1.2f);
                    Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, Language.GetTextValue("Mods.Bismuth.YourBet") + bet, Main.screenWidth / 2 + 160, Main.screenHeight / 2 - 100, Color.White, Color.Black, new Vector2(), 1.2f);
                    sb.Draw(TextureAssets.Item[73].Value, new Vector2(Main.screenWidth / 2 + 160 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.YourBet") + bet).X * 1.2f + 4, Main.screenHeight / 2 - 98), Color.White);
                    Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, Language.GetTextValue("Mods.Bismuth.Winstreak") + VictoryInARow, Main.screenWidth / 2 + 160, Main.screenHeight / 2 - 70, Color.White, Color.Black, new Vector2(), 1.2f);
                    Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, Language.GetTextValue("Mods.Bismuth.DiceVicTotal") + VictoryTotal, Main.screenWidth / 2 + 160, Main.screenHeight / 2 - 40, Color.White, Color.Black, new Vector2(), 1.2f);
                    if (!IsThrownDices && !IsEnemyTurn && Main.mouseX > Main.screenWidth / 2 - buttontex.Width / 2 && Main.mouseX < Main.screenWidth / 2 + buttontex.Width / 2 && Main.mouseY > Main.screenHeight / 2 + 143 && Main.mouseY < Main.screenHeight / 2 + 143 + buttontex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        firstvalue = Main.rand.Next(1, 7);
                        secondvalue = Main.rand.Next(1, 7);
                        side1 = Main.rand.Next(1, 3);
                        side2 = Main.rand.Next(1, 3);
                        switch (firstvalue)
                        {
                            case 1:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceI").Value;
                                break;
                            case 2:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceII").Value;
                                break;
                            case 3:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIII").Value;
                                break;
                            case 4:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIV").Value;
                                break;
                            case 5:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceV").Value;
                                break;
                            case 6:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceVI").Value;
                                break;
                        }
                        switch (secondvalue)
                        {
                            case 1:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceI").Value;
                                break;
                            case 2:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceII").Value;
                                break;
                            case 3:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIII").Value;
                                break;
                            case 4:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIV").Value;
                                break;
                            case 5:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceV").Value;
                                break;
                            case 6:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceVI").Value;
                                break;
                        }
                        IsThrownDices = true;
                    }
                    if (IsThrownDices && !IsEnemyTurn)
                    {
                        if (!soundflag)
                        {
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/DiceThrowing"));
                            soundflag = true;
                        }
                        taimer0++;
                        if (taimer0 >= 60)
                        {
                            sb.Draw(firstdice, new Vector2(Main.screenWidth / 2 - firstdice.Width - 30, Main.screenHeight / 2 + 10), new Rectangle(0, 0, firstdice.Width, firstdice.Height), Color.White, 0f, Vector2.Zero, 1f, ((side1 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
                            sb.Draw(seconddice, new Vector2(Main.screenWidth / 2 + seconddice.Width - 19, Main.screenHeight / 2 + 10), new Rectangle(0, 0, seconddice.Width, seconddice.Height), Color.White, 0f, Vector2.Zero, 1f, ((side2 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
                            myscore = firstvalue + secondvalue + (Player.GetModPlayer<BismuthPlayer>().IsEquippedDiceCup ? 1 : 0);
                            buttontex = ModContent.Request<Texture2D>("Bismuth/UI/PassButton").Value;
                            taimer0 = 60;
                            taimer1++;
                            if (taimer1 >= 60)
                                taimer1 = 60;
                        }
                    }
                    if (IsThrownDices && !IsEnemyTurn && taimer1 == 60 && Main.mouseX > Main.screenWidth / 2 - buttontex.Width / 2 && Main.mouseX < Main.screenWidth / 2 + buttontex.Width / 2 && Main.mouseY > Main.screenHeight / 2 + 143 && Main.mouseY < Main.screenHeight / 2 + 143 + buttontex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        soundflag = false;
                        if (!soundflag)
                        {
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/DiceThrowing"));
                            soundflag = true;
                        }
                        IsThrownDices = false;
                        IsEnemyTurn = true;
                        firstvalueenemy = Main.rand.Next(1, 7);
                        secondvalueenemy = Main.rand.Next(1, 7);
                        switch (firstvalueenemy)
                        {
                            case 1:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceI").Value;
                                break;
                            case 2:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceII").Value;
                                break;
                            case 3:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIII").Value;
                                break;
                            case 4:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIV").Value;
                                break;
                            case 5:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceV").Value;
                                break;
                            case 6:
                                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/DiceVI").Value;
                                break;
                        }
                        switch (secondvalueenemy)
                        {
                            case 1:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceI").Value;
                                break;
                            case 2:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceII").Value;
                                break;
                            case 3:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIII").Value;
                                break;
                            case 4:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceIV").Value;
                                break;
                            case 5:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceV").Value;
                                break;
                            case 6:
                                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/DiceVI").Value;
                                break;
                        }
                    }
                    if (!IsThrownDices && IsEnemyTurn)
                    {

                        taimer2++;
                        if (taimer2 >= 60)
                        {
                            enemyscore = firstvalueenemy + secondvalueenemy;
                            if (myscore > enemyscore)
                                result = 1;
                            else if (myscore < enemyscore)
                                result = -1;
                            else if (myscore == enemyscore)
                                result = 0;
                            sb.Draw(firstdice, new Vector2(Main.screenWidth / 2 - firstdice.Width - 30, Main.screenHeight / 2 + 10), new Rectangle(0, 0, firstdice.Width, firstdice.Height), Color.White, 0f, Vector2.Zero, 1f, ((side1 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
                            sb.Draw(seconddice, new Vector2(Main.screenWidth / 2 + seconddice.Width - 19, Main.screenHeight / 2 + 10), new Rectangle(0, 0, seconddice.Width, seconddice.Height), Color.White, 0f, Vector2.Zero, 1f, ((side2 == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
                            buttontex = ModContent.Request<Texture2D>("Bismuth/UI/FinishButton").Value;
                            taimer2 = 60;
                            if (result == 1)
                                sb.Draw(ModContent.Request<Texture2D>("Bismuth/UI/WinSign").Value, new Vector2(Main.screenWidth / 2 - 63, Main.screenHeight / 2 - 196), Color.White);
                            else if (result == 0)
                                sb.Draw(ModContent.Request<Texture2D>("Bismuth/UI/DrawSign").Value, new Vector2(Main.screenWidth / 2 - 63, Main.screenHeight / 2 - 196), Color.White);
                            else if (result == -1)
                                sb.Draw(ModContent.Request<Texture2D>("Bismuth/UI/LoseSign").Value, new Vector2(Main.screenWidth / 2 - 63, Main.screenHeight / 2 - 196), new Rectangle(0, 0, losetex.Width, losetex.Height), Color.White);
                        }

                    }
                    if (IsEnemyTurn && taimer2 == 60 && Main.mouseX > Main.screenWidth / 2 - buttontex.Width / 2 && Main.mouseX < Main.screenWidth / 2 + buttontex.Width / 2 && Main.mouseY > Main.screenHeight / 2 + 143 && Main.mouseY < Main.screenHeight / 2 + 143 + buttontex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        switch (result)
                        {
                            case -1:
                                {
                                    VictoryInARow = 0;
                                    break;
                                }
                            case 0:
                                {
                                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet);
                                    break;
                                }
                            case 1:
                                {
                                    VictoryTotal++;
                                    VictoryInARow++;
                                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet * 2);
                                    if (Player.GetModPlayer<BismuthPlayer>().IsEquippedGamblersBag)
                                    {
                                        if (bet % 2 == 0)
                                        {
                                            Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet / 2);
                                        }
                                        else
                                        {
                                            Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet / 2);
                                            Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.SilverCoin, 50);
                                        }
                                    }
                                    if (VictoryTotal == 5)
                                    {
                                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet * 2);
                                        if (Player.GetModPlayer<BismuthPlayer>().IsEquippedGamblersBag)
                                        {
                                            if (bet % 2 == 0)
                                            {
                                                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet / 2);
                                            }
                                            else
                                            {
                                                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet / 2);
                                                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.SilverCoin, 50);
                                            }
                                        }
                                    }
                                    if (VictoryTotal == 10)
                                    {
                                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet * 4);
                                        if (Player.GetModPlayer<BismuthPlayer>().IsEquippedGamblersBag)
                                        {
                                            if (bet % 2 == 0)
                                            {
                                                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet);
                                            }
                                            else
                                            {
                                                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, bet);
                                                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.SilverCoin, 50);
                                            }
                                        }
                                    }
                                    if (VictoryTotal == 50)
                                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<MidasGlove>());
                                    if (VictoryInARow == 3 && !ThirdRow)
                                    {
                                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<GamblersBag>());
                                        ThirdRow = true;
                                    }
                                    if (VictoryInARow == 4 && !FourthRow)
                                    {
                                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<DiceCup>());
                                        FourthRow = true;
                                    }
                                    if (VictoryInARow == 5 && !FifthRow)
                                    {
                                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<HerosBoots>());
                                        FifthRow = true;
                                    }
                                    break;
                                }
                        }
                        IsEnemyTurn = false;
                        IsTableOpened = false;
                    }
                }
            }
            else
            {
                taimer0 = 0;
                taimer1 = 0;
                taimer2 = 0;
                result = 0;
                myscore = 0;
                enemyscore = 0;
                IsEnemyTurn = false;
                IsThrownDices = false;
                soundflag = false;
                bet = 0;
                actgold = 0;
                needtopay = 0;
                IsBetMade = false;
                betkeys.Clear();
               // buttontex = ModContent.Request<Texture2D>("Bismuth/UI/ThrowingButton");
                firstdice = ModContent.Request<Texture2D>("Bismuth/UI/ClosedSkill").Value;
                seconddice = ModContent.Request<Texture2D>("Bismuth/UI/ClosedSkill").Value;
            }
        }
        public override void SaveData(TagCompound tag)
        {
            tag["ThirdRow"] = ThirdRow;
            tag["FourthRow"] = FourthRow;
            tag["FifthRow"] = FifthRow;
            tag["VictoryTotal"] = VictoryTotal;
            tag["VictoryInARow"] = VictoryInARow;
        }
        //public override void SaveData(TagCompound tag)
        //{
        //    TagCompound save_data = new TagCompound();
        //    save_data.Add("ThirdRow", ThirdRow);
        //    save_data.Add("FourthRow", FourthRow);
        //    save_data.Add("FifthRow", FifthRow);
        //    save_data.Add("VictoryTotal", VictoryTotal);
        //    save_data.Add("VictoryInARow", VictoryInARow);

        //    return;
        //}
        public override void LoadData(TagCompound tag)
        {
            ThirdRow = tag.GetBool("ThirdRow");
            FourthRow = tag.GetBool("FourthRow");
            FifthRow = tag.GetBool("FifthRow");
            VictoryTotal = tag.GetInt("VictoryTotal");
            VictoryInARow = tag.GetInt("VictoryInARow");
        }
    }
}