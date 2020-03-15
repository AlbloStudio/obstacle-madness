extends KinematicBody2D


const DIRECTIONS = preload("./constants/directions.gd").DIRECTIONS

export var speed := 600

var _velocity := Vector2.ZERO
var _current_direction = DIRECTIONS[0] setget set_current_direction


func _physics_process(_delta) -> void:
	handle_movement()


func handle_movement() -> void:
	_velocity = Vector2.ZERO
	set_speed_and_animation()
	_velocity = move_and_slide(_velocity.normalized() * speed)


func should_change_animation(animation: String) -> bool:
	return !$AnimationPlayer.is_playing() or not _current_direction.ANIMATION == animation


func should_flip(direction) -> bool:
  return direction.has("FLIP_H") and not $Sprite.flip_h == direction.FLIP_H


func set_current_direction(direction) -> void:
	_current_direction = direction
	$AnimationPlayer.play(direction.ANIMATION)

	if(should_flip(direction)):
		$Sprite.flip_h = direction.FLIP_H


func set_speed_and_animation() -> void:
	var input_pressed = false

	for direction in DIRECTIONS:
		if Input.is_action_pressed(direction.ACTION):
			_velocity += direction.DIRECTION
			if(not input_pressed):
				set_current_direction(direction)
				input_pressed = true
			
	if(not input_pressed):
		$AnimationPlayer.stop(false)



