#include <iostream>
using namespace std;

#ifndef SHAPE_H
#define SHAPE_H

// Add Shape class here
class Shape {
  
  protected : 
    string name;
    
    Shape(string theName){
        name = theName;
    }
  public : 
  
  string getName(){
      return name;
  }
  
  virtual double getArea(){
      return -1;
  }
  
  virtual double getPerimeter(){
      return -1;
  }
    
};
#endif /* SHAPE_H_ */