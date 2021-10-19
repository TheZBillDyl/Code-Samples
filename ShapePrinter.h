#include <iostream>

#include "Shape.h"
#include "Rectangle.h"
#include "Square.h"
#include "Triangle.h"
using namespace std;

#ifndef SHAPEPRINTER_H_
#define SHAPEPRINTER_H_

// Add prettyPrint method here (do not add a class)
 void prettyPrint(Shape *shape){
   
    if(shape->getPerimeter() < 0){
        cout << shape->getName() << " is invalid!" << endl;
    }else {
        cout << "Perimeter of " << shape->getName() << " is " << shape->getPerimeter() << endl;
        cout << "Area of " << shape->getName() << " is " << shape->getArea() << endl;
    }
    
    
}
#endif /* SHAPEPRINTER_H_ */