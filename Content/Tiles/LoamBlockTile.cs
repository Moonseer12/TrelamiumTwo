using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumTwo.Content.Tiles
{
    public class LoamBlockTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<LimestoneTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<LoamBlockGrassTile>()] = true;
            dustType = 38;
            mineResist = 0.35f;
            soundType = SoundID.Dig;
            soundStyle = 2;

            AddMapEntry(new Color(78, 31, 39));
        }
        public override void RandomUpdate(int i, int j)
        {
            if (WorldGen.genRand.Next(3) == 0)
            {
                WorldGen.SpreadGrass(i, j, ModContent.TileType<LoamBlockTile>(), ModContent.TileType<LoamBlockGrassTile>(), true, Main.tile[i, j].color());
            }
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
    public class LoamBlockGrassTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.Grass[Type] = true;

            dustType = 39;
            mineResist = 0.35f;
            soundType = SoundID.Grass;
            soundStyle = 2;

            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<LoamBlockTile>();
            Main.tileMerge[Type][ModContent.TileType<LoamBlockTile>()] = true;
            AddMapEntry(new Color(100, 111, 59));
        }
        #region Things that aren't SetDefaults()
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override void RandomUpdate(int i, int j)
        {
            if (WorldGen.genRand.Next(3) == 0)
            {
                WorldGen.SpreadGrass(i, j, ModContent.TileType<LoamBlockTile>(), ModContent.TileType<LoamBlockGrassTile>(), true, Main.tile[i, j].color());
            }
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!effectOnly)
            {
                fail = true;
                Main.tile[i, j].type = (ushort)ModContent.TileType<LoamBlockTile>();
                WorldGen.SquareTileFrame(i, j, true);
                for (int i1 = 0; i1 < 3; i1++)
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 39, 0f, 0f, 0, default, 1.0f);
                }
            }
        }
        #endregion
    }
}