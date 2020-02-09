extends KinematicBody2D

const Bullet = preload("res://entities/Bullet/Bullet.tscn")
const DIRECTIONS = preload("./constants/directions.gd").DIRECTIONS

export var speed := 600

onready var _velocity := Vector2.ZERO
onready var _current_direction = DIRECTIONS[0] setget set_current_direction


func _physics_process(_delta: float) -> void:
  _velocity = Vector2.ZERO
  set_speed_and_animation()
  _velocity = move_and_slide(_velocity.normalized() * speed)
  
  if(Input.is_action_just_pressed("shoot")):
    var bullet = Bullet.instance()
    get_parent().add_child(bullet)
    bullet.start(position)


func should_change_animation(animation: String) -> bool:
  print(animation)
  return not _current_direction.ANIMATION == animation


func should_flip(direction) -> bool:
  return direction.has("FLIP_H") and not $Sprite.flip_h == direction.FLIP_H


func set_current_direction(direction) -> void:
  print(direction)
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


