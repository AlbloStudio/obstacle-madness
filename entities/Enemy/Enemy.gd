extends KinematicBody2D

export var speed := 600

var _velocity := Vector2.ZERO


func _physics_process(_delta) -> void:
	_velocity = Vector2.ZERO
	_velocity = move_and_slide(_velocity.normalized() * speed)


