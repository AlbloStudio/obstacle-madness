extends Area2D


export var speed:= 800

var _direction := Vector2.ZERO


func _process(delta: float) -> void:
	position += _direction * delta * speed


func start(source: Vector2, direction: Vector2) -> void:
	position = source
	_direction = direction
