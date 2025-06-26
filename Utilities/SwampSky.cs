using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class SwampSkyVisual : ModSystem
    {
        public override void PostUpdateEverything()
        {
            bool _SwampSkyVisual = false;
            NPC[] npc = Main.npc;
            foreach (NPC npc2 in npc)
            {
                if (BismuthPlayer.ZoneSwamp)
                {
                    _SwampSkyVisual = true;
                    break;
                }
            }
            if (_SwampSkyVisual)
            {
                if (!Filters.Scene["Bismuth:SwampSky"].IsActive())
                {
                    Filters.Scene.Activate("Bismuth:SwampSky", default(Vector2));
                }
            }
            else if (Filters.Scene["Bismuth:SwampSky"].IsActive())
            {
                Filters.Scene.Deactivate("Bismuth:SwampSky");
            }
        }
    }

    public class SwampSky : CustomSky
    {
        private bool isActive;

        private float intensity;

        public override void Update(GameTime gameTime)
        {
            if (isActive && intensity < 0.5f)
            {
                intensity += 0.01f;
            }
            else if (!isActive && intensity > 0f)
            {
                intensity -= 0.01f;
            }
        }

        private bool UpdatepyroIndex()
        {
            bool _SwampSky = BismuthPlayer.ZoneSwamp = true;
            if (_SwampSky)
            {
                return true;
            }
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0f && minDepth < 0f)
            {
                spriteBatch.Draw(TextureAssets.BlackTile.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(0, 50, 100) * intensity);
            }
        }

        public override float GetCloudAlpha()
        {
            return 0f;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            isActive = false;
        }

        public override void Reset()
        {
            isActive = false;
        }

        public override bool IsActive()
        {
            if (!isActive)
            {
                return intensity > 0f;
            }
            return true;
        }
    }
}