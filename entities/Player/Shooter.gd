extends Node

const Bullet = preload("res://entities/Bullet/Bullet.tscn")
const bullet_separation = 60

export var bullets_per_second := 2

var _player: Node2D
var _scene: Node
var _shoot_timer := 1.0 / bullets_per_second
var _is_shooting := false;

func _ready() -> void:
	_player = get_parent()
	_scene = _player.get_parent()


func _process(delta: float) -> void:
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
	var mouse_position = _scene.get_global_mouse_position()
	var bullet = Bullet.instance()
	_scene.add_child(bullet)
	
	var bullet_direction = (mouse_position - _player.position).normalized()
	var bullet_start_position = _player.position + (bullet_direction * bullet_separation)
	bullet.start(bullet_start_position)


func is_time_to_shoot() -> bool:
	return _is_shooting and _shoot_timer > 1.0 / bullets_per_second



