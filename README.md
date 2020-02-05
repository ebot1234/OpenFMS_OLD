# What is OpenFMS:

OpenFMS is a re-implentation of FIRST's FMS for controlling robots in an event. This software is used to control 3v3 matches with real-time scoring and year-specfic elements. 



## PLC Integration:

We use Automation Direct's FMS Hardware, which consits of a DoMore BRX PLC and many remote network cards to control inputs and outputs of the field. Just like the Allen-Bradley hardware the Offical Field uses, our hardware is only half as much money and works the same.



## Scoring: 

OpenFMS has the capabilites to use either automated PLC scoring or manual scoring. The automated scoring  is handled by Automation Direct's BRX PLC series and has the ability to have touchscreens for the referees. The manual scoring has the ability to scoring everything from year to year but is controlled by the scorekeeper/FMS operator.



## Networking:

OpenFMS uses two items to make the field networking safe for teams and robots for gameplay. First we use the Linksys 1900ACS Router that came into play in 2017, FIRST SteamWorks. It runs the OpenWRT software FIRST modified for FRC use. The second item is a Cisco Catalyst 3500-series Layer 3 managed switch, which allows us to reconfigure every match team specific VLANs to ensure safe and fair gameplay.



## Field Lighting:

The field lighting for each year will use an Arduino Uno and WS2812 LED Pixel strips. Each year this will change along with the game so stay tuned for changes.


## PLC and Field Lighting Programs:

Both the PLC and the field lighting controller (arduino) is included in the release of each year. Detailed instructions on how to write the programs to the PLC and arduino is comming soon to the WIKI. 

## Feature Requests:

If you want to request features you can do so by using the issues tab in the repository.
