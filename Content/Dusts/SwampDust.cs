using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Dusts
{
    public class SwampDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.noLight = true;
            dust.scale *= 1f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.95f;        
            if ((double)dust.scale < 0.5)
                dust.active = false;
            return false;
        }
    }
}
