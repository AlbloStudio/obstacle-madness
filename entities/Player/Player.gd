class_name Player
extends KinematicBody2D

export var speed := 600

onready var _velocity := Vector2.ZERO
onready var _current_animation : String = ACTION_STATES[0].ANIMATION;


const ACTION_STATES := [
  {
    ACTION = "ui_left",
    ANIMATION = "side",
    FLIP_H = false,
    DIRECTION = Vector2(-1, 0)
  },
  {
    ACTION = "ui_right",
    ANIMATION = "side",
    FLIP_H = true,
    DIRECTION = Vector2(1, 0)
  },
  {
    ACTION = "ui_up",
    ANIMATION = "back",
    DIRECTION = Vector2(0, -1)
  },
  {
    ACTION = "ui_down",
    ANIMATION = "front",
    DIRECTION = Vector2(0, 1)
  }
]

func should_change_animation(animation: String) -> bool:
  return not _current_animation == animation

func should_flip(action) -> bool:
  return action.has("FLIP_H") and not $Sprite.flip_h == action.FLIP_H

func set_animation(action) -> void:
  if should_change_animation(action.ANIMATION):
    _current_animation = action.ANIMATION
    $AnimationPlayer.play(action.ANIMATION)

  if(should_flip(action)):
    $Sprite.flip_h = action.FLIP_H

func set_speed_and_animation() -> void:
  for action in ACTION_STATES:
    if Input.is_action_pressed(action.ACTION):
      set_animation(action)
      _velocity += action.DIRECTION

func _physics_process(_delta: float) -> void:
  _velocity = Vector2.ZERO
  set_speed_and_animation()
  _velocity = move_and_slide(_velocity.normalized() * speed)
