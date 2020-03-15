extends KinematicBody2D

func _physics_process(delta: float) -> void:
	var parent = get_parent()

	var velocity = parent.direction * delta * parent.speed
	var collision = move_and_collide(velocity)
	if collision:
		queue_free()

