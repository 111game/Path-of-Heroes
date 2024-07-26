using Godot;
using System;

public partial class MyObject : Sprite2D
{
	AnimationPlayer mAnimationPlayer = null;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mAnimationPlayer=GetNode<AnimationPlayer>("AnimationPlayer");
		if(mAnimationPlayer!=null)
		{
			// mAnimationPlayer.Autoplay="stand";
			mAnimationPlayer.Play("stand");

			GD.Print("animation play");
		}
		// ProcessMode=ProcessModeEnum.Disabled;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
