#include <EEPROM.h>
#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
#include <avr/power.h> // Required for 16 MHz Adafruit Trinket
#endif

#define LED_PIN    6
#define LED_COUNT 24

int brightness = 1;
int effect = -1;
int READY = 0;
int trigger = 0;
int pin = -1;
int led = -1;

Adafruit_NeoPixel strip(LED_COUNT, LED_PIN, NEO_GRB + NEO_KHZ800);

char deviceid[22];
const char charTerminator = '\n';
const String version = "1.0";
String receivedString = "";



void setup() {
  Serial.begin(9600);

#if defined(__AVR_ATtiny85__) && (F_CPU == 16000000)
  clock_prescale_set(clock_div_1);
#endif

  strip.begin();
  strip.show();

  for (int i = 0; i < sizeof(deviceid); i++) {
    deviceid[i] = (char)EEPROM.read(i);
  }

}

void loop() {
  if (trigger == 1 && READY == 1) {
    switch (effect) {
      case 0:
        rainbow(1);
        break;
      case 1:
        theaterChaseRainbow(30);
        break;
    }
  }
}

void serialEvent() {
  while (Serial.available() > 0) {
    char incomingChar = (char)Serial.read();
    if (incomingChar == '=' && READY) {
      if (receivedString == "LP") {
        pin = Serial.parseInt();
      }
      if (receivedString == "LC") {
        led = Serial.parseInt();
      }
      if (receivedString == "FX") {
        effect = Serial.parseInt();
      }
      if (receivedString == "BR") {
        brightness = Serial.parseInt();

        strip.setBrightness(brightness);
        colorWipe(strip.Color(255,   255,   255), 15); //White
        colorWipe(strip.Color(255,   0,   0), 15); // Red
        colorWipe(strip.Color(  0, 255,   0), 15); // Green
        colorWipe(strip.Color(  0,   0, 255), 15); // Blue
        colorWipe(strip.Color(0,   0,   0), 15); //Blank

      }
//      if (receivedString == "SET") {
//        trigger = Serial.parseInt();
//        if (trigger == 0) {
//          colorWipe(strip.Color(0,   0,   0), 15); //Blank
//        }
//      }
      receivedString = "";
    } else if (incomingChar == ';') {
      if (receivedString == "PLAY" && READY) {
        trigger = 1;
      }
      if (receivedString == "STOP" && READY) {
        trigger = 0;
        colorWipe(strip.Color(0,   0,   0), 15); //Blank
        strip.show();
      }
      if (receivedString == "VS_RLA" && !READY) {
        Serial.print("VS_RLA"); Serial.print(charTerminator);
        Serial.print(deviceid); Serial.print(charTerminator);
      }
      if (receivedString == "OK" && !READY) {
        Serial.print("VINSTUDIOS_RLA"); Serial.print(charTerminator);
        READY = 1;
      }
      receivedString = "";
    } else if (incomingChar == '?' && READY) {
      if (receivedString == "BR") {
        Serial.print("BR"); Serial.print(charTerminator);
        Serial.print(brightness); Serial.print(charTerminator);
      }
      if (receivedString == "LC") {
        Serial.print("LC"); Serial.print(charTerminator);
        Serial.print(led); Serial.print(charTerminator);
      }
      if (receivedString == "LP") {
        Serial.print("LP"); Serial.print(charTerminator);
        Serial.print(pin); Serial.print(charTerminator);
      }
      if (receivedString == "FX") {
        Serial.print("FX"); Serial.print(charTerminator);
        Serial.print(effect); Serial.print(charTerminator);
      }
      if (receivedString == "VS") {
        Serial.print("VS"); Serial.print(charTerminator);
        Serial.print(version); Serial.print(charTerminator);
      }
      receivedString = "";
    } else {
      receivedString += incomingChar;
    }
  }
}


void colorWipe(uint32_t color, int wait) {
  for (int i = 0; i < strip.numPixels(); i++) { // For each pixel in strip...
    strip.setPixelColor(i, color);         //  Set pixel's color (in RAM)
    strip.show();                          //  Update strip to match
    delay(wait);                           //  Pause for a moment
  }
}

void rainbow(int wait) {
  for (long firstPixelHue = 0; firstPixelHue < 5 * 65536; firstPixelHue += 256) {
    for (int i = 0; i < strip.numPixels(); i++) {
      int pixelHue = firstPixelHue + (i * 65536L / strip.numPixels());
      strip.setPixelColor(i, strip.gamma32(strip.ColorHSV(pixelHue)));
    }
    strip.show();
    delay(wait);
  }
}

// Slightly different, this makes the rainbow equally distributed throughout
void theaterChaseRainbow(int wait) {
  int firstPixelHue = 0;
  for (int a = 0; a < 30; a++) {
    for (int b = 0; b < 3; b++) {
      strip.clear();
      for (int c = b; c < strip.numPixels(); c += 3) {
        int      hue   = firstPixelHue + c * 65536L / strip.numPixels();
        uint32_t color = strip.gamma32(strip.ColorHSV(hue));
        strip.setPixelColor(c, color);
      }
      strip.show();
      delay(wait);
      firstPixelHue += 65536 / 90;
    }
  }
}
