#include <iostream>

#include "Rectangle.h"
using namespace std;

#ifndef SQUARE_H_
#define SQUARE_H_

// Add Square class here
class Square : public Rectangle {
  
  public :
  
  Square(double size, string name) : Rectangle(size, size, name) {
      
  }
    
};
#endif /* SQUARE_H_ */