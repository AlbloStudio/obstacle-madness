extends Node2D

export var speed:= 800

var direction := Vector2.ZERO


func _process(delta: float) -> void:
	$Smoke.position += direction * delta * speed/2.5

func start(source: Vector2, direction: Vector2) -> void:
	self.direction = direction
	position = source

	_start_smoke()
	_start_bullet()

func _start_smoke() -> void:
	$Smoke.emitting = true
	$Smoke.one_shot = true

func _start_bullet() -> void:
	$Bullet/Sprite.rotate(direction.angle())
