extends KinematicBody2D

const Bullet = preload("res://entities/Bullet/Bullet.tscn")
const DIRECTIONS = preload("./constants/directions.gd").DIRECTIONS

export var speed := 600
export var bullets_per_second := 2

var _velocity := Vector2.ZERO
var _current_direction = DIRECTIONS[0] setget set_current_direction
var _shoot_timer := 1.0 / bullets_per_second
var _is_shooting := false;

func _physics_process(delta: float) -> void:
	handle_movement()
	handle_shooting(delta)


func handle_shooting(delta: float) -> void:
	_shoot_timer += delta
	if is_time_to_shoot():
			shoot()
			_shoot_timer = 0

	if Input.is_action_just_pressed("shoot"):
		_is_shooting = true
	elif Input.is_action_just_released("shoot"):
		_is_shooting = false;


func shoot() -> void:
	var bullet = Bullet.instance()
	get_parent().add_child(bullet)
	bullet.start(position)


func is_time_to_shoot() -> bool:
	return _is_shooting and _shoot_timer > 1.0 / bullets_per_second


func handle_movement() -> void:
	_velocity = Vector2.ZERO
	set_speed_and_animation()
	_velocity = move_and_slide(_velocity.normalized() * speed)


func should_change_animation(animation: String) -> bool:
	return not _current_direction.ANIMATION == animation


func should_flip(direction) -> bool:
	return direction.has("FLIP_H") and not $Sprite.flip_h == direction.FLIP_H


func set_current_direction(direction) -> void:
	if should_change_animation(direction.ANIMATION):
		_current_direction = direction
		$AnimationPlayer.play(direction.ANIMATION)

	if(should_flip(direction)):
		$Sprite.flip_h = direction.FLIP_H


func set_speed_and_animation() -> void:
	for direction in DIRECTIONS:
		if Input.is_action_pressed(direction.ACTION):
			set_current_direction (direction)
			_velocity += direction.DIRECTION


