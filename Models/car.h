#pragma once
#include<iostream>
#include"reservation.h"
using namespace std;
class Car {
	int id=0;
	string make;
	string model;
	int year=0;
	bool availability=1;
	Reservation* reserve=NULL;
	int reserve_count=0;
	int reserve_size=0;
public:
	Car(Reservation**,int);
	Car(int=3);
	void setReservations(Reservation**,int);
	void setReserveSize(int);
	int getReserveSize();
	int getId();
	bool addReservation(Reservation&);
	int getReserveCount();
	void lessenCount();
	bool checkSize();
	bool checkAvailability(Date start_date,Date end_date);
	friend istream& operator>>(istream& input, Car& obj);
	friend ostream& operator<<(ostream& output, const Car& obj);
	bool operator<(Car);
	bool operator==(Car car);
	bool operator>(Car car);
	~Car();
};
bool overlap(Date s1, Date d1, Date s2, Date d2);
