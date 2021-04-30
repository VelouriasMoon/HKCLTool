# HKCLTool

Merger tool for hkcl files based off the HKX2 libaray.

usage:\
merging: `hkcltool [--merge/-m] [json/hku/hknx] [hkcl to merge into] [hkcl to merge from] [list of cloth indexes]`\
listing: `hkcltool [--list/-l] [hkcl or json]`\
bones: `hkcltool [--bonelist/-bl] [hkcl or json]`\
removing: `hkcltool [--remove/-r] [json/hku/hknx] [hkcl or json] [index to remove]`\
converting platform: `hkcltool [--export/-e] [json/hku/hknx] [hkcl or json]`

example:\
to add the 2 scarf physics from the stealth head to hylian upper and export them for the wii u\
`hkcltool -m hku Armor_001_Upper.hkcl Armor_012_Head_A.hkcl 4 5`

### Visual Examples

Tail physics added to Link's base mesh:\
![Tail](ExamplePictures/TailPhysics.gif?raw=true)

Cape physics added to a head mesh with hair:\
![Cape](ExamplePictures/CapePhysics.gif?raw=true)

Fin Physics and Hair physics spilt on the zora helmet:\
![Hair](ExamplePictures/HairPhysics.gif?raw=true)

### Credits
[HKX2](https://github.com/krenyy/HKX2) - havok library\
[HKXConvert](https://github.com/krenyy/HKXConvert) - code base and examples on how to handle hkx files
