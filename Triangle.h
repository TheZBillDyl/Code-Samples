#include <iostream>
#include <cmath>

#include "Shape.h"
using namespace std;

#ifndef TRIANGLE_H_
#define TRIANGLE_H_

// Add Triangle class here
class Triangle : public Shape {
    
    double a, b, c;
    
    public :
    
    Triangle(double a, double b, double c, string name) : Shape(name){
        this->a = a;
        this->b = b;
        this->c = c;
    }
    
    
    private :
    
    bool isValid(){
        if(a+b > c && a+c > b && b+c > a){
            return true;
        }else {
            return false;
        }
    }
    
    public : 
    
    double getPerimeter(){
        if(!isValid()){
            //invalid
            return -1;
        }else {
            //valid
            return a+b+c;
        }
    }
    
    double getArea(){
        if(!isValid()){
            return -1;
        }else {
            double s = (a+b+c)/2;
            double theArea = sqrt(s*(s-a)*(s-b)*(s-c));
            return theArea;
        }
    }
};


#endif /* TRIANGLE_H_ */