using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;

namespace Bismuth.Utilities
{
	public class OrcUtils
	{
		public bool HitTileOnSide(Entity codable, int dir, bool noYMovement = true)
		{
			if (!noYMovement || codable.velocity.Y == 0f)
			{
				Vector2 dummyVec = default(Vector2);
				return HitTileOnSide(codable.position, codable.width, codable.height, dir, ref dummyVec);
			}
			return false;
		}

		public void WalkupHalfBricks(NPC npc)
		{
			WalkupHalfBricks(npc, ref npc.gfxOffY, ref npc.stepSpeed);
		}

		public int GetFirstTileCeiling(int x, int startY, bool solid = true)
		{
			for (int y = startY; y > 0; y--)
			{
				Tile tile = Main.tile[x, y];
				if (tile != null && tile.HasUnactuatedTile && (!solid || Main.tileSolid[(int)tile.TileType])) { return y; }
			}
			return 0;
		}

		public void WalkupHalfBricks(Entity codable, ref float gfxOffY, ref float stepSpeed)
		{
			if (codable.velocity.Y >= 0.0f)
			{
				int offset = 0;
				if (codable.velocity.X < 0.0f) offset = -1;
				if (codable.velocity.X > 0.0f) offset = 1;
				Vector2 pos = codable.position;
				pos.X += codable.velocity.X;
				int tileX = (int)(((double)pos.X + (double)(codable.width / 2) + (double)((codable.width / 2 + 1) * offset)) / 16.0);
				int tileY = (int)(((double)pos.Y + (double)codable.height - 1.0) / 16.0);
				Tile tile = Main.tile[tileX, tileY];
                Tile tile1 = Main.tile[tileX, tileY - 1];
                Tile tile2 = Main.tile[tileX, tileY - 2];
                Tile tile3 = Main.tile[tileX, tileY - 3];
                Tile tile4 = Main.tile[tileX, tileY + 1];
				Tile tile5 = Main.tile[tileX - offset, tileY - 3];
                if (Main.tile[tileX, tileY] == null) tile = new Tile();
				if (Main.tile[tileX, tileY - 1] == null) tile1 = new Tile();
				if (Main.tile[tileX, tileY - 2] == null) tile2 = new Tile();
				if (Main.tile[tileX, tileY - 3] == null) tile3 = new Tile();
				if (Main.tile[tileX, tileY + 1] == null) tile4 = new Tile();
				if (Main.tile[tileX - offset, tileY - 3] == null) tile5 = new Tile();
				if ((double)(tileX * 16) < (double)pos.X + (double)codable.width && (double)(tileX * 16 + 16) > (double)pos.X && (Main.tile[tileX, tileY].HasUnactuatedTile && (int)Main.tile[tileX, tileY].Slope == 0 && ((int)Main.tile[tileX, tileY - 1].Slope == 0 && Main.tileSolid[(int)Main.tile[tileX, tileY].TileType]) && !Main.tileSolidTop[(int)Main.tile[tileX, tileY].TileType] || Main.tile[tileX, tileY - 1].IsHalfBlock && Main.tile[tileX, tileY - 1].HasUnactuatedTile) && ((!Main.tile[tileX, tileY - 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 1].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 1].TileType] || Main.tile[tileX, tileY - 1].IsHalfBlock && (!Main.tile[tileX, tileY - 4].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 4].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 4].TileType])) && ((!Main.tile[tileX, tileY - 2].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 2].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 2].TileType]) && (!Main.tile[tileX, tileY - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY - 3].TileType] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 3].TileType]) && (!Main.tile[tileX - offset, tileY - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX - offset, tileY - 3].TileType]))))
				{
					float tileWorldY = (float)(tileY * 16);
					if (Main.tile[tileX, tileY].IsHalfBlock)
						tileWorldY += 8.0f;
					if (Main.tile[tileX, tileY - 1].IsHalfBlock)
						tileWorldY -= 8.0f;
					if ((double)tileWorldY < (double)pos.Y + (double)codable.height)
					{
						float tileWorldYHeight = pos.Y + (float)codable.height - tileWorldY;
						float heightNeeded = 16.1f;
						if ((double)tileWorldYHeight <= (double)heightNeeded)
						{
							gfxOffY += codable.position.Y + (float)codable.height - tileWorldY;
							codable.position.Y = tileWorldY - (float)codable.height;
							stepSpeed = (double)tileWorldYHeight >= 9.0 ? 2.0f : 1.0f;
						}
					}
					else
						gfxOffY = Math.Max(0f, gfxOffY - stepSpeed);
				}
				else
					gfxOffY = Math.Max(0f, gfxOffY - stepSpeed);
			}
			else
				gfxOffY = Math.Max(0f, gfxOffY - stepSpeed);
		}

		public bool HitTileOnSide(Vector2 position, int width, int height, int dir, ref Vector2 hitTilePos)
		{
			try
			{
				int tilePosX = 0;
				int tilePosY = 0;
				int tilePosWidth = 0;
				int tilePosHeight = 0;
				if (dir == 0)
				{
					tilePosX = (int)(position.X - 8.0f) / 16;
					tilePosY = (int)position.Y / 16;
					tilePosWidth = tilePosX + 1;
					tilePosHeight = (int)(position.Y + (float)height) / 16;
				}
				else if (dir == 1)
				{
					tilePosX = (int)(position.X + (float)width + 8.0f) / 16;
					tilePosY = (int)position.Y / 16;
					tilePosWidth = tilePosX + 1;
					tilePosHeight = (int)(position.Y + (float)height) / 16;
				}
				else if (dir == 2)
				{
					tilePosX = (int)position.X / 16;
					tilePosY = (int)(position.Y - 8.0f) / 16;
					tilePosWidth = (int)(position.X + (float)width) / 16;
					tilePosHeight = tilePosY + 1;
				}
				else if (dir == 3)
				{
					tilePosX = (int)position.X / 16;
					tilePosY = (int)(position.Y + (float)height + 8.0f) / 16;
					tilePosWidth = (int)(position.X + (float)width) / 16;
					tilePosHeight = tilePosY + 1;
				}
				for (int x2 = tilePosX; x2 < tilePosWidth; x2++)
				{
					for (int y2 = tilePosY; y2 < tilePosHeight; y2++)
					{
						if (Main.tile[x2, y2] == null) { return false; }
						if (Main.tile[x2, y2].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[x2, y2].TileType])
						{
							hitTilePos = new Vector2(x2, y2);
							return true;
						}
					}
				}
			}
			catch { }
			return false;
		}

		public Vector2 AttemptJump(Vector2 position, Vector2 velocity, int width, int height, int direction, float directionY = 0, int tileDistX = 3, int tileDistY = 4, float maxSpeedX = 1f, bool jumpUpPlatforms = false, Entity target = null, bool ignoreTiles = false)
		{
			tileDistX -= 2;
			Vector2 newVelocity = velocity;
			int tileX = Math.Max(5, Math.Min(Main.maxTilesX - 5, (int)((position.X + (width * 0.5f) + (float)(((width * 0.5f) + 8.0f) * direction)) / 16.0f)));
			int tileY = Math.Max(5, Math.Min(Main.maxTilesY - 5, (int)((position.Y + (float)height - 15.0f) / 16.0f)));
			int tileItX = Math.Max(5, Math.Min(Main.maxTilesX - 5, tileX + (direction * tileDistX)));
			int tileItY = Math.Max(5, Math.Min(Main.maxTilesY - 5, tileY - tileDistY));
			int lastY = tileY;
			int tileHeight = (int)(height / 16.0f);
			if (height > tileHeight * 16) { tileHeight += 1; }
			Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, width, height);
			if (ignoreTiles && target != null && Math.Abs((position.X + (width * 0.5f)) - target.Center.X) < width + 120)
			{
				float dist = (int)Math.Abs(position.Y + ((float)height * 0.5f) - target.Center.Y) / 16;
				if (dist < tileDistY + 2) { newVelocity.Y = -8.0f + (dist * -0.5f); }
			}
			if (newVelocity.Y == velocity.Y)
			{
				for (int y = tileY; y >= tileItY; y--)
				{
					Tile tile = Main.tile[tileX, y];
					Tile tileNear = Main.tile[Math.Min(Main.maxTilesX, tileX - direction), y];
					if (tile == null) { tile = new Tile(); }
					if (tileNear == null) { tileNear = new Tile(); }
					if (tile.HasUnactuatedTile && (y != tileY || (!tile.IsHalfBlock && tile.Slope == 0)) && Main.tileSolid[tile.TileType] && (jumpUpPlatforms || !Main.tileSolidTop[tile.TileType]))
					{
						if (!Main.tileSolidTop[tile.TileType])
						{
							Rectangle tileHitbox = new Rectangle(tileX * 16, y * 16, 16, 16);
							tileHitbox.Y = hitbox.Y;
							if (tileHitbox.Intersects(hitbox)) { newVelocity = velocity; break; }
						}
						if (tileNear.HasUnactuatedTile && Main.tileSolid[tileNear.TileType] && !Main.tileSolidTop[tileNear.TileType]) { newVelocity = velocity; break; }
						if (target != null && y * 16 < target.Center.Y) { continue; }
						lastY = y;
						newVelocity.Y = -(5.0f + (float)(tileY - y) * (tileY - y > 3 ? 1.0f - ((tileY - y - 2) * 0.0525f) : 1.0f));
					}
					else
					if (lastY - y >= tileHeight) { break; }
				}
			}
			if (newVelocity.Y == velocity.Y)
			{
				Tile tile = Main.tile[tileX, tileY + 1];
                Tile tile1 = Main.tile[tileX, tileY + 2];
                if (Main.tile[tileX, tileY + 1] == null) { tile = new Tile(); }
				if (Main.tile[tileX + direction, tileY + 1] == null) { tile = new Tile(); }
				if (Main.tile[tileX + direction, tileY + 2] == null) { tile1 = new Tile(); }
				if (directionY < 0 && (!Main.tile[tileX, tileY + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY + 1].TileType]) && (!Main.tile[tileX + direction, tileY + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX + direction, tileY + 1].TileType]))
				{
					if (!Main.tile[tileX + direction, tileY + 2].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[tileX, tileY + 2].TileType] || (target == null || ((target.Center.Y + (target.height * 0.25f)) < tileY * 16f)))
					{
						newVelocity.Y = -3.0f;
						newVelocity.X *= 1.5f * (1.0f / maxSpeedX);
						if (tileX <= tileItX)
						{
							for (int x = tileX; x < tileItX; x++)
							{
								Tile tiles = Main.tile[x, tileY + 1];
                                if (tile == null) { tiles = new Tile(); }
								if (x != tileX && !tile.HasUnactuatedTile)
								{
									newVelocity.Y -= 0.0325f;
									newVelocity.X += direction * 0.255f;
								}
							}
						}
						else
						if (tileX > tileItX)
						{
							for (int x = tileItX; x < tileX; x++)
							{
								Tile tiled = Main.tile[x, tileY + 1];
								Tile tile1d = Main.tile[x, tileY + 2];
                                if (tiled == null) { tile1d = new Tile(); }
								if (x != tileItX && !tile.HasUnactuatedTile)
								{
									newVelocity.Y -= 0.0325f;
									newVelocity.X += direction * 0.255f;
								}
							}
						}
					}
				}
			}
			return newVelocity;
		}

		public void RedundantFunc()
		{
			var something = Enumerable.Range(1, 10);
		}
	}
}
