using System.Collections.Generic;
using UnityEngine;

namespace SanctumCorp
{
	public static class MakePoints
	{
		public static Vector3[] GetPoints(Sprite sprite, Transform targetTransform)
		{
			if (sprite == null) return null;
			int width, height;
			var pixels = GetPixels(sprite, out width, out height);
			bool[,] alphaMask = GetAlphaMask(pixels, width, height);
			bool[,] contourMask = ExtractContourMask(alphaMask, width, height);
			var contourPoints = ExtractContourPoints(contourMask, width, height);
			var simplifiedPoints = SimplifyPoints(contourPoints);
			var worldCoordinatePoints = ConvertToWorldPoints(simplifiedPoints, sprite.pivot, targetTransform, sprite.pixelsPerUnit);

			

			GetCoordinates(contourMask, width, height, sprite.pivot, targetTransform, sprite.pixelsPerUnit);
			
			return worldCoordinatePoints.ToArray();
		}


		public static Color[] GetPixels(Sprite sprite, out int width, out int height)
		{
			Texture2D texture = sprite.texture;
			Rect rect = sprite.rect;

			width = Mathf.RoundToInt(rect.width);
			height = Mathf.RoundToInt(rect.height);

			Color[] rectPixels = texture.GetPixels(
				Mathf.RoundToInt(rect.x),
				Mathf.RoundToInt(rect.y),
				width,
				height
			);


			return rectPixels;
		}

		public static bool[,] GetAlphaMask(Color[] pixels, int width, int height, float alphaTreshold = 0.1f)
		{
			bool[,] alphaMask = new bool[width, height];

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Color pixel = pixels[y * width + x];
					alphaMask[x, y] = pixel.a > alphaTreshold;
				}
			}

			Debug.LogError(alphaMask.Length);

			return alphaMask;
		}

		private static List<Vector2Int> ExtractContourPoints(bool[,] contourMask, int width, int height)
		{
			var directions = new Vector2Int[]
			{
		new Vector2Int(1, 0),   // Right
		new Vector2Int(1, 1),   // Top-Right
		new Vector2Int(0, 1),   // Top
		new Vector2Int(-1, 1),  // Top-Left
		new Vector2Int(-1, 0),  // Left
		new Vector2Int(-1, -1), // Bottom-Left
		new Vector2Int(0, -1),  // Bottom
		new Vector2Int(1, -1),  // Bottom-Right
			};

			bool[,] visited = new bool[width, height];
			List<Vector2Int> contour = new List<Vector2Int>();

			// Find first point
			Vector2Int start = new Vector2Int(-1, -1);
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (contourMask[x, y])
					{
						start = new Vector2Int(x, y);
						break;
					}
				}
				if (start.x != -1) break;
			}

			if (start.x == -1) return contour; // No contour

			Vector2Int current = start;
			int dirIndex = 0;

			do
			{
				contour.Add(current);
				visited[current.x, current.y] = true;

				bool foundNext = false;
				// Start from current guide + 6 (backward traverse)
				for (int i = 0; i < 8; i++)
				{
					int index = (dirIndex + i + 6) % 8;
					Vector2Int offset = directions[index];
					Vector2Int neighbor = current + offset;

					if (neighbor.x >= 0 && neighbor.x < width && neighbor.y >= 0 && neighbor.y < height)
					{
						if (contourMask[neighbor.x, neighbor.y] && !visited[neighbor.x, neighbor.y])
						{
							current = neighbor;
							dirIndex = index;
							foundNext = true;
							break;
						}
					}
				}

				if (!foundNext) break; // Cannot move anymore

			} while (current != start && contour.Count < 10000); // Endless loop protected

			return contour;
		}

		private static List<Vector2Int> SimplifyPoints(List<Vector2Int> input)
		{
			if (input.Count < 3) return new List<Vector2Int>(input);

			List<Vector2Int> result = new List<Vector2Int>();
			result.Add(input[0]);

			for (int i = 1; i < input.Count - 1; i++)
			{
				Vector2Int prev = input[i - 1];
				Vector2Int curr = input[i];
				Vector2Int next = input[i + 1];

				Vector2Int dir1 = curr - prev;
				Vector2Int dir2 = next - curr;

				if (dir1.x * dir2.y != dir1.y * dir2.x)
					result.Add(curr);
			}

			result.Add(input[input.Count - 1]);
			return result;
		}

		private static List<Vector3> ConvertToWorldPoints(List<Vector2Int> pixelPoints, Vector2 pivot, Transform transform, float ppu)
		{
			List<Vector3> worldPoints = new List<Vector3>();

			foreach (var p in pixelPoints)
			{
				float localX = (p.x - pivot.x) / ppu;
				float localY = (p.y - pivot.y) / ppu;
				Vector3 localPos = new Vector3(localX, localY);
				worldPoints.Add(localPos);
			}

			return worldPoints;
		}

		public static Vector3[,] GetCoordinates(bool[,] alphaMask, int width, int height, Vector2 pivot, Transform targetTransform, float pixelsPerUnit)
		{
			Vector3[,] points = new Vector3[width, height];

			for (int y = 0; y < height; y++)
			{
				for(int x = 0; x < width; x++)
				{
					if (alphaMask[x, y])
					{
						float localX = (x - pivot.x) / pixelsPerUnit;
						float localY = (y - pivot.y) / pixelsPerUnit;

						Vector3 localPos = new Vector3(localX, localY, 0);

						Vector3 worldPos = targetTransform.TransformPoint(localPos);

						points[x, y] = worldPos;

						Debug.DrawRay(worldPos, Vector3.up * 0.01f, Color.green, 10f);
					}
				}
			}

			return points;
		}

		private static bool IsContourPixel(bool[,] mask, int x, int y, int width, int height)
		{
			if (!mask[x, y]) return false;

			if (x == 0 || !mask[x - 1, y]) return true;
			if (x == width - 1 || !mask[x + 1, y]) return true;
			if (y == 0 || !mask[x, y - 1]) return true;
			if (y == height - 1 || !mask[x, y + 1]) return true;

			return false;
		}

		public static bool[,] ExtractContourMask(bool[,] alphaMask, int width, int height)
		{
			bool[,] contourMask = new bool[width, height];

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					contourMask[x, y] = IsContourPixel(alphaMask, x, y, width, height);
				}
			}

			return contourMask;
		}


	}
}
