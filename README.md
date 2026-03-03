# CS2 Bhop

Undetected external bhop script for CS2. Simulates mouse scroll down on landing. Hold SPACE to bhop.

## Requirements

- Windows
- .NET 8 SDK — [download](https://dotnet.microsoft.com/download/dotnet/8.0)
- Run as Administrator

## Setup

CS2 console:

> [!NOTE]
> **Important**: Unbind your bhop hold key from +jump in CS2 — otherwise the manual jump and the script's scroll will conflict.
> For example if using SPACE:
> `unbind space`

```
unbind space
bind "mwheeldown" "+jump"
```

## Run

### From code

```
dotnet run
```

### From .exe

1. Start CS2
2. Start cs2-bhop.exe
3. Hold down "SPACE"

## Build .exe

```
dotnet publish -c Release -r win-x64 --self-contained false /p:PublishSingleFile=true
```

Output: `bin\Release\net8.0\win-x64\publish\cs2-bhop.exe`

## Changing the hold key

Default is SPACE (`0x20`). To change, replace `0x20` in `Program.cs` with:

| Key | Code |
|---|---|
| SPACE | `0x20` |
| Left mouse | `0x01` |
| Right mouse | `0x02` |
| Middle mouse | `0x04` |
| Mouse side 1 | `0x05` |
| Mouse side 2 | `0x06` |
| SHIFT | `0x10` |
| CTRL | `0x11` |
| ALT | `0x12` |
| CAPS LOCK | `0x14` |

Full list: [Virtual Key Codes](https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes)

## Disclaimer

For educational and private server use only. Using on VAC-secured servers may result in a ban. Use at your own risk.
