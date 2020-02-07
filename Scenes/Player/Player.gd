class_name Player
extends KinematicBody2D

const ACTION_STATES := [
  {
    ACTION = "ui_left",
    ANIMATION = "side",
    FLIP_H = false,
  },
  {
    ACTION = "ui_right",
    ANIMATION = "side",
    FLIP_H = true,
  },
  {
    ACTION = "ui_up",
    ANIMATION = "back",
  },
  {
    ACTION = "ui_down",
    ANIMATION = "front",
  }
]

func _process(_delta) -> void:
  for action in ACTION_STATES:
    if Input.is_action_pressed(action.ACTION):
      $AnimationPlayer.play(action.ANIMATION)
      if(action.has("FLIP_H")):
        $Sprite.flip_h = action.FLIP_H
