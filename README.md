OFMS is a re-implentation of FIRST's FMS for controlling robots in an event. This software is used to control 3v3 matches with real-time scoring and year-specfic elements. 



#PLC Integration:

We use Automation Direct's FMS Hardware, which consits of a DoMore BRX PLC and many remote network cards to control inputs and outputs of the field.



#Scoring: 

Scoring is handled by Automation Directs BRX PLC series and for the offseasons the sensors are provided by FIRST on the offical field for each year. 



#Networking:

OFMS requires you to use the Linksys 1900ACS by: Cisco and a Cisco 3500 series L3 Switch. The 1900ACS is flashed with the FIRST 2017 VLAN configuration for OpenWRT. The Cisco switch is configured for VLANs and reconfigured at the beginning of each match, to provide extra security for the teams.



#Field Lighting:

The field lighting for each year will use an Arduino and a WS2812 LED Pixel strips. Each year this will change along with the game so stay tuned for changes.



#Release Info:

We will try to release a pre-release version for the pre-season for week zero scrimmages and an offical release for each years off-seasons.


#PLC and Field Lighting Programs:

The PLC programs are programmed in Automation Direct's free programming software availible on their website:
https://support.automationdirect.com/products/domore.html
The OFMS PLC program is changed every year and will included in each years release.
The Arudino programs are programmed in Arduino's desktop IDE which is also free at their website:
https://www.arduino.cc/en/Main/Software
The OFMS Led program is also changed each year and will be included in each years release.


