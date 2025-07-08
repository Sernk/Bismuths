using Bismuth.Content.Items.Materials;
using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class QuicksilverMirror : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 25, 0);
            Item.rare = 1;
            Item.useStyle = 4;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            Vector2 moveto = Vector2.Zero;
            List<Vector2> ActualCaskets = new List<Vector2>();
            foreach (Vector2 pos in BismuthWorld.CasketCoords)
            {
                if (WorldMethods.CheckTile((int)pos.X, (int)pos.Y, ModContent.TileType<Tiles.BeggarsCasket>()))
                    ActualCaskets.Add(pos);
            }
            if (ActualCaskets.Count == 0)
                return false;
            else
                return true;
        }
        public override bool? UseItem(Player player)
        {
            Vector2 moveto = Vector2.Zero;
            List<Vector2> ActualCaskets = new List<Vector2>();
            foreach (Vector2 pos in BismuthWorld.CasketCoords)
            {
                if (WorldMethods.CheckTile((int)pos.X, (int)pos.Y, ModContent.TileType<Tiles.BeggarsCasket>()))
                    ActualCaskets.Add(pos);
            }
            foreach (Vector2 pos in ActualCaskets)
                if (moveto == Vector2.Zero || Vector2.Distance(player.position, pos * 16) < Vector2.Distance(player.position, moveto * 16))
                    moveto = pos;
            Projectile.NewProjectile(player.GetSource_FromThis(), player.position, UtilsAI.VelocityToPoint(player.position, moveto * 16, 4f), ModContent.ProjectileType<QuicksilverMirrorP>(), 0, 0f);
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MirrorRim>());
            recipe.AddIngredient(ModContent.ItemType<Quicksilver>(), 3);
            recipe.Register();
        }
    }
}