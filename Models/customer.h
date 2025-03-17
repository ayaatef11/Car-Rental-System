#pragma once
#include<iostream>
#include"reservation.h"
using namespace std;
class Customer {
protected:
	int id = 0;
	int phoneNumber = 0;
	Reservation* x = NULL;
	int size_reserve = 0;
	int count_reserve = 0;
public:
	Customer(int=2);
	Customer(Reservation**, int);
	int getId();
	int getReseveSize();
	bool checkSize();
	bool addReservation(Reservation &r);
	void deleteReservation(Reservation& r);
	bool operator<(Customer &customer);
	bool operator==(Customer &customer);
	bool operator>(Customer &customer);
	friend istream& operator>>(istream& input, Customer& obj);
	friend ostream& operator<<(ostream& output, const Customer& obj);
	virtual istream& readData(istream& input) = 0;
	virtual ostream& printData(ostream& output) const = 0;
	~Customer();
};