using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Bismuth.Content.Buffs;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class ConverterPlayer : ModPlayer
    {
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            int damage = (int)modifiers.SourceDamage.Additive;
            if (Player.buffType.Any(x => x == ModContent.BuffType<Converter>()))
            {
                
                if (Player.statMana >= damage)
                {
                    CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y, 10, 10), Color.BlueViolet, damage + " mana absorbed");
                    Player.statMana -= damage;
                    Player.immune = true;
                    Player.immuneAlpha = 0;
                    Player.immuneTime = 40;
                    Player.immuneNoBlink = true;
                    if (Player.longInvince)
                        Player.immuneTime += 40;
                    return;
                }
                else
                {
                    CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y, 10, 10), Color.BlueViolet, Player.statMana + " mana absorbed");
                    damage -= Player.statMana;
                    Player.statMana = 0;                   
                    return;
                }
            }
            return;
        }      
    }
}