#pragma once
#include"RentalAgreement.h"
class Invoice {
	double rentalCharges=0;
	double taxes=0;
	double totalAmountDue=0;
	rentalAgreement* agreement=NULL;
public:
	Invoice();
	Invoice(rentalAgreement*);
	void setAgreement(rentalAgreement*);
	void readtaxes();
	double getRentalCharges();
	double calculateTotalAmountDue();
	friend istream& operator>>(istream&, Invoice&);
	friend ostream& operator <<(ostream& out, Invoice& obj);
	//int operator -(int total_amount);//what i should pay the next time
	bool operator<(Invoice invoice);
	bool operator==(Invoice invoice);
	bool operator>(Invoice invoice);
	//ostream& operator <<(ostream& output);
};
