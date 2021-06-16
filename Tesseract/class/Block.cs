using System;
using System.Collections.Generic;
using Tesseract;

public class Block
{
    public int PositionX1 { get; set; }
    public int PositionY1 { get; set; }

    public int PositionX2 { get; set; }
    public int PositionY2 { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public string Text { get; set; }
    public string Type { get; set; }
    public List<Block> Children { get; set; }
    public float Confidence { get; set; }



    public Block()
    {

    }

    public Block(Rect rect)
    {
        PositionX1 = rect.X1;
        PositionY1 = rect.Y1;
        PositionX2 = rect.X2;
        PositionY2 = rect.Y2;
        Height = rect.Height;
        Width = rect.Width;
    }
}
