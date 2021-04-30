# HKCLTool
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/donate?hosted_button_id=7LVCJCM9LNQ2W)

Editing tool for hkcl files using the HKX2 libaray.\
hkcl research done by [Moonling](https://github.com/VelouriasMoon), special thanks to [sofiahxrley](https://github.com/sofiahxrley) for testing.

#### usage:
merging: `hkcltool [--merge/-m] [json/hku/hknx] [base hkcl] [reference hkcl] [cloth indexes]`\
listing: `hkcltool [--list/-l] [hkcl or json]`\
bones: `hkcltool [--bonelist/-bl] [hkcl or json]`\
removing: `hkcltool [--remove/-r] [json/hku/hknx] [hkcl or json] [index to remove]`\
converting platform: `hkcltool [--export/-e] [json/hku/hknx] [hkcl or json]`

#### example:
to add the 2 scarf physics from the stealth head to hylian upper and export them for the wii u\
`hkcltool -m hku Armor_001_Upper.hkcl Armor_012_Head_A.hkcl 4 5`

### Credits
[HKX2](https://github.com/krenyy/HKX2) - havok library\
[HKXConvert](https://github.com/krenyy/HKXConvert) - code base and examples on how to handle hkx files\
[Json.NET](https://www.newtonsoft.com/json)

### Visual Examples

Tail physics added to Link's base mesh:\
![Tail](ExamplePictures/TailPhysics.gif?raw=true)

Cape physics added to a head mesh with hair:\
![Cape](ExamplePictures/CapePhysics.gif?raw=true)

Fin Physics and Hair physics spilt on the zora helmet:\
![Hair](ExamplePictures/HairPhysics.gif?raw=true)
