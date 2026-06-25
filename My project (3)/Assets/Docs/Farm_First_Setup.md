# Farm First Setup

## Current Goal

Build the first playable prototype:

1. Player moves in a top-down map.
2. Player attacks with a sword.
3. Player gathers items from animals, trees, rocks, and crystals.
4. Player enters a small dungeon.
5. Player fights slimes, plant monsters, and an orc.
6. Player crafts a dungeon key or recovery item.

## Imported Assets

Source assets are under:

- `Assets/Art/_Source/CraftPix`
- `Assets/Audio/_Source/Kenney`

Use these as source folders. Build actual prefabs and scene objects under:

- `Assets/Prefabs`
- `Assets/Scenes`
- `Assets/ScriptableObjects`

## First Unity Steps

1. Create `Assets/Scenes/Main.unity`.
2. Create a Player prefab with:
   - `Rigidbody2D`
   - `Collider2D`
   - `PlayerController2D`
   - `InteractionController`
   - `Inventory`
   - `Health`
   - `MeleeAttack2D`
3. Add a Camera with `CameraFollow2D`.
4. Make a simple grass test map.
5. Add one `Gatherable` object and one `ItemData`.
6. Add one slime enemy with:
   - `Rigidbody2D`
   - `Collider2D`
   - `Health`
   - `SimpleEnemyChase`
   - `DamageOnContact`

## Script Controls

- Move: WASD or arrow keys
- Attack: Space
- Interact: E

## Notes

The project display name has been changed to `Farm` in Project Settings.
