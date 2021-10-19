#include <iostream>
#include "Shape.h"
using namespace std;

#ifndef RECTANGLE_H_
#define RECTANGLE_H_

// Add Rectangle class here
class Rectangle : public Shape {
  
 // string name;
  double length;
  double width;
  public:
  Rectangle(double length, double width, string theName) : Shape(theName) {
      this->length = length;
      this->width = width;
  }
   double getPerimeter(){
        double perm = 2 * (length + width);
        return perm;
    }
    
    double getArea() {
        double theArea = length * width;
        return theArea;
    }
};

#endif /* RECTANGLE_H_ */