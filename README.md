# ARArduino
Interaction with 3d AR objects using Arduno board and sensors
### Prerequisites. What you need to reimplement the system
Hardware: Arduino board, breadboard, a couple of jump wires, two resistors,  t (KY-013) - and photosensors. Software: Arduino IDE, Unity, Vuforia, Uduino plug-in (https://marcteyssier.com/uduino/).  
### Installing
Hardware: 
Set up a circuit. Connect t and photosensor to 5V and analog pins (don't forget about resistors and ground)
Install Vuforia and add uduino plugin into the most recent unity editor. 
Choose your target for AR and create a license for your application. 
Test your target in unity. 
Set up communicaton between your board and unity editor via Uduino (https://marcteyssier.com/uduino/)
### Scripts 
As the scene contains several interactive objects: the sun (sunrays), cloud, rain, snow, rainbow and lightning each of these objects need to have a scripted behaviour. 
The Sun rays extend and change colour based on light sensor and t sensor values. The cloud dissipates gradually depending on the light intensity. It rains only when temp is high enough and the cloud is still there, as it dissipates when light analog value reaches a certain point beyound the predefined range of values. Once the temp drops down below a predefined value it starts snowing instead. Rainbow appears when it rains and snowrays can partially penetrate the cloud. Lightning strikes only when temp is high and the cloud is still there (the photo analog value is low)  

