using Godot;
using System;

public partial class Ball : RigidBody2D
{
	int mSpeed=100;
	private bool collided = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// LinearVelocity+=new Vector2((float)delta*mSpeed,0);
		//Position+=new Vector2((float)delta*mSpeed,1); //delta*mSpeed;
	}
	public void _on_mounse_enter()
	{
		// GD.Print("1111");
	}

	public void _physics_process(double delta)
	{

		collided=GetContactCount()>0;
		if(collided)
		{
			// 计算运动向量
			Vector2 motion = LinearVelocity * (float)delta;
			// 检测并处理碰撞
			KinematicCollision2D collision = MoveAndCollide(motion);
			if (collision != null)
			{
				// 碰撞反弹
				LinearVelocity = LinearVelocity.Bounce(collision.GetNormal());
			}
		}
		float speed = LinearVelocity.Length();
		if(speed<400)
		{
			LinearVelocity*=1.05F;
		}


	}
}

public class Physics2DDirectBodyState
{
}