using Godot;
using System;

public class LookUpScript : Sprite{
    private Image imageRaw;
    [Export] private Texture imageLookupText;

    public override void _Ready(){
        var imageLookup = imageLookupText.GetData();
        imageRaw = Texture.GetData();
        imageLookup.Lock();
        imageRaw.Lock();
        // imageRaw.Lock();
        for (int y = 0; y < 8; y++){
            for (int x = 0; x < 8; x++){
                // GD.Print(; 
                var _c = imageRaw.GetPixel(x,y) * 255;
                var color = imageLookup.GetPixel((int)_c.r,(int)_c.g);
                imageRaw.SetPixel(x,y,color);
            }
        }
        var t = new ImageTexture();
        t.CreateFromImage(imageRaw, 0);
        Texture = t;
    }
}
    