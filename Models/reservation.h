#pragma once
#include"Date.h"
#include"invoice.h"
class Car;
class Customer;
enum reservationStatus { notCompleted, completed, canceled, still };
class Reservation {
	Date startDate;
	Date endDate;
	Car* c=NULL;
	Customer* m_customer=NULL;
	int customerId=0;
	int carId=0;
	Invoice invoice;
	string status;
public:
	Reservation();
	Reservation(Car*);
	Reservation(const Reservation&);//definition in class car
	void setStatue(reservationStatus s);
	string getStatue();
	int getCustomerId();
	int getCarId();
	Invoice getInvoice();
	Date getStartDate();
	Date getEndDate();
	int computePeriod();
	void setCar(Car*);
	void readCarId();
	void readCustomerName();
	void readInvoice();
	friend ostream& operator<<(ostream&, Reservation&);
	friend istream& operator>>(istream&, Reservation&);
	bool operator<(Reservation reservation);
	bool operator==(Reservation reservation);
	bool operator>(Reservation reservation);
};
