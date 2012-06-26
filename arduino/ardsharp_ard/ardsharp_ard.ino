
// configure some input bytes
// that we can use to pass information
// to and from c#
byte inputByte_0;  // verification byte - should be 42
byte inputByte_1;  // command byte - the action to perform
byte inputByte_2;  // pin byte - the number of the pin
byte inputByte_3;  // value byte - the value to set
byte inputByte_4;  // extra byte - for expansion

int portNumber = 9600;  // default port - 9600
int inputParse = 0;

/*
  The setup item. Initializes the serial port
  for communication with c#
*/
void setup() 
{
  // initialize and wait for command
  Serial.begin(portNumber);
}

/*
  Game style loop. Iterates and attempts to read
  the five bytes.
*/
void loop() 
{
  if (Serial.available() == 5) 
  {
    // Read the buffer from the serial port
    inputByte_0 = Serial.read();
    inputByte_1 = Serial.read();
    inputByte_2 = Serial.read();
    inputByte_3 = Serial.read();
    inputByte_4 = Serial.read();
    
    process();
  }
}

/*
  Process the bytes if they are recieved
  from the client.
*/
void process() 
{
  // check the verification byte to make sure
  // we are buddies
  if(inputByte_0 != 42)
    return;
  
  // switch on the command from the
  // first indexer
  switch(inputByte_1)
  {
    // initialize
    case 100:
      Serial.print("hi");
      break;
      
    // pin mode
    case 101:
      // parse the input byte
      inputParse = OUTPUT;
      if(inputByte_3 == 0)
        inputParse = INPUT;
      if(inputByte_3 == 2)
        inputParse = INPUT_PULLUP;
      // check for other types here
      pinMode(inputByte_2, inputParse);
      break;
    
    // digital write
    case 102:
      digitalWrite(inputByte_2, inputByte_3);
      break;
  }
  
  // clear Message bytes so we
  // can recieve more messages.
  inputByte_0 = 0;
  inputByte_1 = 0;
  inputByte_2 = 0;
  inputByte_3 = 0;
  inputByte_4 = 0;
}
