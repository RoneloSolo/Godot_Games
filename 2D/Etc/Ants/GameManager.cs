using Godot;
using System;

[Tool]
public class GameManager : Node2D{
	private Sprite sprite;

	[Export] int octaves;
	[Export] int period;
	[Export] float persistence;
	[Export] Gradient gradient;

	public override void _Ready(){
		sprite = GetNode<Sprite>("Sprite");
		var noise = new OpenSimplexNoise();
		noise.Seed = (int)GD.Randi();
		noise.Octaves = octaves;
		noise.Period = period;
		noise.Persistence = persistence;
		var noise_image = noise.GetImage(512, 512);
		var texture = new ImageTexture();
		texture.CreateFromImage(noise_image);
		sprite.Texture = texture;
	}
}
