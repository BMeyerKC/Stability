Stability
=========

A simple class to determine the stability of an ongoing sampling

Usage
=====
```
var tempReading = new Stable();
while (!tempReading.IsStable)
{
  tempReading.AddSample(4);
}
return tempReading.StableAverage;
```
