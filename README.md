# UnrealZeroMQ
Unreal Engine 5 plugin for ZeroMQ with bindings from [cppzmq](https://github.com/zeromq/cppzmq).

## Usage
1. Copy this repository into the `Plugins` folder of your Unreal project.
2. Verify that the plugin is enabled in the plugin menu inside the Unreal Editor.
3. In your module's build file (`<your project name>.Build.cs`) add `ZeroMQ` to the module dependency list:
```c#
...
PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "ZeroMQ" });
                                                                                     // add this! ^^^^^^^^
...
```
4. Test that it works!
```cpp
# include <zmq.hpp>

...
// place this somewhere it'll be run (e.g. BeginPlay() of your gamemode or similar)
int major, minor, patch;
zmq::version(&major, &minor, &patch);
GEngine->AddOnScreenDebugMessage(-1, 5.f, FColor::Green, FString(TEXT("ZeroMQ version: v")) + FString::FromInt(major) + FString::Printf(TEXT(".")) + FString::FromInt(minor) + FString::Printf(TEXT(".")) + FString::FromInt(patch));
...

```

## Support
* Windows (x64)
