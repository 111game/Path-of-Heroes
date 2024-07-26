using Godot;
using System;
using System.Collections.Generic;
public partial class Wall : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	List<int> tLIs=new List<int>();
	double time=0;
	public Wall()
	{
		
		GD.Print("Wall Wall");
	}
    public override void _EnterTree()
    {
        base._EnterTree();
		GD.Print("Wall enter");
    }
    public override void _Ready()
	{
		GD.Print("Wall Ready");
		Ball tBall=GetTree().Root.GetChild(0).GetNode<Ball>("Ball2");//GetTree().Root.
		GD.Print(tBall);
		if(tBall!=null)
		{
			GD.Print("ok get it");
		}
		this.ProcessMode=ProcessModeEnum.Disabled;
		Visible=false;
		
		//SetNodeActive(this,false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		time+=delta;
		if(time>1)
		{
			time=0;
			GD.Print("11ok process");
		}
	}

	    // 控制节点及其子节点的启用/禁用
}
/*     private void SetNodeActive(Node2D node, bool active)
    {
		node.Visible = active;  // 控制可见性
        node.SetProcess(active);  // 控制 _Process 回调
        node.SetPhysicsProcess(active);  // 控制 _PhysicsProcess 回调
        node.SetProcessInput(active);  // 控制 _Input 回调
        node.SetProcessUnhandledInput(active);  // 控制 _UnhandledInput 回调
        node.SetProcessUnhandledKeyInput(active);  // 控制 _UnhandledKeyInput 回调

        // 如果节点有物理体，则禁用其物理处理
        if (node is CollisionShape2D collisionObject)
        {
            collisionObject.SetDeferred("disabled", !active);
        }

        // 递归处理所有子节点
        foreach (Node2D child in node.GetChildren())
        {
            SetNodeActive(child, active);
        }
    }
 */