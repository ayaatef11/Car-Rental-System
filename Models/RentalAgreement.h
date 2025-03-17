#pragma once
#include<iostream>
//#include"car.h" no never
//#include"reservation.h"
class Car;
class Reservation;
using namespace std;
class rentalAgreement {
	int rentalPeriod=0;
	double rentalRate=0;
	double rentalPrice=0;
	double insuranceCharges=0;
	Car* c=NULL;
	Reservation* r = NULL;
public:
	//modify insurance charges to be rented when the state of he car is well
	rentalAgreement();
	int getRentalPeriod();
	double getRentalRate();
	double getInsuranceCharges();
	double getRentalPrice();
	double operator +(int price);
	bool operator<(rentalAgreement rentalAgreement);
	bool operator>(rentalAgreement rentalAgreement);
	bool operator==(rentalAgreement rentalAgreement);
	friend istream& operator >>(istream&, rentalAgreement&);
	friend ostream& operator<<(ostream&,  rentalAgreement&);
};
