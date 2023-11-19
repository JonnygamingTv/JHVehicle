# JHVehicle
Unturned RocketMod Vehicle Plugin


Jump out of vehicle at speed -> actions provided in configuration

```xml
<?xml version="1.0" encoding="utf-8"?>
<Config xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <JustLastEffect>false</JustLastEffect>
  <StaminaBeforeHealth>false</StaminaBeforeHealth>
  <MinSpeed>3</MinSpeed>
  <InvertIfBelow>0</InvertIfBelow>
  <Multiplier>1.7</Multiplier>
  <Stances>
    <Stance Speed="2" StanceName="CROUCH" />
    <Stance Speed="12" StanceName="PRONE" />
  </Stances>
  <Effects>
    <Effect Speed="5" BreakLegs="true" Bleed="false" />
    <Effect Speed="15" BreakLegs="true" Bleed="true" />
    <Effect Speed="70" BreakLegs="true" Bleed="true" />
  </Effects>
</Config>
```

`<JustLastEffect>false</JustLastEffect>` Will only the last and worst action happen?

`<StaminaBeforeHealth>false</StaminaBeforeHealth>` Remove stamina before removing health from the player?

`<MinSpeed>3</MinSpeed>` Minimum speed to take any action.

`<InvertIfBelow>0</InvertIfBelow>` if going backwards, invert.

`<Multiplier>1.7</Multiplier>` Multiply speed.

`<Stance Speed="2" StanceName="CROUCH" />` If going above 2 speed, crouch.

`<Stance Speed="12" StanceName="PRONE" />` If going above 12 speed, prone.

`<Effect Speed="5" BreakLegs="true" Bleed="false" />` If going above 5 speed, break legs, but don't start bleeding.

`<Effect Speed="15" BreakLegs="true" Bleed="true" />` If going above 15 speed, break legs, and start bleeding.
