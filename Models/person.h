#pragma once
#include"customer.h"
class Person :public Customer {
	string full_name;
	string address;
public:
	istream& readData(istream& input)override;
	ostream& printData(ostream& output) const override;
};
