#include <EEPROM.h>
char deviceid[] = "9YWKK19B9YntPRPn6DdrHQ";

char readdevid[sizeof(deviceid)];
void setup()
{
 Serial.begin(9600);
 Serial.println("Writing to EEPROM...");
 for (int i=0; i<sizeof(deviceid); i++) {
   EEPROM.write(i,deviceid[i]);
   readdevid[i] = EEPROM.read(i);
 }
 Serial.println("Writing DONE!");
 Serial.print("The size of Device ID writed is ");
 Serial.println(sizeof(readdevid));
 Serial.print("The ID of this device is ");
 Serial.print("'");
 Serial.print(readdevid);
 Serial.println("'");
}
void loop() {
}
