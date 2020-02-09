extends Area2D

export var speed:= 800

var _normalized_mouse_position:= Vector2.ZERO


func _process(delta: float) -> void:
	position += _normalized_mouse_position * delta * speed


func start(source: Vector2) -> void:
	position = source
	_normalized_mouse_position = (get_global_mouse_position() - position).normalized()
