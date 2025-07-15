using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Dusts
{
    public class BladeOfWoeDust : ModDust
    {
        int timer = 0;

        public override void OnSpawn(Dust dust)
        {
            dust.velocity = Vector2.Zero;
            dust.noLight = true;
            dust.color = Color.Black;
            dust.noGravity = true;
            dust.scale = 1f;
        }
        public override bool Update(Dust dust)
        {
            timer++;
            dust.rotation *= 1.01f;
            if (timer > 180) dust.scale *= 0.98f;
            else dust.scale = 1f;
            if (dust.scale < 0.5) dust.active = false;
            return false;
        }
    }
}