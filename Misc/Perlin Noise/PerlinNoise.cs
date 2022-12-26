using Godot;
using System;

public class PerlinNoise : Sprite{
    [Export] int octaves;
    [Export] int period;
    [Export] float persistence;

    public override void _Ready(){
        var noise = new OpenSimplexNoise();
        noise.Seed = (int)GD.Randi();
        noise.Octaves = octaves;
        noise.Period = period;
        noise.Persistence = persistence;
        var noise_image = noise.GetImage(512, 512);
        var texture = new ImageTexture();
        texture.CreateFromImage(noise_image);
        Texture = texture;
    }
}
