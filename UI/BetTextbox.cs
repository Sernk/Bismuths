using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;

namespace Bismuth.UI
{
    public class BetTextbox : UITextBox
    {
        public BetTextbox(string text, float textScale = 1, bool large = false) : base(text, textScale, large) { }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            SetText(new string(Text.Where(c => char.IsDigit(c)).ToArray()));
            SetTextMaxLength(4);
        }
    }
}