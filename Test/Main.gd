extends Node

@export var Ball: PackedScene

func _input(event):
	if event.is_action_pressed("click"):
		var new_ball = Ball.instantiate()
		#var mouse_position = get_viewport().get_mouse_position()
		#var camera = get_viewport().get_camera_2d()  # 获取 Camera2D 节点
		#var world_position = (mouse_position/camera.zoom - camera.position)

		var pos=get_viewport().get_camera_2d().get_global_mouse_position()
		print(pos)
		new_ball.global_position = pos		
		#print(world_position.x)
		#print(world_position.y)
		#print(camera.position)
		add_child(new_ball)
		#var mouse_position = get_viewport().get_mouse_position()
		#var camera = get_viewport().get_camera_2d()
		#var world_position = camera.pos(mouse_position)
		#new_ball.global_position = world_position

		


func _On_Mounse_Enter():
	pass # Replace with function body.


func _on_mouse_enter():
	pass # Replace with function body.
