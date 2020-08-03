# Chemistry

## Preamble

When creating our first game, Candy Raid: The Factory, we kept it deliberately simple since it was out first game. It was linear, straight forward and mechanically simple.

Chemistry (working title) instead takes the opposite approach - it is complex and multilayered, with many secrets and hidden game elements; that's the goal at least. This game design document is intended to outline a plan for ourselves, so that we're not blindly groping in the darkness.

The game is heavily inspired by The Legend of Zelda (1986), and The Legend of Zelda: Breath of the Wild (2017). This inspiration goes beyond the gameplay - the opening area deliberately mimics the first screen of the first game in the LoZ series.

Chemistry is a systemic game, with many interacting systems permiating the game world. An exmaple of this is the heat system - combustible objects in the world catch fire when the temperature rises beyond a threshold. There is also light, which is affected by the day/night cycle.

---

## Premise

The seal that contains the king of evil is weakening, causing monsters to appear across the land. As a direct descendant of the hero of legend, your older brother was sent to gather the three dragon pendants and reinforce the seal. However, during his quest, he vanished. Now that you've come of age at 13, the task falls to you...

## Basic Gameplay

Players begin the game in a simple outdoor screen, with no instructions.

Players can move between screens (triggering a screen transition in the process) in the overworld, and can enter caves or dungeons; caves/dungeons can also consist of more than one screen.

Players have the ability to pick up a tool, swap their current tool for another, or drop their current tool, all with the same button. Players can also use their current tool (with a separate button), each of which has a unique effect based on it's type.

As the game progresses, the player may find upgrades that alter gameplay slightly, such as a sheath allowing them to carry and swap between a second tool, a shield or reflective shield which can reflect light, a bomb bag allowing them to carry bombs, magic wands that can cast elemental spells, etc. No upgrade is strictly necessary to beat the game.

---

## Interlocking Systems

There are a number of interlocking systems that items in the world, and the world itself, interact with.

### Light

The lighting in the game world can vary, depending on the time of day, weather conditions, and other effects. Torches can be used to produce light in a limited amount, but this takes up the tool slot in the player's inventory. Fire of any kind produces light and heat.

### Heat

The temperature of the world can be affected by a number of things, such as the presence of fire or monsters that freeze the ground.

---

## Tools List

These are a list of items that are considered "tools".

### Stick
- Can hit things
- Breaks easily
- Can be lit into a [Torch](#torch)
- Can be crafted into a [Wood Sword](#wood-sword)

### Torch
- Produces light
- Can set things on fire

### Wood Sword
- Can be crafted from a [Stick](#stick)
- Can hit things
- Breaks easily

### Sword
- Costs money to buy
- Can hit things
- Stronger than a [Wood Sword](#wood-sword)

### Bomb
- Crafted from [Ash](#ash) and [Strange Powder](#strange-powder)
- Can explode and damage walls
- Multiple can be carried in a bomb bag

---

## Materials

These are a list of items that are considered "materials".

### Ash
- Created from burning static objects like [Bushes](#bush)

### Strange Powder
- Dropped from [Ghosts](#ghost)

### Meat
- Can't be eaten raw
- Can be crafted into [Cooked Meat](#cooked-meat)

### Cooked Meat
- Crafted from [Meat](#meat)
- Can be eaten to refill health

---

## Static Objects

This is a list of static objects in the world that may interact with various systems.

### Bush
- Can catch fire, producing [Ash](#ash)

### Breakable Wall
- Can be broken by damage (i.e. from a [Bomb](#bomb))

### Hidden Breakable Wall
- Indistinguishable from a normal wall
- Can be broken by damage (i.e. from a [Bomb](#bomb))

---

## Monsters

This is a list of monsters that exist in the world, and their behaviours.

### NPC
- Non-Player Characters who can be talked with

### Ghost
- Scared of light
- Drops [Strange Powder](#strange-powder) on death

### Wolf
- Fur burns
- Drops [Meat](#meat) or [Cooked Meat](#cooked-meat) on death

---

## Technical Specifications

This game must run on the Nintendo Switch hardware, as well as Windows and Linux Desktops.

### Scalar Fields

A "scalar field" is a grid of objects that covers the 2D world, where each cell in the grid has a value. The values can be set by emitters, and utilized by receptors. Multiple scalar fields can be layered on top of each other.

### InputLayer class

The InputLayer class is designed to support any kind of target hardware internally, wrapping the differences in a simple API. Any vibration features used by the Nintendo Switch might be implemented within the InputLayer, but this is hacky and sub-optimal.

---

## Ideas

Ice Cavern, with sliding ice floors. The temperature here is permanently below freezing, causing damage to the player unless they have something to mitigate it.

Water temple, after some kind of water mechanic is implemented.

Poison gas, utilizing scalar fields, produced by monsters or spells.

"Mana", fuel for spells, which is collected from a scalar field.

Dungeon that changes based on the time of day.

