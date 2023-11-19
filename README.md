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
